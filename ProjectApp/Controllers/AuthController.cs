using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.ViewModels;

namespace ProjectApp.Controllers
{
    public class AuthController(UserService userService) : Controller
    {
        private readonly UserService _userService = userService;

       
        [HttpGet]
        [Route("/signup")]
        public IActionResult SignUp()
        {
            var viewModel = new SignUpViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Route("/signup")]
      
        public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(viewModel.Form);
                if (result.StatusCode == Infrastructure.Models.StatusCodes.OK)
                    return RedirectToAction("SignIn", "Auth");

            }
            return View(viewModel);
           
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
        public async Task<IActionResult> SignIn(SignInViewModel viewModel)
        {


            if (ModelState.IsValid)

            {
                var result = await _userService.SignInUserAsync(viewModel.Form);
                if (result.StatusCode == Infrastructure.Models.StatusCodes.OK)


                    //var result=_accountService.SignIn(viewModel.Form);
                    //if(result)
                    return RedirectToAction("Details", "Account");
            }

            viewModel.ErrorMessage = "Incorrect email address or password";
            return View(viewModel);     

        }


        public new IActionResult SignOut()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
