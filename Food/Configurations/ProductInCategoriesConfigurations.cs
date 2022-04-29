using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.Configurations
{
    public class ProductInCategoriesConfigurations : IEntityTypeConfiguration<ProductsInCategories>
    {
        public void Configure(EntityTypeBuilder<ProductsInCategories> builder)
        {
            builder.ToTable("ProductsInCategories");
            builder.HasKey(t => new { t.pic_productId,t.pic_CategoriesId });
            builder.HasOne(t => t.ProductsPIC).WithMany(ur => ur.ProductsInCategoriesP)
     .HasForeignKey(pc => pc.pic_productId);
            builder.HasOne(t => t.CategoriesPIC).WithMany(ur => ur.ProductsInCategoriesC)
     .HasForeignKey(pc => pc.pic_CategoriesId);
        }
    }
}
