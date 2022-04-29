using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Entity;

namespace Food.Configurations
{
        public class SubReviewInReviewConfigurations : IEntityTypeConfiguration<SubReviewInReview>
        {
            public void Configure(EntityTypeBuilder<SubReviewInReview> builder)
            {
                builder.ToTable("SubReviewInReview");
                builder.HasKey(t => new { t.SRiR_ReviewId, t.SRiR_SubReviewId });
                builder.HasOne(t => t.Reviews).WithMany(ur => ur.SubReviewInReview)
         .HasForeignKey(pc => pc.SRiR_ReviewId);
                builder.HasOne(t => t.SubReview).WithMany(ur => ur.SubReviewInReview)
         .HasForeignKey(pc => pc.SRiR_SubReviewId);
            
        }
    }
}
