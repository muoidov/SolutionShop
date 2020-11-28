using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolutionShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.Data.Configurations
{
    public class AppUserconfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
           // builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Dob).IsRequired();


           

        }
    }
    
    
}
