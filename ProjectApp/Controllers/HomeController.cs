using Microsoft.AspNetCore.Mvc;
using ProjectApp.Models.Components;
using ProjectApp.Models.Sections;
using ProjectApp.Models.Views;

namespace ProjectApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {


        var viewModel = new HomeIndexViewModel
        {
            Title = "Task Management Assistent",
            Showcase = new ShowcaseViewModel
            {
                Id = "overview",
                Title = "Task Management Assistent You Gonna Love",
                Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
                Link = new() { ControllerName="Downloads",ActionName="Index", Text= "Get started for free " },
                BrandsText = "Largest companies use our tool to work efficiently ",
             
                Brands =
                [
                    new() { ImageUrl= "images/brands1.svg",  AltText = "logo brand name 1" },
                    new() { ImageUrl = "images/brands2.svg", AltText = "logo brand name 2" },
                    new() { ImageUrl = "images/brands3.png", AltText = "logo brand name 3" },
                    new() { ImageUrl = "images/brands4.svg", AltText = "logo brand name 4" }

                    ],
               
                ShowcaseImage = new() { ImageUrl= "images/image.svg",  AltText="Showcase image"}


            }

        };
        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
}
