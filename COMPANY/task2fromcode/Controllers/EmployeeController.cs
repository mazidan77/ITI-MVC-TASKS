using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2fromcode.Models;

namespace task2fromcode.Controllers
{
    public class EmployeeController : Controller
    {
        companyDBcontext DB=new companyDBcontext(); 
        public IActionResult Index()
        {
       var q=  DB.employees.ToList();
            return View(q);
        }

        public IActionResult getinfo(int id)
        {
            var q = DB.employees.Where(x=>x.SSN==id).SingleOrDefault();
            ViewBag.emp = DB.employees.ToList();
           
            return View(q);
        }
        public IActionResult userinfo()
        {

            var id = HttpContext.Session.GetInt32("id");

           

            var q = DB.employees.Where(x => x.SSN == id).SingleOrDefault();
            ViewBag.emp = DB.employees.ToList();
             
            if (id!=null)
            {
                return View(q);
            }
            else
            {
                return View("../Home/index");
            }
          
        }
     

        public IActionResult addform()
        {
           
            var q = DB.employees.ToList();
            return View(q);
        }

        public IActionResult addnew(employee emp)
        {
            var q = DB.employees.ToList();
            DB.employees.Add(emp);
            DB.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public IActionResult delete(int id)
        {

            var q = DB.employees.Where(x=>x.SSN== id).SingleOrDefault();

            DB.employees.Remove(q);
                 DB.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult editform(int id)
        {

            var q = DB.employees.Where(x => x.SSN == id).SingleOrDefault();
             ViewBag.emp = DB.employees.ToList();
           
            return View(q);

        }

        public IActionResult afteredit(employee emp)
        {

            var q = DB.employees.Where(x=>x.SSN== emp.SSN).SingleOrDefault();
            q.Fname=emp.Fname;
            q.Lname=emp.Lname;
            q.salary=emp.salary;
            q.superid=emp.superid;
            q.sex=emp.sex;
            q.address=emp.address;
            DB.SaveChanges();
            return RedirectToAction(nameof(Index));



        }
    }
}
