using Microsoft.AspNetCore.Mvc;

namespace ProjectApp.Controllers;

public class SiteSettingsController : Controller
{
    public IActionResult ChangeTheme(string theme)
    {
        var option = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(60),
        };
        Response.Cookies.Append("ThemeMode", theme, option);
        return Ok(option);
    }

    [HttpPost]
    public IActionResult CookieConsent()
    {
        var option = new CookieOptions
        {
            Expires = DateTime.Now.AddYears(1),
            HttpOnly = true,
            Secure = true
        };

        Response.Cookies.Append("CookieConsent", "true", option);
        return Ok(option);
    }
}
