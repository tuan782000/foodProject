using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.Configurations
{
    public class ContactUsersConfigurations : IEntityTypeConfiguration<ContactUsers>
    {
        public void Configure(EntityTypeBuilder<ContactUsers> builder)
        {
            builder.ToTable("ContactUsers");
            builder.HasKey(t => new { t.cu_Id });
        }
    }
}
