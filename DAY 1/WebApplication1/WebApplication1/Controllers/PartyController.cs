using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PartyController : Controller
    {
        public IActionResult Index()
        {
            return View("all");
        }

        public IActionResult allfriend()
        {

            var p = sampledata.Friends.Where(x => x.attend == "yes").ToList();


            return View("all", p);
        }


        public IActionResult addfriend()
        {




            return View("addform");
        }

        public IActionResult adddata(Party po) 
        {
            sampledata.add(po);
            List<Party> p = sampledata.Friends.Where(x => x.attend == "yes").ToList();
            if (po.attend == "no")
            {
                return View("later");

            }
            else
            {


                return View("thankyou");
            }



        }


    }
}
