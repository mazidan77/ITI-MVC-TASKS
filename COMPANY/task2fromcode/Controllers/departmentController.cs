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

            if (q != null)
            {
                return View(q);
            }
          return Content("Error");
        }

        public IActionResult addForm()
        {
            var id = HttpContext.Session.GetInt32("id");
         
            ViewBag.emp = DB.employees.ToList();
            var q = DB.Departments.Where(x => x.manageid == id).SingleOrDefault();

            ViewBag.projects = DB.Projects.Where(x => x.DepartmentDnum==q.Dnum).ToList();
         
            return View();
        }

        [HttpPost]
        public IActionResult afteradd(employee emp,List<int> p)
        {
            var id = HttpContext.Session.GetInt32("id");

            ViewBag.emp = DB.employees.ToList();
            var q = DB.Departments.Where(x => x.manageid == id).SingleOrDefault();

            foreach (var a in p)
            {
                workfor w = new workfor()
                {
                    ESSN = emp.SSN,
                    Pnum = a,


                };
            var s = DB.employees.Where(x => x.SSN==emp.SSN).SingleOrDefault();

                s.workid = q.Dnum;
                DB.WorksFor.Add(w);
                DB.SaveChanges();
            }


           
      

            return RedirectToAction("index");
        }
    }
}
