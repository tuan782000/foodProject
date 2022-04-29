using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Entity
{
    public class ProductsInCategories
    {
        public Categories CategoriesPIC { get; set; }
        public string pic_CategoriesId { get; set; }
        public Products ProductsPIC { get; set; }
        public string pic_productId { get; set; }
    }
}
