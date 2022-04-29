using Food.Data;
using Food.Entity;
using Food.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Food.Controllers.Staff
{
    public class CouponManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CouponManagementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CouponManagementController
        [Route("/couponmanagement")]
        public ActionResult Index(int? pageNumber)
        {
            var query = _context.Coupons;
            int pageSize = 5;
            return View(PaginatedList<Coupons>.Create(query.AsNoTracking(), pageNumber ?? 1, pageSize) );
        }

        // GET: CouponManagementController/Details/5
        [Route("/couponmanagement/details")]
        [HttpGet]
        public ActionResult Details(string id)
        {
            var query = _context.Coupons.Find(id);
            return View(query);
        }

        // GET: CouponManagementController/Create
        [Route("/couponmanagement/create")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CouponManagementController/Create
        [Route("/couponmanagement/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Coupons coupons)
        {
            try
            {
                var CouponCreate = new Coupons()
                {
                    couponId = Guid.NewGuid().ToString(),
                    couponCode = coupons.couponCode,
                    couponPrice = coupons.couponPrice
                };

                _context.Coupons.Add(CouponCreate);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouponManagementController/Edit/5
        [Route("/couponmanagement/edit")]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var query = _context.Coupons.Find(id);
            return View(query);
        }

        // POST: CouponManagementController/Edit/5
        [Route("/couponmanagement/edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Coupons coupons)
        {
            try
            {
                var query = _context.Coupons.Find(coupons.couponId);
                query.couponCode = coupons.couponCode;
                query.couponPrice = coupons.couponPrice;

                _context.Coupons.Update(query);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouponManagementController/Delete/5
        [Route("/couponmanagement/delete")]
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var query = _context.Coupons.Find(id);
            return View(query);
        }

        // POST: CouponManagementController/Delete/5
        [Route("/couponmanagement/delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Coupons coupons)
        {
            try
            {
                var query = _context.Coupons.Find(coupons.couponId);

                _context.Coupons.Remove(query);
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
