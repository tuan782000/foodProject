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
namespace Food.StatisFile.Function
{
    public static class CheckCart
    {
        internal static int CheckProudctCart(ApplicationDbContext _context,
            string namePC,
            bool checklogin,
            string userId = "")
        {


            int countProductInCart = 0;
            if (checklogin)
            {
                //Query produdct in Cart for logined
                var query = from a in _context.Products
                            join b in _context.ProductInCart on a.pd_Id equals b.pic_ProductId
                            join c in _context.Cart on b.pic_CartId equals c.cart_Id
                            join d in _context.AppUser on c.cart_UserID equals d.Id
                            select new { a, b, c, d };

                query = query.Where(x => x.d.Id == userId);
                countProductInCart = query.Count();
            }
            else
            {

                //Query produdct in Cart, that user don't login
                var query = from a in _context.Products
                            join b in _context.ProductInCartDevices on a.pd_Id equals b.picd_ProductId
                            join c in _context.CartsDevice on b.picd_CartId equals c.cartd_Id
                            join d in _context.Devices on c.cartd_DeviceId equals d.deviceId
                            select new { a, b, c, d };

                query = query.Where(x => x.d.deviceName == namePC);
                countProductInCart = query.Count();
            }



            return countProductInCart;
        }

 
    }
}
