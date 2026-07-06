using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Threading.RateLimiting;
using Asp.Versioning;
using BookVerse.Api.Middlewares;
using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using BookVerse.Core.Models;
using BookVerse.Infrastructure.Data;
using BookVerse.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Formatting.Compact;
using Stripe;
using AccountService = BookVerse.Infrastructure.Services.AccountService;

var builder = WebApplication.CreateBuilder(args);

// ====================================
// LOGGING - SERILOG
// ====================================

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .Enrich.WithProcessId()
        .Enrich.WithThreadId()
        .Enrich.WithProperty("Application", "BookVerse");

    if (context.HostingEnvironment.IsDevelopment())
    {
        configuration.WriteTo.Console(
            outputTemplate:
            "[{Timestamp:HH:mm:ss} {Level:u3}] [{CorrelationId:l}] {SourceContext}{NewLine}  {Message:lj}{NewLine}{Exception}");
    }
    else
    {
        configuration.WriteTo.Console(new CompactJsonFormatter());
    }

    var seqUrl = context.Configuration["Seq:ServerUrl"];
    if (!string.IsNullOrEmpty(seqUrl))
    {
        configuration.WriteTo.Seq(seqUrl);
    }
});


// ====================================
// CONFIGURATION
// ====================================
if (builder.Environment.IsDevelopment())
    builder.Configuration.AddUserSecrets<Program>();

// ====================================
// DATA PROTECTION
// ====================================
var dataProtectionKeysPath = builder.Configuration["DataProtection:KeysPath"] ??
                             Path.Combine(AppContext.BaseDirectory, "dataprotection-keys");

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(dataProtectionKeysPath))
    .SetApplicationName("BookVerse");

// ====================================
// DATABASE
// ====================================

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.MigrationsAssembly("BookVerse.Infrastructure");
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorNumbersToAdd: null);
        })
);

// ====================================
// HTTP CONTEXT & CONTROLLERS
// ====================================


builder.Services.AddHttpContextAccessor();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddControllers();

// [ApiController] already short-circuits with its own response BEFORE any ActionMethod runs whenever ModelState is invalid This factory makes that automatic, unavoidable response use the same BasicResponse shape as the rest of the API instead of the framework's default ValidationProblemDetails.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var problemDetails = new ValidationProblemDetails(context.ModelState)
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Validation Error",
            Instance = context.HttpContext.Request.Path,
            Type = $"https://httpstatuses.com/{StatusCodes.Status400BadRequest}"
        };
        problemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;
        problemDetails.Extensions["correlationId"] = context.HttpContext.Items["X-Correlation-Id"]?.ToString();

        return new BadRequestObjectResult(problemDetails);
    };
});
builder.Services.AddRateLimiter(options =>
{
    // Global rate limit
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
        RateLimitPartition.GetFixedWindowLimiter(
            context.User.FindFirstValue(ClaimTypes.NameIdentifier) ??
            context.Connection.RemoteIpAddress?.ToString() ?? "anonymous",
            partition => new FixedWindowRateLimiterOptions
            {
                AutoReplenishment = true,
                PermitLimit = 100,
                QueueLimit = 0,
                Window = TimeSpan.FromMinutes(1)
            }));

    /// Strict per-IP rate limit for auth endpoints
    options.AddPolicy("auth", context =>
        RateLimitPartition.GetFixedWindowLimiter(
            context.Connection.RemoteIpAddress?.ToString() ?? "anonymous",
            _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5,
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 0,
                AutoReplenishment = true
            }));

    // Moderate per-IP rate limit for public endpoints
    options.AddPolicy("api", context =>
        RateLimitPartition.GetFixedWindowLimiter(
            context.Connection.RemoteIpAddress?.ToString() ?? "anonymous",
            _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 50,
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 0,
                AutoReplenishment = true
            }));

    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = 429;
        context.HttpContext.Response.Headers["Retry-After"] = "60";
        await context.HttpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = 429,
            Title = "Too Many Requests",
            Detail = "You have exceeded the request rate limit. Please try again later.",
            Instance = context.HttpContext.Request.Path,
            Type = "https://httpstatuses.com/429"
        }, token);
    };
});
builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();

