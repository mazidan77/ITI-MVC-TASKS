using Microsoft.AspNetCore.Mvc;
using task2fromcode.Models;

namespace task2fromcode.Controllers
{
    public class dependentsController : Controller
    {
        companyDBcontext DB = new companyDBcontext();   
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult showdebendent()
        {
            var id = HttpContext.Session.GetInt32("id");

            var qq = DB.Dependents.Where(x => x.EmployeeSSN == id).ToList();
            ViewBag.emp = DB.employees.ToList();
            return View(qq);
        }

        public IActionResult addform()
        {

            var id = HttpContext.Session.GetInt32("id");

            var qq = DB.employees.Where(x => x.SSN == id).SingleOrDefault();
            return View(qq);

        }

        public IActionResult addnew(dependent de)
        {
            DB.Dependents.Add(de);
            DB.SaveChanges();

           // set TempData
           //...
            TempData["name"] = "new dependent added";





            return RedirectToAction(nameof(showdebendent));
        
        }

    }
}
