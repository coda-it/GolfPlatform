using Microsoft.AspNetCore.Mvc;
using GolfPlatform.Domain.Usecases;

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
}