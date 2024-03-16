using Microsoft.AspNetCore.Mvc;

namespace ProjectApp.Controllers
{
    public class AccountController : Controller
    {
        [Route("/signup")]
        public IActionResult SignIn()
        {
           
            return View();
        }

        public IActionResult SignUp()
        {
           
            return View();
        }


        public new IActionResult SignOut()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
