using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Models
{
    public class CheckOutModel
    {
        public string Id { get; set; }
        public string checkout_ProductName { get; set; }
        public int checkout_Quantity { get; set; }
        public int checkout_Price { get; set; }

    }
}
