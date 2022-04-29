using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Entity
{
    public class Cart
    {
        public string cart_Id { set; get; }
        public AppUser AppUserC { get; set; }
        public string cart_UserID { set; get; }
        public List<ProductInCart> ProductInCartC { get; set; }

    }
}
