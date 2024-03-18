using Microsoft.AspNetCore.Mvc;
using ProjectApp.ViewModels;

namespace ProjectApp.Controllers
{
    public class AccountController : Controller
    {
        [Route("/signup")]
        [HttpGet]
       
        public IActionResult SignUp()
        {
            var viewModel = new SignUpViewModel();
            return View(viewModel);
        }


        [Route("/signup")]
        [HttpPost]
        public IActionResult SignUp(SignUpViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

           return RedirectToAction("SignIn", "Account");
           
        }



        public IActionResult SignIn()
        {

            return View();
        }



        public new IActionResult SignOut()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
