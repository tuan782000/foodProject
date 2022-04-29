using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Data;
using Microsoft.Extensions.Configuration;

namespace Food.Controllers
{
    public class TestController : Controller
    {

        private readonly ApplicationDbContext _context;


        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Route("/test")]
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }


        public void Mail()
        {
            var smtpacountJson = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("MailSettings")["Mail"];
            var smtppasswordJson = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("MailSettings")["Password"];

            String noidung = "Test noi dung";
            String mailnhan = "thaibao0225@gmail.com";
            String mailgui = "tuanntmmo@gmail.com";
            String chude = "Kiểm tra email gửi đi";
            string smtpacount = smtpacountJson.ToString();
            string smtppassword = smtppasswordJson.ToString();

            MailUtils.MailUtils.SendMailGoogleSmtp(
                mailgui,
                mailnhan,
                chude,
                noidung,
                smtpacount,
                smtppassword

            ).Wait();
        }
    }
}
