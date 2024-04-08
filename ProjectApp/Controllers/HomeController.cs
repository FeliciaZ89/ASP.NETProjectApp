using Microsoft.AspNetCore.Mvc;
using ProjectApp.Models.Components;
using ProjectApp.Models.Sections;
using ProjectApp.Models.Views;
using ProjectApp.ViewModels;

namespace ProjectApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel();
        return View(viewModel);
    }

}
