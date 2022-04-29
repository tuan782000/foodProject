using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Entity;

namespace Food.Configurations
{
    public class CartsDeviceConfigurations : IEntityTypeConfiguration<CartsDevice>
    {

        public void Configure(EntityTypeBuilder<CartsDevice> builder)
        {
            builder.ToTable("CartsDevice");
            builder.HasKey(t => new { t.cartd_Id });
            builder.HasOne(t => t.DeviceCD).WithMany(ur => ur.CartsDeviceD)
     .HasForeignKey(pc => pc.cartd_DeviceId);


        }
    }
}
