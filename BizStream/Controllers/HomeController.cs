using BizStream.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BizStream.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Result()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Form formData)
        {
            string filePath = @"..\BizStream\wwwroot\formData.txt";



            if (!System.IO.File.Exists(filePath))
            {
                // Create a file to write to.
                using (StreamWriter sw = System.IO.File.CreateText(filePath))
                {
                    sw.WriteLine(formData.FirstName + "\n" + formData.LastName + "\n" + formData.Email + "\n" + formData.Message + "\n");
                }
            }
            else
            {
                System.IO.File.AppendAllText(filePath, formData.FirstName + "\n" + formData.LastName + "\n"+ formData.Email+"\n" + formData.Message +"\n");
            }


            return RedirectToAction("Result");
        }

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
