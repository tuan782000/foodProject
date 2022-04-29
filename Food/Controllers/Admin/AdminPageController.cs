using Food.Data;
using Food.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Controllers.Admin
{
    //Authorize 
    [Authorize(Roles = "Admin,Staff,Manager")]
    public class AdminPageController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("admin")]
        public IActionResult Index()
        {
            //Create Chart 
            var queryBill = _context.Bills;
            ChartForBill chartForBill = new ChartForBill();

            chartForBill.PriceForJanuary = 0;
            chartForBill.PriceForFebruary = 0;
            chartForBill.PriceForMarch = 0;
            chartForBill.PriceForApril = 0;
            chartForBill.PriceForMay = 0;
            chartForBill.PriceForJune = 0;
            chartForBill.PriceForJuly = 0;
            chartForBill.PriceForAugust = 0;
            chartForBill.PriceForSeptember = 0;
            chartForBill.PriceForOctober = 0;
            chartForBill.PriceForNovember = 0;
            chartForBill.PriceForDecember = 0;


            // Pass data into feild
            foreach (var item in queryBill)
            {
                switch (item.bill_DatetimeOrder.Month)
                {
                    case 1:
                        // code block
                        chartForBill.PriceForJanuary += item.bill_PaidTotal;
                        break;
                    case 2:
                        // code block
                        chartForBill.PriceForFebruary += item.bill_PaidTotal;
                        break;
                    case 3:
                        // code block
                        chartForBill.PriceForMarch += item.bill_PaidTotal;
                        break;
                    case 4:
                        // code block
                        chartForBill.PriceForApril += item.bill_PaidTotal;
                        break;
                    case 5:
                        // code block
                        chartForBill.PriceForMay += item.bill_PaidTotal;
                        break;
                    case 6:
                        // code block
                        chartForBill.PriceForJune += item.bill_PaidTotal;
                        break;
                    case 7:
                        // code block
                        chartForBill.PriceForJuly += item.bill_PaidTotal;
                        break;
                    case 8:
                        // code block
                        chartForBill.PriceForAugust += item.bill_PaidTotal;
                        break;
                    case 9:
                        // code block
                        chartForBill.PriceForSeptember += item.bill_PaidTotal;
                        break;
                    case 10:
                        // code block
                        chartForBill.PriceForOctober += item.bill_PaidTotal;
                        break;
                    case 11:
                        // code block
                        chartForBill.PriceForNovember += item.bill_PaidTotal;
                        break;
                    case 12:
                        // code block
                        chartForBill.PriceForDecember += item.bill_PaidTotal;
                        break;
                    default:
                        // code block
                        break;
                }
            }

            //Send Data
            sendData(
                chartForBill.PriceForJanuary,
                chartForBill.PriceForFebruary,
                chartForBill.PriceForMarch,
                chartForBill.PriceForApril,
                chartForBill.PriceForMay,
                chartForBill.PriceForJune,
                chartForBill.PriceForJuly,
                chartForBill.PriceForAugust,
                chartForBill.PriceForSeptember,
                chartForBill.PriceForOctober,
                chartForBill.PriceForNovember,
                chartForBill.PriceForDecember
                );


            return View();
        }

        public void sendData(
            int January = 0,
            int February = 0,
            int March = 0,
            int April = 0,
            int May = 0,
            int June = 0,
            int July = 0,
            int August = 0,
            int September = 0,
            int October = 0,
            int November =0 ,
            int December =0
            )
        {
            ViewBag.January = January;
            ViewBag.February = February;
            ViewBag.March = March;
            ViewBag.April = April;
            ViewBag.May = May;
            ViewBag.June = June;
            ViewBag.July = July;
            ViewBag.August = August;
            ViewBag.September = September;
            ViewBag.October = October;
            ViewBag.November = November;
            ViewBag.December = December;
        }
    }
}
