using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Entity
{
    public class ProductInCart
    {
        public Products ProductsPICart { get; set; }

        public string pic_CartId { get; set; }
        public Cart CartPICart { get; set; }
        public string pic_ProductId { get; set; }

        public int pic_amount { get; set; }

        public string pic_size { get; set; }

        public string pic_color { get; set; }

    }
}
