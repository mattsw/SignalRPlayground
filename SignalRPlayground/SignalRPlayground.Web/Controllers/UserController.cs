using Microsoft.AspNetCore.Mvc;
using SignalRPlayground.Repositories.Users;
using SignalRPlayground.UserTools.Interfaces;
using SignalRPlayground.UserTools.UserManager;

namespace SignalRPlayground.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(INewUserManager userManager) : ControllerBase
{
    private readonly INewUserManager _userManager = userManager;

    [HttpPut]
    public IActionResult UpdateUser(UserDto user)
    {
        _userManager.UpdateUser(user);

        return Ok(user);
    }
}