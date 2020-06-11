using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using randomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace randomPasscode.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {            
            HttpContext.Session.SetInt32("passcodeCount", 1);
            int? Count = HttpContext.Session.GetInt32("passcodeCount");
            ViewBag.num = Count;

            string chars ="ABCDEFGHIJKLMNOPQRSTUVWXWZ0123456789";
            string generatedCode = "";
            Random rand = new Random();
            for (int i = 0; i < 14; i++)
            {
                generatedCode += chars[rand.Next(chars.Length)];
            }
            ViewBag.Code = generatedCode;


            return View();
        }

        [HttpPost("")]
        public IActionResult Generate()
        {
            int? Count = HttpContext.Session.GetInt32("passcodeCount");
            Count += 1;
            HttpContext.Session.SetInt32("passcodeCount", (int)Count+1);

            int? num_count = HttpContext.Session.GetInt32("passcodeCount");
            @ViewBag.Num = num_count;

            string chars ="ABCDEFGHIJKLMNOPQRSTUVWXWZ0123456789";
            string generatedCode = "";
            Random rand = new Random();
            for (int i = 0; i < 14; i++)
            {
                generatedCode += chars[rand.Next(chars.Length)];
            }
            ViewBag.Code = generatedCode;
            return View("Index");
        }

        // public IActionResult Reset()
        // {
        //     HttpContext.Session.Clear();
        //     return View("Index");
        // }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
