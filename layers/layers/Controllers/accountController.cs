using layers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using System.Threading.Tasks;

namespace layers.Controllers
{

    [Authorize]
    public class accountController : Controller
    {
    private readonly    UserManager<IdentityUser> userManager;
    private readonly   SignInManager<IdentityUser> signInManager;

        public accountController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager )
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
        }   
    
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
 
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult>  login(loginVM loginuser)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginuser.UserName);
                if (user != null)
                {
                 bool valid=  await userManager.CheckPasswordAsync(user,loginuser.Password);
                    Microsoft.AspNetCore.Identity.SignInResult res =  await signInManager.PasswordSignInAsync(user, loginuser.Password, loginuser.isper, false);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("getall", "employee");
                    }
                
                }
                else
                {
                    ModelState.AddModelError("", "invalid userName or password");
                    return View(loginuser);
                }
             
            }
            return View(loginuser);
        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult registration()
        {
            return View();
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task <IActionResult> registration(registerVM account)
        {
            if(ModelState.IsValid) {
                IdentityUser user = new IdentityUser()
                {
                    UserName = account.UserName,
                    Email = account.Email,
                };
              

                //save user & create cookie
             IdentityResult result =    await userManager.CreateAsync(user,account.Password);
                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);//create cookie
                return    RedirectToAction("getall", "employee");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                       
                    }
                  

                }
            
            
            }
            return View(account);
        }


        public IActionResult profile()
        {
            return View();
        }
    }
}
