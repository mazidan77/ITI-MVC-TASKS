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
        [HttpGet]
        public IActionResult addform()
        {
            ViewBag.dept = DB.Departments.ToList();
           
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addform(projectVM proj)
        {
            if(ModelState.IsValid)
            {
                project newproject = new project()
                {
                    Name = proj.Name,
                    Pnumber = proj.Pnumber,
                    location = proj.location
                };
                DB.Projects.Add(newproject);
                DB.SaveChanges();


                return RedirectToAction(nameof(showall));
            }
            else
            {
                return View();
            }
       
        }

        public IActionResult delete(int id)
        {
          var q= DB.Projects.Where(x=>x.Pnumber== id).SingleOrDefault();
            DB.Projects.Remove(q);
            DB.SaveChanges();

            return RedirectToAction(nameof(showall));
        }


        //public IActionResult AFTERADD(project proj)
        //{
        //    DB.Projects.Add(proj);
        //    DB.SaveChanges();


        //    return RedirectToAction(nameof(showall));
        //}

    }
}
