using Food.Data;
using Food.StatisFile.Function;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace Food.Controllers.System
{
    public class PaymentCompleteController : Controller
    {
        private readonly ApplicationDbContext _context;


        public PaymentCompleteController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: PaymentCompleteController
        [Route("/paymentcomplete")]
        public ActionResult Index()
        {
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
