using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using BookVerse.Core.Interfaces;
using BookVerse.Infrastructure.Data.Seeds;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor,
        IDateTimeProvider dateTimeProvider) :
        base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        _dateTimeProvider = dateTimeProvider;
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }

    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>()
            .Property(b => b.Price)
            .HasPrecision(18, 4);
        modelBuilder.Entity<Book>()
            .Property(b => b.RowVersion)
            .IsRowVersion();
        modelBuilder.Entity<Book>().HasIndex(b => b.Title).HasDatabaseName("IX_BooksTitle");
        modelBuilder.Entity<CartItem>()
            .Property(c => c.PriceAtAdd)
            .HasPrecision(18, 4);
        ConfigureUserEntity(modelBuilder);
        ConfigureBookAuthorRelationship(modelBuilder);
        ConfigureBookCategoryRelationship(modelBuilder);
        ConfigureCartRelationships(modelBuilder);
        ConfigureOrderRelationships(modelBuilder);
        SeedData(modelBuilder);
    }

    private static void ConfigureOrderRelationships(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(o => o.OrderNumber)
                .IsUnique();

            entity.HasIndex(o => o.UserId);

            entity.HasIndex(o => o.OrderDate);
            entity.HasIndex(o => o.StripePaymentIntentId);
            // Covering index for GetUserOrdersAsync.
            // Query pattern: WHERE UserId = @id ORDER BY OrderDate DESC
            // Without this index, SQL Server does a clustered index scan over all orders and then sorts — O(n) per user. With it, the seek is O(log n) and the INCLUDE columns eliminate a key lookup back to the clustered index.

            entity.HasIndex(o => new { o.UserId, o.OrderDate })
                .IsDescending(false, true) // UserId ASC, OrderDate DESC
                .IncludeProperties(
                    nameof(Order.Status),
                    nameof(Order.TotalAmount),
                    nameof(Order.OrderNumber),
                    nameof(Order.PaymentStatus))
                .HasDatabaseName("IX_Orders_UserId_OrderDate_Covering");

            entity.Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            // RowVersion optimistic concurrency
            entity.Property(o => o.RowVersion).IsRowVersion();


            entity.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.Property(oi => oi.PriceAtOrder)
                .HasPrecision(18, 2);
            entity.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(oi => oi.Book)
                .WithMany()
                .HasForeignKey(oi => oi.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(oi => oi.BookId);
        });
    }

    private static void ConfigureCartRelationships(ModelBuilder modelBuilder)
    {
        // One User has One Cart
        modelBuilder.Entity<Cart>()
            .HasOne(c => c.User)
            .WithOne(u => u.Cart)
            .HasForeignKey<Cart>(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // One Cart has Many CartItems
        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Book)
            .WithMany()
            .HasForeignKey(ci => ci.BookId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CartItem>()
            .HasIndex(ci => ci.BookId);
    }

    private static void ConfigureBookCategoryRelationship(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.HasKey(bc => new { bc.BookId, bc.CategoryId });

            entity.HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void ConfigureBookAuthorRelationship(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.HasKey(ba => new { ba.BookId, ba.AuthorId });

            entity.HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void ConfigureUserEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(u => u.RefreshToken)
                .HasMaxLength(500);

            entity.Property(u => u.PreviousRefreshToken)
                .HasMaxLength(500);

            entity.HasIndex(u => u.RefreshToken);
            entity.HasIndex(u => u.PreviousRefreshToken);
        });
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Roles
        modelBuilder.Entity<IdentityRole<Guid>>()
            .HasData(new List<IdentityRole<Guid>>
            {
                new()
                {
                    Id = IdentityRoleConstants.AdminRoleGuid,
                    Name = IdentityRoleConstants.Admin,
                    NormalizedName = IdentityRoleConstants.Admin.ToUpper()
                },
                new()
                {
                    Id = IdentityRoleConstants.UserRoleGuid,
                    Name = IdentityRoleConstants.User,
                    NormalizedName = IdentityRoleConstants.User.ToUpper()
                }
            });

        //Seed Authors, Categories, Books, and Relationships
        modelBuilder.Entity<Author>().HasData(AuthorSeed.GetAuthors());
        modelBuilder.Entity<Category>().HasData(CategorySeed.GetCategories());
        modelBuilder.Entity<Book>().HasData(BookSeed.GetBooks());
        modelBuilder.Entity<BookAuthor>().HasData(BookAuthorSeed.GetBookAuthors());
        modelBuilder.Entity<BookCategory>().HasData(BookCategorySeed.GetBookCategories());
    }

    private void ApplyAuditInformation()
    {
        var currentUserEmail =
            _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? ApplicationConstants.SystemUser;

        var currentTime = _dateTimeProvider.UtcNow;
        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
            if (entry.Entity is IAuditable auditableEntity)
            {
                if (entry.State == EntityState.Added)
                {
                    auditableEntity.CreatedAtUtc = currentTime;
                    auditableEntity.UpdatedAtUtc = currentTime;
                    auditableEntity.CreatedBy = currentUserEmail;
                    auditableEntity.UpdatedBy = currentUserEmail;
                }
                else if (entry.State == EntityState.Modified)
                {
                    auditableEntity.UpdatedAtUtc = currentTime;
                    auditableEntity.UpdatedBy = currentUserEmail;

                    // Prevent anyone from changing the createdBy or createdAt once set.
                    entry.Property(nameof(IAuditable.CreatedAtUtc)).IsModified = false;
                    entry.Property(nameof(IAuditable.CreatedBy)).IsModified = false;
                }
            }

            // Handle entities implementing ITimestampedEntity (join tables)
            else if (entry.Entity is ITimestampedEntity timestampedEntity && entry.State == EntityState.Added)
            {
                timestampedEntity.CreatedAtUtc = currentTime;
            }

            // Handle User entity separately (doesn't implement IAuditable)
            else if (entry.Entity is User user)
            {
                if (entry.State == EntityState.Added)
                {
                    user.CreatedAtUtc = currentTime;
                    user.UpdatedAtUtc = currentTime;
                }
                else if (entry.State == EntityState.Modified)
                {
                    user.UpdatedAtUtc = currentTime;
                    entry.Property(nameof(user.CreatedAtUtc)).IsModified = false;
                }
            }
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditInformation();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        ApplyAuditInformation();
        return base.SaveChanges();
    }
}