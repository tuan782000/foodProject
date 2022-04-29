using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Food.Data;
using Food.Entity;
using Food.Models;
using Microsoft.AspNetCore.Http;
using Food.StatisFile;
using Food.StatisFile.Function;

namespace Food.Controllers.System
{
    public class CartController : Controller
    {


        private readonly ApplicationDbContext _context;

        private readonly SignInManager<AppUser> _SignInManager;
        private readonly UserManager<AppUser> _UserManager;

        public CartController(ApplicationDbContext context, UserManager<AppUser> UserManager, SignInManager<AppUser> SignInManager)
        {
            _context = context;
            _UserManager = UserManager;
            _SignInManager = SignInManager;
        }

        
        [Route("/cart")]
        [HttpGet]
        public IActionResult Index()
        {
            string namePc = Environment.MachineName;
            bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userIdString = "";
            if (userId != null)
            {
                userIdString = userId.ToString();
            }
            ViewBag.CountProductInCart = CheckCart.CheckProudctCart(_context, namePc, checkLogin, userIdString);

            
            if (checkLogin)
            {
                //login
                var query = from a in _context.Products
                            join b in _context.ProductInCart on a.pd_Id equals b.pic_ProductId
                            join c in _context.Cart on b.pic_CartId equals c.cart_Id
                            join d in _context.AppUser on c.cart_UserID equals d.Id
                            select new { a, b, c, d };

                query = query.Where(x => x.d.Id == userId);

                var productInCartModelQuery = query
                    .Select(x => new ProductInCartModel()
                    {
                        ProductId = x.a.pd_Id,
                        ProductName = x.a.pd_Name,
                        ProductPrice = x.a.pd_Price,
                        ProductImg1 = x.a.pd_Img1,
                        Quantity = x.b.pic_amount,
                        UserId = x.d.Id

                    });

                // Calculate Ship, Subtotal, Total, Discount
                // Discount

                int discount = GetDiscount();

                // Ship
                int ship = GetShippingPrice(productInCartModelQuery.Count(), "ship");
                if (productInCartModelQuery.Count() == 0)
                {
                    ship = 0;
                }

                // SubTotal
                int reTotal = 0;
                foreach (var item in productInCartModelQuery)
                {
                    reTotal += item.Quantity * item.ProductPrice;
                }

                ViewBag.Subtotal = 0;
                if (reTotal != 0)
                {
                    ViewBag.Subtotal = reTotal;
                }

                // Total
                CaculateTotal(reTotal, ship, discount);

                return View(productInCartModelQuery);
            }
            else
            {
                //No login
                //Count product in cart page
                //Query produdct in Cart
                var query = from a in _context.Products
                            join b in _context.ProductInCartDevices on a.pd_Id equals b.picd_ProductId
                            join c in _context.CartsDevice on b.picd_CartId equals c.cartd_Id
                            join d in _context.Devices on c.cartd_DeviceId equals d.deviceId
                            select new { a, b, c, d };
                query = query.Where(x => x.d.deviceName == namePc);

                var productInCartModelQuery = query
                    .Select(x => new ProductInCartModel()
                    {
                        ProductId = x.a.pd_Id,
                        ProductName = x.a.pd_Name,
                        ProductPrice = x.a.pd_Price,
                        ProductImg1 = x.a.pd_Img1,
                        Quantity = x.b.picd_amount,
                        UserId = x.d.deviceId
                    });

                // Calculate Ship, Subtotal, Total, Discount
                // Discount

                int discount = GetDiscount();

                // Ship
                int ship = GetShippingPrice(productInCartModelQuery.Count(), "ship");
                

                // SubTotal
                int reTotal = 0;
                foreach (var item in productInCartModelQuery)
                {
                    reTotal += item.Quantity * item.ProductPrice;
                }

                ViewBag.Subtotal = 0;
                if (reTotal != 0)
                {
                    ViewBag.Subtotal = reTotal;
                }

                // Total
                CaculateTotal(reTotal, ship, discount);

                return View(productInCartModelQuery);
            }
        }

        private int GetShippingPrice(int countProduct,string NameShip)
        {
            var shipingQuery = _context.Shipping.FirstOrDefault(a => a.ship_Name == NameShip);
            int ship;
            if (countProduct == 0)
            {

                ship = 0;
                ViewBag.Ship = 0;
            }
            else
            {
                if (shipingQuery != null)
                {
                    ship = shipingQuery.ship_Price;
                    ViewBag.Ship = shipingQuery.ship_Price;
                }
                else
                {
                    ship = 0;
                    ViewBag.Ship = 0;
                }
            }
            
            return ship;
        }
        
        private int CaculateTotal(int reTotal, int ship, int discount)
        {
            int total = reTotal + ship - discount;
            if (total <0)
            {
                total = 0;
            }
            ViewBag.total = total;
            return reTotal + ship - discount;
        }

        private int GetDiscount()
        {
            int discount = 0;
            if ((HttpContext.Session.GetString(KeySession.sessionCouponPrice) == null) || (HttpContext.Session.GetString(KeySession.sessionCouponPrice) == ""))
            {
                ViewBag.CouponPrice = 0;
            }
            else
            {
                discount = Int32.Parse(HttpContext.Session.GetString(KeySession.sessionCouponPrice));
                ViewBag.CouponPrice = HttpContext.Session.GetString(KeySession.sessionCouponPrice);
            }
            return discount;
        }

        [Route("/cart/remove")]
        [HttpGet("id")]
        public IActionResult RemoveProduct(string id)
        {
            try
            {
                bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();

                if (checkLogin)
                {
                    //Logined
                    var productQuery = _context.ProductInCart.FirstOrDefault(a => a.pic_ProductId == id);
                    _context.ProductInCart.Remove(productQuery);
                    _context.SaveChanges();
                }
                else
                {
                    // No login
                    // Query product in cart device and remove 
                    var productQuery = _context.ProductInCartDevices.FirstOrDefault(a => a.picd_ProductId == id);
                    _context.ProductInCartDevices.Remove(productQuery);
                    _context.SaveChanges();
                }
                    

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }

        }


        [Route("/cart/addCoupon")]
        [HttpGet("{coupon}&{quantity}")]
        public IActionResult addCoupon(string coupon, int quantity)
        {

            try
            {
                var couponQuery = _context.Coupons.FirstOrDefault(a => a.couponCode == coupon);

                // Set Coupon price in session
                if (couponQuery != null)
                {
                    HttpContext.Session.SetString(KeySession.sessionCouponPrice, couponQuery.couponPrice.ToString());
                }
                else
                {
                    HttpContext.Session.SetString(KeySession.sessionCouponPrice, "0");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }

        }
    }
}
