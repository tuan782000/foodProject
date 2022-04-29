using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Data;
using Food.Models;
using Microsoft.AspNetCore.Authorization;
using Food.Service;
using Microsoft.EntityFrameworkCore;

namespace Food.Controllers.Staff
{
    [Authorize(Roles = "Admin,Staff")]
    public class OrderConfirmationManagementController : Controller
    {
        private readonly ApplicationDbContext _context;

        private string sortName;
        private string SearchName;


        public OrderConfirmationManagementController(ApplicationDbContext context)
        {
            _context = context;
            sortName = "";
            SearchName = "";
        }


        [Route("/orderconfirmationmanagement")]
        [HttpGet]
        // GET: OrderConfirmationManagementController
        public ActionResult Index(int? pageNumber)
        {

            // Connect Table AppUser and Bills
            var UserAndBill = from a in _context.AppUser
                              join b in _context.Bills on a.Id equals b.bill_UserId
                              select new{a, b};

           
            switch (sortName)
            {
                case "":
                    // code block

                    // Search 
                    if (SearchName != "")
                    {
                        UserAndBill = UserAndBill.Where(x => x.b.bill_HideStatus == false
                        && x.a.UserName == SearchName
                        || x.a.LastName == SearchName
                        || x.a.FirstName == SearchName
                        || x.b.bill_Id == SearchName);
                    }
                    else
                    {
                        UserAndBill = UserAndBill.Where(x => x.b.bill_HideStatus == false);
                    }
                    break;
                case "Confirm":
                    // code block
                    break;
                case "Confirmed":
                    // code block
                    break;
                case "Hid":
                    // code block
                    break;
                case "Not hide":
                    // code block
                    break;
                default:
                    // code block
                    break;
            }



            var UserAndBillQuery = UserAndBill.Select(x => new OrderConfirmationModel()
            {
                OrderC_UserId = x.a.Id,
                OrderC_UserName = x.a.UserName,
                OrderC_FirstName = x.a.FirstName,
                OrderC_LastName = x.a.LastName,
                OrderC_Email = x.a.Email,
                OrderC_Address = x.a.bill_Address1,
                OrderC_PhoneNumber = x.a.PhoneNumber,
                OrderC_Confirm = x.b.bill_Confirmation,
                OrderC_BillId = x.b.bill_Id,
                OrderC_DatetimeOrder = x.b.bill_DatetimeOrder,
                OrderC_Discount = x.b.bill_Discount,
                OrderC_PaymentMethod = x.b.bill_PaymentMethod,
                OrderC_Shiping = x.b.bill_Shipping,
                OrderC_TotalPrice = x.b.bill_PaidTotal
            });



            // thieu OrderId

            int pageSize = 5;
            return View(PaginatedList<OrderConfirmationModel>.Create(UserAndBillQuery.AsNoTracking(), pageNumber ?? 1, pageSize));
        }



        string[] ProductIdArr;
        string[] ProductNameArr;
        string[] ProductPriceArr;
        string[] ProductQuantityArr;



