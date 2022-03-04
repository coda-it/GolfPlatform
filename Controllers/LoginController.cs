using Microsoft.AspNetCore.Mvc;
using GolfPlatform.Domain.Usecases;

namespace GolfPlatform.Controllers;

public struct ViewUser
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginController : Controller
{
    private IUserUsecases _userUsecases;
    public LoginController(IUserUsecases userUsecases)
    {
        _userUsecases = userUsecases;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string username, string password)
    {
        var user = _userUsecases.LogIn(username, password);
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string username, string password)
    {
        _userUsecases.Add(username, password);
        return View();
    }
}