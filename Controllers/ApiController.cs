using Microsoft.AspNetCore.Mvc;
using GolfPlatform.Domain.Usecases;

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

    public JsonResult Hit()
    {
        var userId = Request.Cookies["userId"];

        if (userId != null)
        {
            _userUsecases.Hit(Int32.Parse(userId));
        }

        var users = _userUsecases.Get();
        return new JsonResult(new { Users = users });
    }
}
