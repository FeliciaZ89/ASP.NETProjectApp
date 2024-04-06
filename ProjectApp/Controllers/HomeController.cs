using Microsoft.AspNetCore.Mvc;
using ProjectApp.Models.Components;
using ProjectApp.Models.Sections;
using ProjectApp.ViewModels;

namespace ProjectApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
       
        return View();
    }
}
