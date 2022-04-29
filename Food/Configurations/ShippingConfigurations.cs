using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Entity;

namespace Food.Configurations
{
    public class ShippingConfigurations : IEntityTypeConfiguration<Shipping>
    {

        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.ToTable("Shipping");
            builder.HasKey(t => new { t.ship_Id });



        }
    }
}
