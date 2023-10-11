using BLL.Services.Stadiums;
using DAL.Repositories.Stadiums;
using Domain.ViewModels.Stadiums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ProjectStadium.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StadiumController : ControllerBase
{
    private readonly StadiumService _service;
    public StadiumController(StadiumService service)
    {
        _service = service;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateStadiumViewModel viewModel)
    {
        var response = _service.CreateAsync(viewModel);
        return Ok(viewModel);
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _service.GetAll();
        if (response.StatusCode == Domain.Enums.StatusCode.OK)
        {
            return Ok(response.Data);
        }
        return RedirectToAction("Error", $"{response.Description}");
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var responce = await _service.DeleteAsync(id);
        if (responce.StatusCode == Domain.Enums.StatusCode.OK)
        {
            return Ok("GetAll");
        }
        return RedirectToAction("Error");
    }
}
