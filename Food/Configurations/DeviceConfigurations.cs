using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.Configurations
{
    public class DeviceConfigurations : IEntityTypeConfiguration<Device>
    {

        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Device");
            builder.HasKey(t => new { t.deviceId });



        }
    }
}
