using Microsoft.AspNetCore.Mvc;
using GolfPlatform.Data;
using GolfPlatform.Data.Repositories;
using GolfPlatform.Domain.Models;
using GolfPlatform.Domain.Usecases;

namespace GolfPlatform.Controllers;
public class LoginController : Controller
{
    private IUserUsecases _userUsecases;
    public LoginController(AppDbContext context)
    {
        var userRepository = new UserRepository(context);
        _userUsecases = new UserUsecases(userRepository);
    }
    public IActionResult Index()
    {
        return View();
    }
}