using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolutionShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.Data.Configurations
{
    public class OrderDetailconfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)

        {
            builder.ToTable("OrderDetails");
            builder.HasKey(x => new { x.OrderId, x.ProductId });
            builder.HasOne(t => t.Order).WithMany(x => x.OrderDetails).HasForeignKey(t => t.OrderId);
            builder.HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(t => t.ProductId);
        }
    }
}
