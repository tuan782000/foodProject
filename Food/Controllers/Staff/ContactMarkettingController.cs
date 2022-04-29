using Food.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food.Controllers.Staff
{
    [Authorize(Roles = "Admin,Staff")]
    public class ContactMarkettingController : Controller
    {


        private readonly ApplicationDbContext _context;
        public ContactMarkettingController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Route("/contactmarketting")]
        // GET: ContactMarkettingController
        public ActionResult Index()
        {
            var queryEmail = _context.SubscribeEmail;
            return View(queryEmail);
        }



    }
}
