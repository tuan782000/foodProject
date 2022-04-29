using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Food.Data;
using Food.Entity;
using Food.Models;
using Food.StatisFile.Function;

namespace Food.Controllers
{
    public class ProductDetailController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly SignInManager<AppUser> _SignInManager;
        private readonly UserManager<AppUser> _UserManager;

        public ProductDetailController(ApplicationDbContext context, UserManager<AppUser> UserManager, SignInManager<AppUser> SignInManager)
        {
            _context = context;
            _UserManager = UserManager;
            _SignInManager = SignInManager;
        }




        [Route("/productdetail")]
        [HttpGet("{id}")]
        public IActionResult Index(string id)
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
            //Mess
            ViewBag.Mess = "";
            //Query product

            var productDetailQuery = _context.Products.FirstOrDefault(a => a.pd_Id == id);


            ViewBag.Id = productDetailQuery.pd_Id;
            ViewBag.Img1 = productDetailQuery.pd_Img1;
            ViewBag.Img2 = productDetailQuery.pd_Img2;
            ViewBag.Img3 = productDetailQuery.pd_Img3;
            ViewBag.Img4 = productDetailQuery.pd_Img4;
            ViewBag.NameProduct = productDetailQuery.pd_Name;
            ViewBag.Price = productDetailQuery.pd_Price;
            ViewBag.Rate = productDetailQuery.pd_Rate;
            ViewBag.ShortDescription = productDetailQuery.pd_ShortDescription;
            ViewBag.Description = productDetailQuery.pd_Description;



            var review = from a in _context.AppUser
                         join b in _context.Reviews on a.Id equals b.review_UserId
                         join c in _context.ReviewInproduct on b.review_id equals c.rip_ReviewId
                         join d in _context.Products on c.rip_ProductId equals d.pd_Id
                         select new { a, b, c, d };



            review = review.Where(x => x.d.pd_Id == id && x.b.review_HideStatus == false).OrderBy(x => x.b.review_UploadTime); ;

            var reviewQuery = review.Select(x => new ReviewModel()
            {
                // table Review
                review_id = x.b.review_id,
                review_UserId = x.a.Id,
                review_ProductId = x.d.pd_Id,
                review_Comment = x.b.review_Comment,
                review_UserName = x.a.UserName,
                review_UploadTime = x.b.review_UploadTime,

                review_CountSubReview = 1
                //// table SubReview
                //Subreview = 

                
            });



            var queryProduct = _context.Products;

            ViewBag.ProductList = queryProduct;




