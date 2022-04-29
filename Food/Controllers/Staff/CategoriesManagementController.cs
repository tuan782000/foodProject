using Food.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food.Controllers.Staff
{
    [Authorize(Roles = "Admin,Staff")]
    public class CategoriesManagementController : Controller
    {
       
        private readonly ApplicationDbContext _context;
        public CategoriesManagementController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: CategoriesManagementController
        [Route("categoriesmanagement")]
        public ActionResult Index()
        {

            var query = _context.Categories;
            return View(query);
        }

    }
}
