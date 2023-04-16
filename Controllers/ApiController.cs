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
        var users = _userUsecases.Get();
        return new JsonResult(new { Users = users });
    }
}
