using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Data;
using Food.Models;
using System.Security.Claims;
using Food.StatisFile.Function;
using Food.Service;
using Microsoft.EntityFrameworkCore;

namespace Food.Controllers.System
{
    public class FoodController : Controller
    {

        private readonly ApplicationDbContext _context;

        public FoodController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Route("/food")]
        [HttpGet("{categoriesName,searchName}")]
        public IActionResult Index(string categoriesName,string searchName, string sortOrder, string currentFilter, int? pageNumber)
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

            //Food
            var query = from a in _context.Products
                        join b in _context.ProductsInCategories on a.pd_Id equals b.pic_productId
                        join c in _context.Categories on b.pic_CategoriesId equals c.cg_Id
                        select new { a, c };

            query = query.Where(a => a.a.isDelete == false);

            // Insert data into model For "Top Rated Products"
            var topRatedProductsModelQuery = query
                .Select(x => new ProductModel()
                {
                    pd_Id = x.a.pd_Id,
                    pd_Img1 = x.a.pd_Img1,
                    pd_Name = x.a.pd_Name,
                    pd_Price = x.a.pd_Price,
                    pd_categoryName = x.c.cg_Name,
                    pd_ReducePrice = x.a.pd_ReducePrice
                });

            ViewBag.topRatedProductsModelQuery = topRatedProductsModelQuery.ToList();

            //Search form
            if ((categoriesName == "")|| (categoriesName == null))
            {
                if ((searchName == "") || (searchName == null))
                {
                }
                else
                {
                    //search by product name
                     query = query.Where(a => a.a.pd_Name.Contains(searchName));
                }
            }
            else
            {
                //search by product categories
                query = query.Where(x => x.c.cg_Name == categoriesName);
            }

            //Query Categories Name 
            var queryCategories = _context.Categories.ToList();
            ViewBag.Categories = queryCategories;

            // Insert data into model
            var productModelQuery = query
                .Select(x => new ProductModel()
                {
                    pd_Id = x.a.pd_Id,
                    pd_Img1 = x.a.pd_Img1,
                    pd_Name = x.a.pd_Name,
                    pd_Price = x.a.pd_Price,
                    pd_categoryName = x.c.cg_Name,
                    pd_ReducePrice = x.a.pd_ReducePrice
                });

            int pageSize = 8; 
            return View(PaginatedList<ProductModel>.Create(productModelQuery.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


    }
}
