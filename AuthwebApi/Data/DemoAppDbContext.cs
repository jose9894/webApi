using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AuthwebApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace AuthwebApi.Data;

public class AuthAppDbContext : IdentityDbContext<ApiUser>
{
    public AuthAppDbContext()
    {
    }

    public AuthAppDbContext(DbContextOptions<AuthAppDbContext> options)
        : base(options)
    {
    }

        // public DbSet<Deposit> Deposits { get; set; }
        // public DbSet<Transaction> Transactions { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

}

