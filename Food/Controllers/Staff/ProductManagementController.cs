using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Data;
using Food.Entity;
using Food.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Food.Service;

namespace Food.Controllers.Staff
{
    [Authorize(Roles = "Admin,Staff")]
    public class ProductManagementController : Controller
    {
        private readonly ApplicationDbContext _context;


        public ProductManagementController(ApplicationDbContext context)
        {
            _context = context;
        }
        //

        [Route("/productmanagement")]
        [HttpGet]
        //public ActionResult Index()
        //{
        //    try
        //    {
        //        //Query Product
        //        var productListTest1 = from a in _context.Products select a;

        //        //Contidition
        //        productListTest1 = productListTest1.Where(a => a.isDelete == false);
        //        return View(productListTest1);
        //    }
        //    catch
        //    {
        //        ViewBag.thongbao = "Cann't create";
        //        return View();
        //    }

        //}
        public ActionResult Index(int? pageNumber)
        {
            try
            {
                //Query Product
                var productListTest1 = from a in _context.Products select a;

                //Contidition
                productListTest1 = productListTest1.Where(a => a.isDelete == false);
                int pageSize = 5;
                return View(PaginatedList<Products>.Create(productListTest1.AsNoTracking(), pageNumber ?? 1, pageSize));
            }
            catch
            {
                ViewBag.thongbao = "Cann't create";
                return View();
            }
        }


        // GET: ProductManagementController/Details/5
        [HttpGet("/productmanagement/details/{id:guid?}/")]
        public ActionResult Details(string id)
        {
            var productQuery = _context.Products.FirstOrDefault(x => x.pd_Id == id);
            return View(productQuery);
        }

        [Route("productmanagement/Create")]
        // GET: ProductManagementController/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.thongbao = "";


            //Query Categories 
            var categoriesQuery = _context.Categories;

            List<SelectListItem> CategoriesList = new List<SelectListItem>();
            foreach (var category in categoriesQuery)
            {
                var itemCategory = new SelectListItem { Value = category.cg_Id, Text = category.cg_Name };
                CategoriesList.Add(itemCategory);
            }
            ViewBag.CategoriesList = CategoriesList;

            return View();
        }

        // POST: ProductManagementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Create(ProductModel productModel)
        {
            try
            {
                //Create product
                var productId = Guid.NewGuid().ToString();
                var product1 = new Products()
                {
                    pd_Id = productId,
                    pd_Name = productModel.pd_Name,
                    pd_Description = productModel.pd_Description,
                    pd_Price = productModel.pd_Price,
                    pd_ReducePrice = productModel.pd_ReducePrice,
                    pd_Img1 = productModel.pd_Img1,
                    pd_Img2 = productModel.pd_Img2,
                    pd_Img3 = productModel.pd_Img3,
                    pd_Img4 = productModel.pd_Img4,
                    pd_Rate = productModel.pd_Rate,
                    pd_ShortDescription = productModel.pd_ShortDescription
                };
                _context.Products.Add(product1);

                //Create Product In Categories
                string CategoriesSelect = Request.Form["CategoriesSelect"];
                var CategoriesIdQuery = _context.Categories.FirstOrDefault(a => a.cg_Id == CategoriesSelect);

                var productInCategories = new ProductsInCategories()
                {
                    pic_productId = productId,
                    pic_CategoriesId = CategoriesSelect,
                };

                _context.ProductsInCategories.Add(productInCategories);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.thongbao = "Cann't create";
                return View();
            }
        }

        [HttpGet("/productmanagement/edit/{id:guid?}/")]
        // GET: ProductManagementController/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                var productQuery = _context.Products.FirstOrDefault(x => x.pd_Id == id);
                return View(productQuery);
            }
            catch (Exception)
            {

                ViewBag.thongbao = "Cann't edit";
                return View();
            }
            
        }

        // POST: ProductManagementController/Edit/5
        [HttpPost("/productmanagement/edit/{id:guid?}/")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, ProductModel productModel)
        {
            try
            {

                var productQuery = _context.Products.FirstOrDefault(x => x.pd_Id == id);

                productQuery.pd_Name = productModel.pd_Name;
                productQuery.pd_Description = productModel.pd_Description;
                productQuery.pd_Price = productModel.pd_Price;
                productQuery.pd_ReducePrice = productModel.pd_ReducePrice;
                productQuery.pd_Img1 = productModel.pd_Img1;
                productQuery.pd_Img2 = productModel.pd_Img2;
                productQuery.pd_Img3 = productModel.pd_Img3;
                productQuery.pd_Img4 = productModel.pd_Img4;
                productQuery.pd_Rate = productModel.pd_Rate;
                productQuery.pd_ShortDescription = productModel.pd_ShortDescription;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }







        // GET: ProductManagementController/Delete/5
        [HttpGet("/productmanagement/delete/{id:guid?}/")]
        public ActionResult Delete(string id)
        {
            var productQuery = _context.Products.FirstOrDefault(x => x.pd_Id == id);

            return View(productQuery);
        }

        // POST: ProductManagementController/Delete/5
        [HttpPost("/productmanagement/delete/{id:guid?}/")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                //Delete in Product Table
                var productQuery = _context.Products.FirstOrDefault(x => x.pd_Id == id);
                _context.Products.Remove(productQuery);

                //Delete in ProductsInCategories Table
                var productsInCategoriesQuery = _context.ProductsInCategories.FirstOrDefault(x => x.pic_productId == id);
                _context.ProductsInCategories.Remove(productsInCategoriesQuery);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: RoleManagementController/Delete/5
        [HttpGet("/productmanagement/hidden/{id:guid}")]
        public ActionResult Hidden(string id, Products products)
        {
            try
            {


                var productQuery = _context.Products.FirstOrDefault(a => a.pd_Id == id);
                productQuery.isDelete = true;

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
