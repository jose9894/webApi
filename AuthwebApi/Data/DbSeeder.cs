using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AuthwebApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;



namespace AuthwebApi.Data;

public static class AuthAppDbSeeder
{

    public async static Task Seed(AuthAppDbContext context, UserManager<ApiUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        context.Database.EnsureCreated();

        if (await userManager.FindByNameAsync("admin") != null) return; 

        // Create roles
        string[] roleNames = { "Admin", "User" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var adminUser = new ApiUser
        {
            UserName = "admin",
        };

        if (await userManager.FindByNameAsync("admin") == null)
        {
            var result = await userManager.CreateAsync(adminUser, "Admin1234567");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}

