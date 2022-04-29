using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Food.Data;
using Food.Models;
using Microsoft.AspNetCore.Http;
using Food.StatisFile.Function;
using System.Security.Claims;

namespace Food.Controllers.System
{
    public class HomeController : Controller
    {
        // Database
        private readonly ApplicationDbContext _context;
        public HomeController( ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Count product in cart page
            string namePc = Environment.MachineName;
            bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userIdString ="";
            if(userId != null)
            {
                userIdString = userId.ToString();
            }
            ViewBag.CountProductInCart = CheckCart.CheckProudctCart(_context, namePc, checkLogin, userIdString);


            // Print list product in Home Page
            var HomeProductQuery = from a in _context.Products 
                                   join b in _context.ProductsInCategories on a.pd_Id equals b.pic_productId
                                   join c in _context.Categories on b.pic_CategoriesId equals c.cg_Id
                                   select new { a, b, c, };

            var homeQuery = HomeProductQuery.Select(x => new ProductModel()
            {
                pd_Id =  x.a.pd_Id,
                pd_Img1 = x.a.pd_Img1,
                pd_Price = x.a.pd_Price,
                pd_ReducePrice = x.a.pd_ReducePrice,
                pd_categoryName = x.c.cg_Name,
                pd_Name = x.a.pd_Name


            });
            return View(homeQuery);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
