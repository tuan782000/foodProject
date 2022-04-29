using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Data;
using Food.Entity;
using Microsoft.AspNetCore.Authorization;

namespace Food.Controllers.Admin
{
    //Authorize
    [Authorize(Roles = "Admin")]
    public class RoleManagementController : Controller
    {

        private readonly ApplicationDbContext _context;
        public RoleManagementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RoleManagementController
        [Route("/rolemanagement")]
        [HttpGet]
        public ActionResult Index()
        {
            //Query Role
            var roleQuery = from a in _context.AppRole select a;
            //Contiditoin for role 
            roleQuery = roleQuery.Where(a => a.isDelete == false);
            return View(roleQuery);
        }


       // GET: RoleManagementController/Details/5
       [Route("/rolemanagement/details/{id:guid?}")]
        [HttpGet]
        public ActionResult Details(string id)
        {
            //Query Role
            var roleQuery = _context.AppRole.FirstOrDefault(a => a.Id == id);
            return View(roleQuery);
        }

        // GET: RoleManagementController/Create
        [Route("/rolemanagement/create")]
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        // POST: RoleManagementController/Create
        [HttpPost("/rolemanagement/create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AppRole appRole)
        {
            try
            {
                //Create Data
                appRole = new AppRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Description = appRole.Description,
                    Name = appRole.Name,
                    NormalizedName = appRole.Name.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()

                };

                // Insert Data
                _context.AppRole.Add(appRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleManagementController/Edit/5
        [Route("/rolemanagement/edit/{id:guid}")]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var roleQuery = _context.AppRole.FirstOrDefault(x => x.Id == id);

            return View(roleQuery);
        }

        // POST: RoleManagementController/Edit/5
        [HttpPost("/rolemanagement/edit/{id:guid}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, AppRole appRole)
        {
            try
            {

                var roleQuery = _context.AppRole.FirstOrDefault(a => a.Id == id);
                roleQuery.Description = appRole.Description;
                roleQuery.Name = appRole.Name;
                roleQuery.NormalizedName = appRole.NormalizedName;

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleManagementController/Delete/5
        [Route("/rolemanagement/delete/{id:guid}")]
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var roleQuery = _context.AppRole.FirstOrDefault(a => a.Id == id);
            return View(roleQuery);
        }

        // POST: RoleManagementController/Delete/5
        [HttpPost("/rolemanagement/delete/{id:guid}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                

                var roleQuery = _context.AppRole.FirstOrDefault(a => a.Id == id);
                _context.AppRole.Remove(roleQuery);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: RoleManagementController/Delete/5
        [HttpGet("/rolemanagement/hidden/{id:guid}")]
        public ActionResult Hidden(string id, AppRole appRole)
        {
            try
            {


                var roleQuery = _context.AppRole.FirstOrDefault(a => a.Id == id);
                roleQuery.isDelete = true;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        

    }
}
