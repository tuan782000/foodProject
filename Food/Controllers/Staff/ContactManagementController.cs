using Food.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food.Controllers.Staff
{
    [Authorize(Roles = "Admin,Staff")]
    public class ContactManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactManagementController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ContactManagementController
        [Route("/contactmanagement")]
        [HttpGet]
        public ActionResult Index()
        {
            var query = _context.ContactUsers;
            return View(query);
        }


    }
}