// Redis distributed cache
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "BookVerse";
});
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version")
    );
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
// ====================================
// IDENTITY CONFIGURATION
// ====================================

builder.Services.AddIdentity<User, IdentityRole<Guid>>(opt =>
    {
        //Password requirements
        opt.Password.RequireDigit = true;
        opt.Password.RequireLowercase = true;
        opt.Password.RequireUppercase = true;
        opt.Password.RequireNonAlphanumeric = true;
        opt.Password.RequiredLength = ApplicationConstants.MinPasswordLength;

        //User requirements
        opt.User.RequireUniqueEmail = true;

        //Lockout settings
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
        opt.Lockout.MaxFailedAccessAttempts = 5;
        opt.Lockout.AllowedForNewUsers = true;

        //Token providers
        opt.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultProvider;
    }).AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Configure password reset token lifespan
builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
{
    opt.TokenLifespan = TimeSpan.FromHours(ApplicationConstants.PasswordResetTokenExpirationHours);
});

// ====================================
// JWT AUTHENTICATION
// ====================================

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var jwtOptions = builder.Configuration.GetSection(JwtOptions.JwtOptionsKey).Get<JwtOptions>();

    if (jwtOptions == null)
        throw new ValidationException(
            $"JWT configuration is missing. Please configure '{JwtOptions.JwtOptionsKey}' section.");

    if (string.IsNullOrEmpty(jwtOptions.Secret) || jwtOptions.Secret.Length < 32)
        throw new ArgumentException("JWT Secret must be at least 32 characters long.");

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtOptions.Issuer,
        ValidAudience = jwtOptions.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
        RoleClaimType = ClaimTypes.Role,
        ClockSkew = TimeSpan.Zero
    };

    //Jwt events
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogWarning("Authentication failed: {Message}", context.Exception.Message);
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            var userEmail = context.Principal?.Identity?.Name;
            logger.LogDebug("Token validated for user: {User}", userEmail);

            return Task.CompletedTask;
        },
        OnChallenge = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogWarning("Authentication challenge: {Error} - {ErrorDescription}",
                context.Error, context.ErrorDescription);
            return Task.CompletedTask;
        }
    };
});

// ====================================
// AUTHORIZATION POLICIES
// ====================================

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole(IdentityRoleConstants.Admin));
    options.AddPolicy("UserOnly", policy => policy.RequireRole(IdentityRoleConstants.User));
});

// ====================================
// SWAGGER / OPENAPI
// ====================================

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    // API Info
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BookVerse API",
        Version = "v1",
        Description = "A comprehensive bookstore API - Version 1",
        Contact = new OpenApiContact
        {
            Name = "BookVerse Support",
            Email = "support@bookverse.com"
        }
    });

    // JWT Authentication
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your JWT token."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// ====================================
// OPTIONS PATTERN CONFIGURATION
// ====================================

builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection(JwtOptions.JwtOptionsKey));

builder.Services.Configure<AdminUserOptions>(
    builder.Configuration.GetSection("AdminUser"));

builder.Services.Configure<EmailOptions>(
    builder.Configuration.GetSection("EmailOptions"));

builder.Services.AddOptions<StripeOptions>()
    .BindConfiguration(StripeOptions.StripeOptionsKey)
    .ValidateDataAnnotations()
    .ValidateOnStart();
// ====================================
// DEPENDENCY INJECTION
// ====================================


// Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IAuthorsService, AuthorsService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// payments
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddTransient<IStripePaymentIntentService, StripePaymentIntentService>();
builder.Services.AddTransient<PaymentIntentService>();
builder.Services.AddTransient<IStripeWebhookConstructor, StripeWebhookConstructor>();
builder.Services.AddTransient<IStripeRefundService, StripeRefundService>();
builder.Services.AddTransient<Stripe.RefundService>();

builder.Services.AddSingleton<ICacheService, RedisCacheService>();
builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

