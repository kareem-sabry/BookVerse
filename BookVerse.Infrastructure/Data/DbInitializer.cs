using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using BookVerse.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BookVerse.Infrastructure.Data;

public static class DbInitializer
{
    public static async Task SeedDataAsync(AppDbContext context, UserManager<User> userManager,
        RoleManager<IdentityRole<Guid>> roleManager, IOptions<AdminUserOptions> adminOptions, ILogger logger,
        IDateTimeProvider dateTimeProvider)
    {
        //Apply pending migrations
        await context.Database.MigrateAsync();

        //Seed roles if they don`t exist
        await SeedRolesAsync(roleManager);

        //Seed admin user if doesn't exist
        await SeedAdminUserAsync(userManager, adminOptions.Value, logger, dateTimeProvider);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole<Guid>> roleManager)
    {
        //Check if Admin role exists
        if (!await roleManager.RoleExistsAsync(IdentityRoleConstants.Admin))
            await roleManager.CreateAsync(new IdentityRole<Guid>
            {
                Id = IdentityRoleConstants.AdminRoleGuid,
                Name = IdentityRoleConstants.Admin,
                NormalizedName = IdentityRoleConstants.Admin.ToUpper()
            });

        if (!await roleManager.RoleExistsAsync(IdentityRoleConstants.User))
            await roleManager.CreateAsync(new IdentityRole<Guid>
            {
                Id = IdentityRoleConstants.UserRoleGuid,
                Name = IdentityRoleConstants.User,
                NormalizedName = IdentityRoleConstants.User.ToUpper()
            });
    }

    private static async Task SeedAdminUserAsync(UserManager<User> userManager, AdminUserOptions admin, ILogger logger,
        IDateTimeProvider dateTimeProvider)
    {
        if (string.IsNullOrWhiteSpace(admin.Email))
        {
            logger.LogWarning("AdminUser.Email is missing");
            return;
        }

        var existingAdmin = await userManager.FindByEmailAsync(admin.Email);
        if (existingAdmin != null)
        {
            logger.LogInformation("Admin user {Email} already exists.", admin.Email);
            if (!await userManager.IsInRoleAsync(existingAdmin, IdentityRoleConstants.Admin))
            {
                await userManager.AddToRoleAsync(existingAdmin, IdentityRoleConstants.Admin);
                logger.LogInformation("Added Admin role to existing admin user.");
            }

            return;
        }

        var user = User.Create(admin.Email, admin.FirstName, admin.LastName,
            dateTimeProvider.UtcNow);

        var createResult = await userManager.CreateAsync(user, admin.Password);

        if (!createResult.Succeeded)
        {
            logger.LogError("Failed to create Admin user.");
            foreach (var error in createResult.Errors) logger.LogError("  - {ErrorDescription}", error.Description);

            return;
        }

        await userManager.AddToRoleAsync(user, IdentityRoleConstants.Admin);
        logger.LogInformation("Admin user created successfully.");
        logger.LogInformation("   Email: {Email}", admin.Email);
        logger.LogInformation("   FirstName: {FirstName}", admin.FirstName);
        logger.LogInformation("   LastName: {LastName}", admin.LastName);
    }
}