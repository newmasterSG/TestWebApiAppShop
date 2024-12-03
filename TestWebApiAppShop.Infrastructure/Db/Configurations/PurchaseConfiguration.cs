using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApiAppShop.Domain.Entity;

namespace TestWebApiAppShop.Infrastructure.Db.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.OrderNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Date)
                .IsRequired();

            builder.Property(p => p.TotalCost)
                .IsRequired()
                .HasPrecision(18,2);
        }
    }
}
