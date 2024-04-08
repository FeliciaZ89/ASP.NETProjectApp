using Infrastructure.Entities;
using Infrastructure.Services;
using ProjectApp.Models.Sections;
using ProjectApp.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace ProjectApp.Models.Views;

public class HomeIndexViewModel
{
    public string? Title { get; set; } = "Ultimate Task Managment Assistant";
    public ShowcaseViewModel Showcase { get; set; } = new ShowcaseViewModel
    {
        Id = "overview",
        ShowcaseImage = new() { ImageUrl = "/images/image.svg", AltText = "Task Managment Assistant" },
        Title = "Task Management Assistant You Gonna Love",
        Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
        Link = new() { ControllerName = "Downloads", ActionName = "Index", Text = "Get started for free" },
        BrandsText = "Largest companies use our tool to work efficiently",
        Brands =
                [
                    new() { ImageUrl = "/images/brands1.svg", AltText = "Brand Name 1" },
                    new() { ImageUrl = "/images/brands2.svg", AltText = "Brand Name 2" },
                    new() { ImageUrl = "/images/brands3.png", AltText = "Brand Name 3" },
                    new() { ImageUrl = "/images/brands4.svg", AltText = "Brand Name 4" },
                ],
    };


   

   
}