using Microsoft.AspNetCore.Mvc;
using ProjectApp.ViewModels;

namespace ProjectApp.Controllers
{
    public class AuthController : Controller
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

           return RedirectToAction("SignIn", "Auth");
           
        }



        [Route("/signin")]
        [HttpGet]

        public IActionResult SignIn()
        {
            var viewModel = new SignInViewModel();
            return View(viewModel);
        }

        [Route("/signin")]
        [HttpPost]
        public IActionResult SignIn(SignInViewModel viewModel)
        {
           

            if (!ModelState.IsValid)
 
                return View(viewModel);


            //var result=_accountService.SignIn(viewModel.Form);
            //if(result)
            //  return RedirectToAction("Account", "Index");

            viewModel.ErrorMessage = "Incorrect email address or password";
            return View(viewModel);

          

        }




        public new IActionResult SignOut()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
