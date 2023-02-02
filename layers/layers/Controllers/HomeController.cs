using layers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace layers.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

       companyDBcontext DB = new companyDBcontext();
        public HomeController(ILogger<HomeController> logger)
        {
            var q = DB.employees.Where(x=>x.SSN== 1).SingleOrDefault();
            _logger = logger;
        }

        public IActionResult Index()
        {
            var q = DB.employees.Where(x => x.SSN == 1).SingleOrDefault();
            return RedirectToAction("registration","account");
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