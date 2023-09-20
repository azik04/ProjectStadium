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
    public StadiumController (StadiumService service)
    {
        _service = service;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateStadiumViewModel viewModel)
    {
        _service.CreateAsync(viewModel);
        return Ok(viewModel);
    }
    [HttpGet]
    public async Task<List<IActionResult>> GetAll()
    {
        var responce = _service.GetAll();
        if (responce.StatusCode == Domain.Enums.StatusCode.OK)
        {
            return Ok(responce);
        }
        return RedirectToAction("Error");
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdateStadiumViewModel viewModel)
    {
        var responce = _service.UpdateAsync(viewModel);
        return Ok(viewModel);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var responce = await _service.DeleteAsync(id);
        if (responce.StatusCode == Domain.Enums.StatusCode.OK)
        {
            return RedirectToAction("GetAll");
        }
        return RedirectToAction("Error");
    }
}
