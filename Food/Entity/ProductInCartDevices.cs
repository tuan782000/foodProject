using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Entity
{
    public class ProductInCartDevices
    {
        public CartsDevice CartsDevicePICD { get; set; }
        public string picd_CartId { get; set; }
        public Products ProductsPICD { get; set; }

        public string picd_ProductId { get; set; }

        public int picd_amount { get; set; }

        public string picd_size { get; set; }

        public string picd_color { get; set; }

    }
}
