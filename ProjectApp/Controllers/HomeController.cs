using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectApp.Models.Components;
using ProjectApp.Models.Sections;
using ProjectApp.Models.Views;
using ProjectApp.ViewModels;
using System.Text;

namespace ProjectApp.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

    public HomeController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel();
        return View(viewModel);
    }
    public async Task<IActionResult> Subscribe(SubscribeViewModel model)
    {
        if (ModelState.IsValid)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7231/api/Subscribe", content);
            if (response.IsSuccessStatusCode)
            {
                TempData["StatusMessage"] = "You are now subscribed";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                TempData["StatusMessage"] = "You are already subscribed";
            }
        }
        else
        {
            TempData["StatusMessage"] = "Invalid email address";
        }

        return RedirectToAction("Index", "Home", "subscribe");
    }
}
