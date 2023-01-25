using Microsoft.AspNetCore.Mvc;
using task2fromcode.Models;

namespace task2fromcode.Controllers
{
 
    public class departmentController : Controller
    {
        companyDBcontext DB = new companyDBcontext();
        public IActionResult Index()
        {
            var id = HttpContext.Session.GetInt32("id");
            var q =DB.Departments.Where(x=>x.manageid== id).SingleOrDefault();

            return View(q);
        }

        public IActionResult addForm()
        {
            var id = HttpContext.Session.GetInt32("id");
            var q = DB.employees.ToList();
            var qq = DB.Projects.Where(x => x.DepartmentDnum == x.Department.Dnum && x.Department.Dnum == id);
            ViewBag.dps = qq;
            return View("ADDFROM",q);
        }
        public IActionResult afteradd(int id, List<int> p)
        {
            foreach (var a in p)
            {
                workfor q = new workfor()
                {
                    ESSN = id,
                    Pnum = a
                };
                DB.WorksFor.Add(q);
                DB.SaveChanges();
            }

            return RedirectToAction("index");
        }
    }
}