        [Route("/orderdetail")]
        [HttpGet]
        // GET: OrderConfirmationManagementController/Details/5
        public ActionResult Details(string id)
        {

            // Connect Table AppUser and Bills
            var UserAndBill = from a in _context.AppUser
                              join b in _context.Bills on a.Id equals b.bill_UserId
                              select new { a, b };


            UserAndBill = UserAndBill.Where(x => x.b.bill_Id == id);

            foreach (var item in UserAndBill)
            {
                string ProductIdN = item.b.bill_ProductIdlist;
                ProductIdArr = ProductIdN.Split('|');
               

                string ProductNameN = item.b.bill_ProductNamelist;
                ProductNameArr = ProductNameN.Split('|');


                string ProductPriceN = item.b.bill_ProductPricelist;
                ProductPriceArr = ProductPriceN.Split('|');


                string ProductQuantityN = item.b.bill_Quantity;
                ProductQuantityArr = ProductQuantityN.Split('|');

            }


            var UserAndBillQuery = UserAndBill.Select(x => new OrderConfirmationModel()
            {
                OrderC_UserId = x.a.Id,
                OrderC_UserName = x.a.UserName,
                OrderC_FirstName = x.a.FirstName,
                OrderC_LastName = x.a.LastName,
                OrderC_Email = x.a.Email,
                OrderC_Address = x.a.bill_Address1,
                OrderC_PhoneNumber = x.a.PhoneNumber,
                OrderC_Confirm = x.b.bill_Confirmation,
                OrderC_BillId = x.b.bill_Id,
                OrderC_DatetimeOrder = x.b.bill_DatetimeOrder,
                OrderC_Discount = x.b.bill_Discount,
                OrderC_PaymentMethod = x.b.bill_PaymentMethod,
                OrderC_Shiping = x.b.bill_Shipping,
                OrderC_TotalPrice = x.b.bill_PaidTotal,
                OrderC_ProductIdList = ProductIdArr.ToList(),
                OrderC_ProductNameList = ProductNameArr.ToList(),
                OrderC_PriceList = ProductPriceArr.ToList(),
                OrderC_ProductQuantityList = ProductQuantityArr.ToList()
            });

            //string search = Request.Form["search"];

            //var searchQuery = _context.Products.Where(a => a.pd_Name.Contains(search) || a.pd_Description.Contains(search) || a.pd_Price.ToString() == search);

            ViewBag.CountProduct = ProductIdArr.Length;

            return View(UserAndBillQuery);
        }


        [Route("/ordersearch")]
        [HttpGet("{search}")]
        // GET: OrderConfirmationManagementController/Search
        public ActionResult Search(string search)
        {

            SearchName = Request.Form["searchinput"];

            return RedirectToAction(nameof(Index));
        }




        [Route("/orderedit")]
        [HttpGet]
        // GET: OrderConfirmationManagementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderConfirmationManagementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Route("/ordereditconfirm")]
        [HttpGet]
        // GET: OrderConfirmationManagementController/EditConfirm/5
        public ActionResult EditConfirm(string id)
        {

            //convert from confirm to confirmed
            var BillQuery = _context.Bills.FirstOrDefault(x => x.bill_Id == id);
            BillQuery.bill_Confirmation = true;

            _context.SaveChanges();


            // Connect Table AppUser and Bills
            var UserAndBill = from a in _context.AppUser
                              join b in _context.Bills on a.Id equals b.bill_UserId
                              select new { a, b };


            UserAndBill = UserAndBill.Where(x => x.b.bill_Id == id);

            foreach (var item in UserAndBill)
            {
                string ProductIdN = item.b.bill_ProductIdlist;
                ProductIdArr = ProductIdN.Split('|');


                string ProductNameN = item.b.bill_ProductNamelist;
                ProductNameArr = ProductNameN.Split('|');



                string ProductPriceN = item.b.bill_ProductPricelist;
                ProductPriceArr = ProductPriceN.Split('|');


                string ProductQuantityN = item.b.bill_Quantity;
                ProductQuantityArr = ProductQuantityN.Split('|');

            }


            var UserAndBillQuery = UserAndBill.Select(x => new OrderConfirmationModel()
            {
                OrderC_UserId = x.a.Id,
                OrderC_UserName = x.a.UserName,
                OrderC_FirstName = x.a.FirstName,
                OrderC_LastName = x.a.LastName,
                OrderC_Email = x.a.Email,
                OrderC_Address = x.a.bill_Address1,
                OrderC_PhoneNumber = x.a.PhoneNumber,
                OrderC_Confirm = x.b.bill_Confirmation,
                OrderC_BillId = x.b.bill_Id,
                OrderC_DatetimeOrder = x.b.bill_DatetimeOrder,
                OrderC_Discount = x.b.bill_Discount,
                OrderC_PaymentMethod = x.b.bill_PaymentMethod,
                OrderC_Shiping = x.b.bill_Shipping,
                OrderC_TotalPrice = x.b.bill_PaidTotal,
                OrderC_ProductIdList = ProductIdArr.ToList(),
                OrderC_ProductNameList = ProductNameArr.ToList(),
                OrderC_PriceList = ProductPriceArr.ToList(),
                OrderC_ProductQuantityList = ProductQuantityArr.ToList()
            });

            //string search = Request.Form["search"];

            //var searchQuery = _context.Products.Where(a => a.pd_Name.Contains(search) || a.pd_Description.Contains(search) || a.pd_Price.ToString() == search);

            ViewBag.CountProduct = ProductIdArr.Length;

            return View(UserAndBillQuery);
        }

