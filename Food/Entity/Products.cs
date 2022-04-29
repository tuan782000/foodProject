using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Entity
{
    public class Products
    {

        [DisplayName("Id")]
        public string pd_Id { set; get; }


        [DisplayName("Name Product")]
        public string pd_Name { set; get; }


        [DisplayName("Description")]
        public string pd_Description { set; get; }


        [DisplayName("Price")]
        public int pd_Price { set; get; }



        [DisplayName("ReducePrice")]
        public int pd_ReducePrice { set; get; }

        public string pd_NameImg1 { set; get; }
        public string pd_NameImg2 { set; get; }
        public string pd_NameImg3 { set; get; }
        public string pd_NameImg4 { set; get; }
        public string pd_Img1 { set; get; }
        public string pd_Img2 { set; get; }

        public string pd_Img3 { set; get; }
        public string pd_Img4 { set; get; }



        [DisplayName("Rate")]
        public int pd_Rate { set; get; }


        public string pd_ShortDescription { set; get; }


        public bool pd_WaitForConfirmation { set; get; }

        public bool isDelete { set; get; }

        public List<ProductsInCategories> ProductsInCategoriesP { get; set; }
        public List<ProductInCart> ProductInCartP { get; set; }
        public List<ReviewInproduct> ReviewInproductP { get; set; }

        public List<ProductInCartDevices> ProductInCartDevicesP { get; set; }

    }
}
