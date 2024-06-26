﻿using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApp.ViewModels;
using Infrastructure.Models;

namespace ProjectApp.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");

        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [Route("/signup")]
  
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var exists = await _userManager.Users.AnyAsync( x=> x.Email == viewModel.Email);
            if (exists)
            {
                ModelState.AddModelError("Already exists", "User with the same email address already exists");
                viewModel.ErrorMessage = "User with the same email address already exists"; 
                return View(viewModel);
            }
            var userEntity = new UserEntity
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email=viewModel.Email,
                UserName=viewModel.Email,
                Created = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(userEntity, viewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Auth");
            }

        }
        return View(viewModel);
       
    }


    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");

        var viewModel = new SignInViewModel();
        return View(viewModel);
    }

    [Route("/signin")]
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {


        if (ModelState.IsValid)

        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Details", "Account");
            } 
                
        }

        ModelState.AddModelError("Incorrect Values", "Incorrect email or password");
        viewModel.ErrorMessage = "Incorrect email or password";
        return View(viewModel);
    }

    [HttpGet]
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
       await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
