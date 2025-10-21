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
            var result = await userManager.CreateAsync(adminUser, "Admin123456!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        var testUserAccount = new UserAccount
        {
            UserName = "user",
            Amount = 1000,
            ActiveStatus = true
        };

        var res = await context.UserAccounts.AddAsync(testUserAccount);
        await context.SaveChangesAsync();

        if (res != null)
        {
            var testUser = new ApiUser
            {
                UserName = testUserAccount.UserName,
                UserAccount = testUserAccount
            };

            if (await userManager.FindByNameAsync("user") == null)
            {
                var result = await userManager.CreateAsync(testUser, "Password123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(testUser, "User");
                }
            }
        }
    }
}

