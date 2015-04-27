﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OMoney.Data.Configuration;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Context
{
    public class DomainDbContext : DbContext
    {
        public DomainDbContext() : base("name=DomainContext")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopingList> ShopingLists { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<CatItem> CatItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<IdentityUserClaim>();
            modelBuilder.Ignore<IdentityUserLogin>();
            modelBuilder.Ignore<IdentityUserRole>();
            modelBuilder.Ignore<IdentityRole>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