        // POST: OrderConfirmationManagementController/EditConfirm/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Route("/ordereditconfirmed")]
        [HttpGet]
        // GET: OrderConfirmationManagementController/EditConfirm/5
        public ActionResult EditConfirmed(string id)
        {
            //convert from confirmed to confirm
            var BillQuery = _context.Bills.FirstOrDefault(x => x.bill_Id == id);
            BillQuery.bill_Confirmation = false;

            _context.SaveChanges();


            // Connect Table AppUser and Bills
            var UserAndBill = from a in _context.AppUser
                              join b in _context.Bills on a.Id equals b.bill_UserId
                              select new { a, b };


            UserAndBill = UserAndBill.Where(x => x.b.bill_Id == id);

            foreach (var item in UserAndBill)
            {
                string ProductIdN = item.b.bill_ProductIdlist;
                ProductIdArr = ProductIdN.Split('|');


                string ProductNameN = item.b.bill_ProductNamelist;
                ProductNameArr = ProductNameN.Split('|');



                string ProductPriceN = item.b.bill_ProductPricelist;
                ProductPriceArr = ProductPriceN.Split('|');


                string ProductQuantityN = item.b.bill_Quantity;
                ProductQuantityArr = ProductQuantityN.Split('|');

            }


            var UserAndBillQuery = UserAndBill.Select(x => new OrderConfirmationModel()
            {
                OrderC_UserId = x.a.Id,
                OrderC_UserName = x.a.UserName,
                OrderC_FirstName = x.a.FirstName,
                OrderC_LastName = x.a.LastName,
                OrderC_Email = x.a.Email,
                OrderC_Address = x.a.bill_Address1,
                OrderC_PhoneNumber = x.a.PhoneNumber,
                OrderC_Confirm = x.b.bill_Confirmation,
                OrderC_BillId = x.b.bill_Id,
                OrderC_DatetimeOrder = x.b.bill_DatetimeOrder,
                OrderC_Discount = x.b.bill_Discount,
                OrderC_PaymentMethod = x.b.bill_PaymentMethod,
                OrderC_Shiping = x.b.bill_Shipping,
                OrderC_TotalPrice = x.b.bill_PaidTotal,
                OrderC_ProductIdList = ProductIdArr.ToList(),
                OrderC_ProductNameList = ProductNameArr.ToList(),
                OrderC_PriceList = ProductPriceArr.ToList(),
                OrderC_ProductQuantityList = ProductQuantityArr.ToList()
            });

            //string search = Request.Form["search"];

            //var searchQuery = _context.Products.Where(a => a.pd_Name.Contains(search) || a.pd_Description.Contains(search) || a.pd_Price.ToString() == search);

            ViewBag.CountProduct = ProductIdArr.Length;

            return View(UserAndBillQuery);
        }

        // POST: OrderConfirmationManagementController/EditConfirm/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirmed(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [Route("/orderdelete")]
        [HttpGet]
        // GET: OrderConfirmationManagementController/Delete/5
        public ActionResult Delete(string id)
        {
            //convert from confirmed to confirm
            var BillQuery = _context.Bills.FirstOrDefault(x => x.bill_Id == id);
            BillQuery.bill_HideStatus = true;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // POST: OrderConfirmationManagementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
