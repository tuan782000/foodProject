using Food.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Food.Models;

namespace Food.Controllers.System
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SearchController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SearchController/Details/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchModel searchModel)
        {

            return Redirect("/food?searchName="+ searchModel.searchName);
        }

    }
}
