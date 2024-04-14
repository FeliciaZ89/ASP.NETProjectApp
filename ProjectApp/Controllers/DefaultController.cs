using Microsoft.AspNetCore.Mvc;
using ProjectApp.Models.Views;

namespace ProjectApp.Controllers;

public class DefaultController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel();

        ViewData["Title"] = viewModel.Title;
        return View("~/Views/Home/Index.cshtml", viewModel);
    }



    [Route("/error")]
    public IActionResult Error404(int statusCode) => View();
    //{
        //return View("Error404");
    //}
}
