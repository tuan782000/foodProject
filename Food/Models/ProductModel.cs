using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Food.Entity;

namespace Food.Models
{
    public class ProductModel
    {
        
        public string pd_Id { set; get; }
        public string pd_Name { set; get; }
        public string pd_Description { set; get; }
        public int pd_Price { set; get; }

        public int pd_ReducePrice { set; get; }
        public string pd_Img1 { set; get; }
        public string pd_Img2 { set; get; }

        public string pd_Img3 { set; get; }
        public string pd_Img4 { set; get; }
        public int pd_Rate { set; get; }

        public string pd_ShortDescription { set; get; }

        public string pd_categoryName { set; get; }





    }
}
