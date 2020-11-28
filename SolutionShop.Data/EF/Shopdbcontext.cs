using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolutionShop.Data.Configurations;
using SolutionShop.Data.Entities;
using SolutionShop.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.Data.EF
{
   public class Shopdbcontext : IdentityDbContext<AppUser,AppRole,Guid> { 
        public Shopdbcontext(DbContextOptions options) : base(options)
        {
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Appconfiguration());
            modelBuilder.ApplyConfiguration(new Productconfiguration());
            modelBuilder.ApplyConfiguration(new Categoryconfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryconfiguration());
            modelBuilder.ApplyConfiguration(new Orderconfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailconfiguration());
            modelBuilder.ApplyConfiguration(new Promotionconfiguration());
            modelBuilder.ApplyConfiguration(new Cartconfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationconfiguration());
            modelBuilder.ApplyConfiguration(new Contactconfiguration());
            modelBuilder.ApplyConfiguration(new Transactionconfiguration());
            modelBuilder.ApplyConfiguration(new Languageconfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationconfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageconfiguration());
            modelBuilder.ApplyConfiguration(new Promotionconfiguration());
            modelBuilder.ApplyConfiguration(new AppUserconfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleconfiguration());
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x=>new {x.UserId,x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x=>x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x=>x.UserId);
            //Data seed
            modelBuilder.Seed();   
        }
            //base.OnModelCreating(modelBuilder);
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<AppConfig> AppConfigs { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<ProductInCategory> ProductInCategories { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        //public DbSet<Slide> Slides { get; set; }
    }
}
