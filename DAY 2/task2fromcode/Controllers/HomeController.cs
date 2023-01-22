using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using task2fromcode.Models;

namespace task2fromcode.Controllers
{
    public class HomeController : Controller
    {
        companyDBcontext DB = new companyDBcontext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult login(employee emp)
        {

            var q = DB.employees.Where(x => x.SSN == emp.SSN && x.Fname==emp.Fname).SingleOrDefault();
          
            if (q!=null)
            {
                //set session
                HttpContext.Session.SetInt32("id", q.SSN);
                return RedirectToAction("userinfo", "Employee");



            }
            else
            {
                return Content("niiii");
            }


        }

        public IActionResult hello()
        {
            return View("hello");
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