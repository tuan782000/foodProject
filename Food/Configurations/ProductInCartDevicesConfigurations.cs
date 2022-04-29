using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Entity;

namespace Food.Configurations
{
    public class ProductInCartDevicesConfigurations : IEntityTypeConfiguration<ProductInCartDevices>
    {
        public void Configure(EntityTypeBuilder<ProductInCartDevices> builder)
        {
            builder.ToTable("ProductInCartDevices");
            builder.HasKey(t => new { t.picd_CartId, t.picd_ProductId });
            builder.HasOne(t => t.ProductsPICD).WithMany(ur => ur.ProductInCartDevicesP)
     .HasForeignKey(pc => pc.picd_ProductId);
            builder.HasOne(t => t.CartsDevicePICD).WithMany(ur => ur.ProductInCartDevicesCD)
     .HasForeignKey(pc => pc.picd_CartId);

        }
    }
}
