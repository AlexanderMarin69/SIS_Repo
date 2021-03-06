﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vueproject.DB
{
    public class vueprojectDatabaseContext : IdentityDbContext<IdentityUser>
    {
        public vueprojectDatabaseContext(DbContextOptions<vueprojectDatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Models.Product> Products { get; set; }
        //public DbSet<Models.Category> Categories { get; set; }
        //public DbSet<Models.Subcategory> Subcategories { get; set; }
        public DbSet<Models.Invoice> Invoices { get; set; }
        public DbSet<Models.Customer> Customers { get; set; }
    }
}

