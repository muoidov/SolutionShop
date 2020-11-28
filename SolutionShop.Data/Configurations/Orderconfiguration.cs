using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolutionShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.Data.Configurations
{
    public class Orderconfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(t => t.Id);
            builder.Property(x => x.ShipEmail).IsRequired().IsUnicode(false);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
        }
    }
}
