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
    private readonly IStadiumService _service;
    public StadiumController (IStadiumService service)
    {
        _service = service;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateStadiumViewModel viewModel)
    {
        await _service.CreateAsync(viewModel);
        return Ok(viewModel);
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _service.GetAll();
        return Ok(response.Data);
    }
    [HttpDelete]
    public  Task<IActionResult> Delete(int id)
    {
        var response =  _service.DeleteAsync(id);
        return bool;
    }
    [HttpGet]
    public  Task<ActionResult> GetByName(string name)
    {
        var response = _service.GetByName(name);
        return Ok(response);
    }
}
