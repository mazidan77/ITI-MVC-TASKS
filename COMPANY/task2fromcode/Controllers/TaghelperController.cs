using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using task2fromcode.Models;

namespace task2fromcode.Controllers
{
    public class TaghelperController : Controller
    {
        companyDBcontext DB = new companyDBcontext();
        public IActionResult Index()
        {
            return View();
        }

        /////////Employee

        public IActionResult showAllEmp()
        {
            var q = DB.employees.ToList();
            return View(q);
        }

        public IActionResult getinfoemp(int id)
        {
            var q = DB.employees.Where(x => x.SSN == id).SingleOrDefault();
            ViewBag.emp = DB.employees.ToList();

            return View(q);
        }
        [HttpGet]
        public IActionResult addemp()
        {
           var q = DB.employees.ToList();
            ViewBag.q = new SelectList(q,"SSN","Fname");
            return View();
        }

        [HttpPost]
        public IActionResult addemp(employee emp)
        {
            var e = DB.employees.Where(x => x.SSN == emp.SSN).FirstOrDefault();
            if (e == null)
            {

                var q = DB.employees.ToList();
                DB.employees.Add(emp);
                DB.SaveChanges();
                return RedirectToAction(nameof(showAllEmp));
            }
            else
            {
                var q = DB.employees.ToList();
                ViewBag.q = new SelectList(q, "SSN", "Fname");
                ModelState.AddModelError("SSN", "SSN alrady taken");
                return View();

            }
        }
        public IActionResult editemployee(int id)
        {
            var q = DB.employees.Where(x=>x.SSN==id).SingleOrDefault();
            var q2 = DB.employees.ToList();
            ViewBag.q2 = new SelectList(q2, "SSN", "Fname", q.Fname);
            return View(q);
        }

        public IActionResult aftereditemployee(employee emp)
        {
          var q = DB.employees.Where(x=>x.SSN==emp.SSN).SingleOrDefault();

            q.Fname=emp.Fname;
            q.SSN=emp.SSN;
            q.Lname=emp.Lname;
            q.salary=emp.salary;
            q.sex=emp.sex;
            q.Bdate=emp.Bdate;
            q.superid=emp.superid;

            DB.SaveChanges();

           return RedirectToAction(nameof(showAllEmp));
        }

        public IActionResult deleteemp(int id)
        {
            var q = DB.employees.Where(x => x.SSN == id).SingleOrDefault();
            DB.employees.Remove(q);

            DB.SaveChanges();

            return RedirectToAction(nameof(showAllEmp));

        }
            ///////////////////////////////////////////////////////////
            ///

            public IActionResult showAllDept()
            {
                var q = DB.Departments.ToList();
                return View(q);
            }
        public IActionResult adddept()
        {
           
            return View();
        }

        public IActionResult afteradddep(department dept)
        {
           DB.Departments.Add(dept);
            DB.SaveChanges();

            return RedirectToAction(nameof(showAllDept));
        }

        public IActionResult Deptdetails(int id)
        {
            var q =DB.Departments.Where(x=>x.Dnum==id).SingleOrDefault();


            return View(q);
        }

        public IActionResult editdept(int id)
        {
            var q =DB.Departments.Where(x=>x.Dnum== id).SingleOrDefault();


            return View(q);
        }

        public IActionResult aftereditdept(department dep)
        {
            var q = DB.Departments.Where(x => x.Dnum == dep.Dnum).SingleOrDefault();

            q.DName= dep.DName;
            DB.SaveChanges();



            return RedirectToAction(nameof(showAllDept));
        }

        public IActionResult deletdept(int id)
        {
            var q = DB.Departments.Where(x => x.Dnum ==id).SingleOrDefault();

            DB.Departments.Remove(q);
            DB.SaveChanges();



            return RedirectToAction(nameof(showAllDept));
        }

    }
}
