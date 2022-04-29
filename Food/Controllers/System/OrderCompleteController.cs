using Food.Data;
using Food.StatisFile.Function;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Food.Controllers.System
{
    public class OrderCompleteController : Controller
    {

        private readonly ApplicationDbContext _context;


        public OrderCompleteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("/OrderComplete")]
        [HttpGet]
        public IActionResult Index()
        {
            //Count product in cart page
            string namePc = Environment.MachineName;
            bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userIdString = "";
            if (userId != null)
            {
                userIdString = userId.ToString();
            }
            ViewBag.CountProductInCart = CheckCart.CheckProudctCart(_context, namePc, checkLogin, userIdString);



            return View();
        }
    }
}
