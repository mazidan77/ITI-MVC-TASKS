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
           //33
           //...
           //----
            TempData["name"] = "new dependent added";

            return RedirectToAction(nameof(showdebendent));
        
        }

        // details
        public IActionResult Ddetails(string id)
        {
            var eid = HttpContext.Session.GetInt32("id");
            var q = DB.Dependents.Where(x=>x.EmployeeSSN==eid  && x.name==id ).SingleOrDefault();    

            return View(q);

        }

        //update form


        public IActionResult editform(string id)
        {
            var eid = HttpContext.Session.GetInt32("id");
            var q = DB.Dependents.Where(x => x.EmployeeSSN == eid && x.name == id).SingleOrDefault();

            return View(q);

        }

        public IActionResult afteredit(dependent dep)
        {
            var eid = HttpContext.Session.GetInt32("id");
            var q = DB.Dependents.Where(x => x.EmployeeSSN == eid && x.name == dep.name).SingleOrDefault();
            q.name=dep.name;
            q.Bdate = dep.Bdate;
            q.relationship = dep.relationship;
            q.sex = dep.sex;
            DB.SaveChanges();

            return RedirectToAction(nameof(showdebendent));

        }

        public IActionResult delete(string id)
        {
            var eid = HttpContext.Session.GetInt32("id");
            var q = DB.Dependents.Where(x => x.EmployeeSSN == eid && x.name ==id).SingleOrDefault();
            DB.Dependents.Remove(q);
            DB.SaveChanges();

            return RedirectToAction(nameof(showdebendent));

        }

        //bind data ==> premetive - array - dictionary - object
        //periority ==> form data(post) -route - query string (get)-file brovider - not found
        public IActionResult dec(Dictionary<string,int> phones)
        {


            return Content("");
        }
    }
}
