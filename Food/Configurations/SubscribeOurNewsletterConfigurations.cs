using Food.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.Configurations
{
    public class SubscribeOurNewsletterConfigurations : IEntityTypeConfiguration<SubscribeEmail>
    {
        public void Configure(EntityTypeBuilder<SubscribeEmail> builder)
        {
            builder.ToTable("SubscribeEmail");
            builder.HasKey(t => new { t.Id });
        }
    }
}
