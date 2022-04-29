using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Data;
using Food.Entity;
using Food.StatisFile.Function;
using System.Security.Claims;

namespace Food.Controllers.System
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;


        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("/contact")]
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

            //Print contact 
            var query = _context.ContactSystem;
            ViewBag.Contact = query;

            return View();
        }

        [Route("/contact/create")]
        [HttpPost]
        public IActionResult Create(ContactUsers contactUsers)
        {
            try
            {
                var contactCreate = new ContactUsers()
                {
                    cu_Subject = contactUsers.cu_Subject,
                    cu_Description = contactUsers.cu_Description,
                    cu_Email = contactUsers.cu_Email,
                    cu_FirstName = contactUsers.cu_FirstName,
                    cu_Id = Guid.NewGuid().ToString()
                };

                _context.ContactUsers.Add(contactCreate);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return RedirectToAction(nameof(Index));
            }
            

        }

    }
}