            return View(reviewQuery);
        }

        [Route("/AddToCart")]
        [HttpPost]
        public async Task<IActionResult> AddToCart()
        {

            try
            {
                
                string namePc = Environment.MachineName;
                bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userName = User.FindFirstValue(ClaimTypes.Name);

                var productid = Request.Form["productid"];
                var quantity = Request.Form["quantityProuct"];

                int quantityProduct = Int16.Parse(quantity);
                string cartId = Guid.NewGuid().ToString();

                

                if (checkLogin)
                {
                    // Logined
                    // Query cart
                    var queryCart = _context.Cart.FirstOrDefault(a => a.cart_UserID == userId.ToString());

                    if (queryCart == null)
                    {
                        //Create cart 
                        var cartCreate = new Cart()
                        {
                            cart_Id = cartId,
                            cart_UserID = userId
                        };
                        _context.Cart.Add(cartCreate);
                    }
                    else
                    {
                        cartId = queryCart.cart_Id;
                    }
                    
                     //Create ProductInCart
                    var ProductInCartCreate = new ProductInCart()
                    {
                        pic_CartId = cartId,
                        pic_ProductId = productid.ToString(),
                        pic_amount = quantityProduct,
                    };
                    _context.ProductInCart.Add(ProductInCartCreate);


                    await _context.SaveChangesAsync();
                }else
                {
                    /// No logined
                    /// Create Device in DB
                    var deviceQuery = _context.Devices.FirstOrDefault(a => a.deviceName == namePc);

                    if (deviceQuery == null)
                    {
                        string DeviceId = Guid.NewGuid().ToString();
                        var AddDevice = new Device()
                        {
                            deviceId = DeviceId,
                            deviceName = namePc
                        };
                        _context.Devices.Add(AddDevice);
                        await _context.SaveChangesAsync();
                    }
                    /// Create Device in DB
                    var deviceQueryre = _context.Devices.FirstOrDefault(a => a.deviceName == namePc);

                    //Create cart
                    var CartsDevice = new CartsDevice()
                    {
                        cartd_Id = cartId,
                        cartd_DeviceId = deviceQueryre.deviceId
                    };

                    _context.CartsDevice.Add(CartsDevice);
                    var ProductInCartDevices = new ProductInCartDevices()
                    {
                        picd_CartId = cartId,
                        picd_ProductId = productid.ToString(),
                        picd_amount = quantityProduct
                    };

                    _context.ProductInCartDevices.Add(ProductInCartDevices);
                    await _context.SaveChangesAsync();
                }
                return Redirect("/cart");
            }
            catch
            {
                return View();
            }

        }

        [Route("/productcomment")]
        [HttpPost]
        public async Task<IActionResult> Comment()
        {
            try
            {
                ViewBag.Mess = "";
                string idproduct = Request.Form["idproduct"];
                bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();
                if(checkLogin)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var userName = User.FindFirstValue(ClaimTypes.Name);
                    string reviewId = Guid.NewGuid().ToString();

                    
                    if (Request.Form["comment"] != "")
                    {
                        var reviews = new Reviews()
                        {
                            review_id = reviewId,
                            review_Comment = Request.Form["comment"],
                            review_UserId = userId,
                            review_UploadTime = DateTime.Now,
                            review_HideStatus = false,
                            review_ReviewType = "Review"
                        };

                        _context.Reviews.Add(reviews);
                        var reviewInProduct = new ReviewInproduct()
                        {
                            rip_ProductId = idproduct,
                            rip_ReviewId = reviewId
                        };
                        _context.ReviewInproduct.Add(reviewInProduct);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    ViewBag.Mess = "Need to login"; 
                }
                return Redirect("/productdetail?id=" + idproduct);
            }
            catch
            {
                ViewBag.thongbao = "Cann't create";
                return View();
            }

        }

        //[Route("/productcommentreply")]
        //[HttpPost]
        //public async Task<IActionResult> Commentreply()
        //{

        //    try
        //    {

        //        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        var userName = User.FindFirstValue(ClaimTypes.Name);
        //        string SubReviewId = Guid.NewGuid().ToString();

        //        string idproduct = Request.Form["idproduct"];
        //        if (Request.Form["subcomment"] != "")
        //        {
        //            var SubReviews = new SubReview()
        //            {
        //                subReview_Id = SubReviewId,
        //                subReview_Commnet = Request.Form["subcomment"],
        //                subReview_DateCommnet = DateTime.Now,
        //                subReview_UserId = userId,
        //                subReview_HideStatus = false,
        //                subreview_SubReviewType = "SubReview"
        //            };

        //            string idCommentMain = Request.Form["idcommentmain"];
        //            int idProductInt = Int32.Parse(idproduct);
        //            _context.SubReview.Add(SubReviews);

        //            var SubReviewInReview = new SubReviewInReview()
        //            {
        //                SRiR_ReviewId = idCommentMain,
        //                SRiR_SubReviewId = SubReviewId
        //            };

        //            _context.SubReviewInReview.Add(SubReviewInReview);
        //            await _context.SaveChangesAsync();
        //        }
        //        return Redirect("/productdetail?id=" + idproduct);
        //    }
        //    catch
        //    {
        //        ViewBag.thongbao = "Cann't create";
        //        return View();
        //    }

        //}


    }
}
