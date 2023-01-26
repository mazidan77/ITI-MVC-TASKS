using Microsoft.AspNetCore.Mvc;
using task2fromcode.Models;

namespace task2fromcode.Controllers
{
    public class ProjectsController : Controller
    {
        companyDBcontext DB = new companyDBcontext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult showall()
        {
            var q = DB.Projects.ToList();
                return View(q);
        }

        public IActionResult addform()
        {
            ViewBag.dept = DB.Departments.ToList();
           
            return View();
        }

        public IActionResult AFTERADD(project proj)
        {
            DB.Projects.Add(proj);
            DB.SaveChanges();


            return RedirectToAction(nameof(showall));
        }
    }
}
