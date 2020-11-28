using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolutionShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.Data.Configurations
{
    class AppRoleconfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("AppRoles");
         //   builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();



        }
    }


}
