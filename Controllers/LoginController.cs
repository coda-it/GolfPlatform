using Microsoft.AspNetCore.Mvc;

namespace GolfPlatform.Controllers;
public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}