using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using GolfPlatform.Domain.Usecases;
using GolfPlatform.Domain.Models;

namespace GolfPlatform.Controllers;

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
    public async Task<IActionResult> Index(string username, string password)
    {
        UserModel? user = _userUsecases.LogIn(username, password);

        if (user is not null && user.Email != null)
        {
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                new Claim(ClaimTypes.Name, user.Email),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties()
                {
                    IsPersistent = true
                }
            );

            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1d);
            Response.Cookies.Append("userId", user.Id.ToString(), cookieOptions);

            return RedirectToAction("Index", "Home");
        }

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