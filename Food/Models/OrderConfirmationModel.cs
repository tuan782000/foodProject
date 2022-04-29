using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Models
{
    public class OrderConfirmationModel
    {

        public string OrderC_BillId { set; get; } // Id of Bill
        public string OrderC_UserId  { set; get; } // Id of User
        public string OrderC_FirstName { set; get; }
        public string OrderC_LastName { set; get; }
        public string OrderC_UserName { set; get; }
        public bool OrderC_Confirm { set; get; } // Status : Confirmed or not yet
        public string OrderC_Address { set; get; }
        public string OrderC_PhoneNumber { set; get; }
        public string OrderC_Email { set; get; }
        public string OrderC_PaymentMethod { set; get; }
        public DateTime OrderC_DatetimeOrder { set; get; }
        
        




        public List<string> OrderC_ProductIdList { set; get; }
        public List<string> OrderC_ProductNameList { set; get; }
        public List<string> OrderC_ProductQuantityList { set; get; }
        public List<string> OrderC_PriceList { set; get; }
        public List<string> OrderC_SizeList { set; get; }
        public List<string> OrderC_ColorList { set; get; }


        public int OrderC_Shiping { set; get; }
        public int OrderC_Discount { set; get; }
        public int OrderC_TotalPrice { set; get; }


    }
}
