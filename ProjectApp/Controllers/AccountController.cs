using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.ViewModels;

//[Authorize]
public class AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    [HttpGet]
    [Route("/account/details")]
    public async Task<IActionResult> Details()
    {
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("SignIn", "Auth");

        var userEntity = await _userManager.GetUserAsync(User);
        var viewModel = new AccountDetailsViewModel()
        {   
            User = userEntity!

        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> BasicInfo(AccountDetailsViewModel viewModel)
    {
        var result = await _userManager.UpdateAsync(viewModel.User);
            if (!result.Succeeded)
        {
            ModelState.AddModelError("Failed to save data", "Unable to save data");
            ViewData["Error Message"] = "Failed to save data"; 
        }

        return RedirectToAction("Details","Account",viewModel);
    }

}

