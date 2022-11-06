using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GolfPlatform.Domain.Usecases;
using GolfPlatform.Domain.Models;

namespace GolfPlatform.Controllers;

public class ApiController : Controller
{
    private IUserUsecases _userUsecases;
    public ApiController(IUserUsecases userUsecases)
    {
        _userUsecases = userUsecases;
    }

    public JsonResult Index()
    {
        var users = _userUsecases.Get();
        return new JsonResult(new { Users = users });
    }
}
