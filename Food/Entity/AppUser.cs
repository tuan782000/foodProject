﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Food.Entity
{
    public class AppUser :IdentityUser
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime DoB { set; get; }


        public string bill_Country { set; get; }
        public string bill_CompanyName { set; get; }
        public string bill_City { set; get; }
        public string bill_State { set; get; }
        public string bill_PostalCode { set; get; }
        public string bill_PhoneNumber { set; get; }
        public string bill_Address1 { set; get; }
        public string bill_Address2 { set; get; }
        public List<SubReview> SubReviewSR { get; set; }

        public List<Bills> BillsAU { get; set; }
        public List<Reviews> ReviewsU { get; set; }
        public List<Cart> CartU { get; set; }





    }
}
