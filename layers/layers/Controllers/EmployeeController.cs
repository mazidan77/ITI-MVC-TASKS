using layers.Models;
using layers.Reposiotries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace layers.Controllers
{
    public class EmployeeController : Controller
    {
        IemployeeRepo ER;

        public EmployeeController(IemployeeRepo ER)
        {
           this.ER = ER;
        }
        public IActionResult Index()
        {
           
           return View();
        }

        public IActionResult getall()
        {
            return View(ER.getAll());

        }

        public IActionResult getemp(int id)
        {
            return View(ER.getById(id));

        }

        [HttpGet]
        public IActionResult add(int id)
        {

            var q =ER.getAll();
            ViewBag.q = new SelectList(q, "SSN", "Fname");
            return View();
           

        }

        [HttpPost]
        public IActionResult add(employee emp)
        {
            ER.Add(emp);
           return RedirectToAction(nameof(getall));

        }

        [HttpGet]
        public IActionResult edit(int id)
        {
            var q = ER.getById(id);
            var q2=ER.getAll();
            ViewBag.q2 = new SelectList(q2, "SSN", "Fname");
            return View(q);

        }
        [HttpPost]
        public IActionResult edit(employee emp)
        {
         
            ER.Edit(emp);

            return RedirectToAction(nameof(getall));
        }

        public IActionResult delete(int id)
        {
           ER.Delete(id);
            return RedirectToAction(nameof(getall));

        }

    }
}