// Token Processing
builder.Services.AddScoped<IAuthTokenProcessor, AuthTokenProcessorService>();
// Health Check
builder.Services.AddHealthChecks()
    .AddDbContextCheck<AppDbContext>();
//AutoMapper
builder.Services.AddAutoMapper(
    cfg => cfg.LicenseKey = builder.Configuration["AutoMapper:LicenseKey"],
    typeof(BookVerse.Infrastructure.Profiles.MappingProfile).Assembly
);

// ====================================
// CORS CONFIGURATION
// ====================================

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentPolicy", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });

    options.AddPolicy("ProductionPolicy", policy =>
    {
        var allowedOrigin = builder.Configuration["Cors:AllowedOrigin"] ??
                            "https://bookverseapi.com";
        policy.WithOrigins(allowedOrigin)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

// ====================================
// BUILD APPLICATION
// ====================================

var app = builder.Build();

// ====================================
// STRIPE CONFIGURATION
// ====================================

var stripeOptions = app.Services.GetRequiredService<IOptions<StripeOptions>>().Value;
StripeConfiguration.ApiKey = stripeOptions.SecretKey;

// ====================================
// DATABASE SEEDING
// ====================================

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        logger.LogInformation("Starting database seeding...");

        var context = services.GetRequiredService<AppDbContext>();
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        var adminOptions = services.GetRequiredService<IOptions<AdminUserOptions>>();
        var dateTimeProvider = services.GetRequiredService<IDateTimeProvider>();
        await DbInitializer.SeedDataAsync(context, userManager, roleManager, adminOptions, logger, dateTimeProvider);
        logger.LogInformation("Database seeding completed successfully");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// ====================================
// MIDDLEWARE PIPELINE
// ====================================

app.UseMiddleware<CorrelationIdMiddleware>();

// Structured HTTP request logging (replaces default Microsoft request logging)
app.UseSerilogRequestLogging(options =>
{
    options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";
    options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
    {
        diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
        diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
        diagnosticContext.Set("UserAgent", httpContext.Request.Headers.UserAgent.ToString());
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!string.IsNullOrEmpty(userId))
            diagnosticContext.Set("UserId", userId);
    };
});

// Must be as early as possible so all downstream exceptions are caught
app.UseExceptionHandler(opt => { });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "BookVerse API v1");
        options.RoutePrefix = "docs";
    });
    app.UseCors("DevelopmentPolicy");
}
else
{
    app.UseCors("ProductionPolicy");
}

// Security headers on every response
app.Use(async (context, next) =>
{
    context.Response.Headers["X-Content-Type-Options"] = "nosniff";
    context.Response.Headers["X-Frame-Options"] = "DENY";
    context.Response.Headers["X-XSS-Protection"] = "1; mode=block";
    context.Response.Headers["Referrer-Policy"] = "strict-origin-when-cross-origin";
    context.Response.Headers["Content-Security-Policy"] = app.Environment.IsDevelopment()
        ? "default-src 'self'; script-src 'self' 'unsafe-inline'; style-src 'self' 'unsafe-inline'; img-src 'self' data:"
        : "default-src 'none'; frame-ancestors 'none'";

    await next();
});

app.UseRateLimiter();
app.UseResponseCaching();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Intentionally unauthenticated — allows load balancers and container
// orchestrators (Docker, Kubernetes) to probe without credentials.
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var dateTimeProvider = context.RequestServices.GetRequiredService<IDateTimeProvider>();

        var result = new
        {
            status = report.Status.ToString(),
            checkedAt = dateTimeProvider.UtcNow,
            duration = report.TotalDuration,
            checks = report.Entries.Select(e => new
            {
                name = e.Key,
                status = e.Value.Status.ToString(),
                description = e.Value.Description,
                duration = e.Value.Duration,
                error = app.Environment.IsDevelopment() ? e.Value.Exception?.Message : null
            })
        };

        await context.Response.WriteAsJsonAsync(result);
    }
});

try
{
    app.Run();
}
finally
{
    Log.CloseAndFlush();
}