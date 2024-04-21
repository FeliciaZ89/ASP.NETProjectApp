using Infrastructure.Entities;
using Infrastructure.Services;
using ProjectApp.Models.Components;
using ProjectApp.Models.Sections;
using ProjectApp.ViewModels;
using System;
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
        Link = new() { ControllerName = "Home", ActionName = "Index", Fragment = "download", Text = "Get started for free" },

        BrandsText = "Largest companies use our tool to work efficiently",
        Brands =
                [
                    new() { ImageUrl = "/images/brands1.svg", AltText = "Brand Name 1" },
                    new() { ImageUrl = "/images/brands2.svg", AltText = "Brand Name 2" },
                    new() { ImageUrl = "/images/brands3.png", AltText = "Brand Name 3" },
                    new() { ImageUrl = "/images/brands4.svg", AltText = "Brand Name 4" },
                ],
    };
    public WorkViewModel Dashboard { get; set; } = new WorkViewModel
    {
        Id = "dashbord",
        DashboardImage = new() { ImageUrl = "/images/dashimg.svg", AltText = "Dashboard image" },
        Title = "Manage your work",
        TextItems =
        [
          "Powerful project management" ,
          "Transparent work management" ,
          "Manage work & focus on the most important tasks" ,
          "Track your progress with interactive charts" ,
          " Easiest way to track time spent on tasks"
        ],

        Link = new() { ControllerName = "Contact", ActionName = "Index", Text = "Learn more" },

    };

    public DownloadViewModel Download { get; set; } = new DownloadViewModel
    {
        Id = "download",
        DownloadImage = new() { ImageUrl = "./Images/iphone.svg", AltText = "download apps image" },
        Title = "Download Our App for Any Devices:",
        Stores =
        [
            new() {
                Name = "App Store",
                RatingImage = new ImageViewModel { ImageUrl = "./Images/rating.svg", AltText = "rating stars" },
                Highlight = "Editor's Choice",
                Rating = "rating 4.7, 187K+ reviews",
                StoreLogo = new ImageViewModel { ImageUrl = "./Images/appstore.svg", AltText = "apple store logo" },
               StoreLink = new LinkViewModel { Url = "https://www.apple.com/se/app-store/", Text = "" }
             },
            new() {
                Name = "Google Play",
                RatingImage = new ImageViewModel { ImageUrl = "./Images/rating.svg", AltText = "rating stars" },
                Highlight = "App of the Day",
                Rating = "rating 4.8, 30K+ reviews",
                StoreLogo = new ImageViewModel { ImageUrl = "./Images/googleplay.svg", AltText = "google play logo" },
                StoreLink = new LinkViewModel { Url = "https://play.google.com/", Text = "" }
              }
         ]
    };

    public SubscribeViewModel Subscribe { get; set; }
 }



