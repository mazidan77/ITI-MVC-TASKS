using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using task2fromcode.Models;

namespace task2fromcode.Controllers
{
    public class workforController : Controller
    {
        companyDBcontext DB = new companyDBcontext();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult updatehours()
        {
            var q = DB.employees.ToList();
            ViewBag.q = new SelectList(q, "SSN", "Fname");
           

            return View();
        }

        public IActionResult projects(int id)
        {
            var q = DB.WorksFor.Where(x=>x.ESSN== id).Select(x=>x.Project).ToList();
            ViewBag.q = new SelectList(q, "Pnumber", "Name");
            return PartialView("_project");
        }

        public IActionResult Hours(int id, int num)
        {
            var q = DB.WorksFor.Where(x=>x.ESSN==id && x.Pnum==num).SingleOrDefault();
            return PartialView("_Hours", q);
        }

        public IActionResult update(workfor f)
        {
            var q = DB.WorksFor.SingleOrDefault(s => s.ESSN == f.ESSN && s.Pnum == f.Pnum);
            q.hour = f.hour;
            DB.SaveChanges();
            return RedirectToAction("updatehours");
        }


    }
}
