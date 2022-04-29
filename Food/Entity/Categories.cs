using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Entity
{
    public class Categories
    {
        public string cg_Id { set; get; }
        public string cg_Name { set; get; }
        public string cg_Type { set; get; }
        public string cg_Sale { set; get; }
        public List<ProductsInCategories> ProductsInCategoriesC { get; set; }


    }
}
