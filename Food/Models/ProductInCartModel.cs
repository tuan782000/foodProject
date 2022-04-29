using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Models
{
    public class ProductInCartModel
    {
        public string ProductId { set; get; }

        public string ProductName { set; get; }

        public int ProductPrice { set; get; }
        public string ProductImg1 { set; get; }
        public int Quantity { set; get; }

        public string UserId { set; get; }

        public string Color { set; get; }

        public string Size { set; get; }


    }
}
