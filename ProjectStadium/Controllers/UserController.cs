using Microsoft.AspNetCore.Mvc;
using BLL.Services.Users;
using Domain.ViewModels.Users;


namespace ProjectStadium.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> GetUsers()
    {
        var response = await _userService.GetUsers();
        return Ok(response.Data);
    }

    public async Task<IActionResult> DeleteUser(long id)
    {
        var response = await _userService.DeleteUser(id);
        return RedirectToAction("GetUsers");
    }


    [HttpPost]
    public async Task<IActionResult> Create(UserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _userService.Create(model);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return Json(new { description = response.Description });
            }
            return BadRequest(new { errorMessage = response.Description });
        }
        return Ok();
    }

    [HttpPost]
    public JsonResult GetRoles()
    {
        var types = _userService.GetRoles();
        return Json(types.Data);
    }
}