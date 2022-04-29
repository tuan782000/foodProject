using Food.Data;
using Food.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food.Controllers.Staff
{
    public class ContactSystemController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactSystemController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ContactSystemController
        [Route("/contactsystem")]
        public ActionResult Index()
        {
            var query = _context.ContactSystem;
            return View(query);
        }

        // GET: ContactSystemController/Details/5
        [Route("/contactsystem/details")]
        public ActionResult Details(string id)
        {
            var query = _context.ContactSystem.Find(id);
            return View(query);
        }

        // GET: ContactSystemController/Edit/5
        [Route("/contactsystem/edit")]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var query = _context.ContactSystem.Find(id);
            return View(query);
        }

        // POST: ContactSystemController/Edit/5
        [Route("/contactsystem/edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContactSystem contactSystem)
        {
            try
            {
                var query = _context.ContactSystem.Find(contactSystem.Contact_Id);
                query.Contact_Address = contactSystem.Contact_Address;
                query.Contact_Phone = contactSystem.Contact_Phone;
                query.Contact_Email = contactSystem.Contact_Email;
                query.Contact_Description = contactSystem.Contact_Description;

                _context.ContactSystem.Update(query);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
