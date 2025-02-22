using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

public static class DatabaseSeeder_Identity
{
    public static async Task SeedIdentityAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        // Roles
        if (!roleManager.Roles.Any())
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));
        }

        if (!userManager.Users.Any(u => u.UserName == "admin"))
        {
            var adminUser = new IdentityUser { UserName = "admin", Email = "admin@email.com" };
            await userManager.CreateAsync(adminUser, "Admin@123"); // Password
            await userManager.AddToRoleAsync(adminUser, "Admin"); // Privilege
        }

        if (!userManager.Users.Any(u => u.UserName == "user"))
        {
            var regularUser = new IdentityUser { UserName = "user", Email = "user@email.com" };
            await userManager.CreateAsync(regularUser, "User@123"); // Password
            await userManager.AddToRoleAsync(regularUser, "User"); // Privilege
        }
    }
}

