using BLL.Services.Orders;
using Domain.ViewModels.Orders;
using Domain.ViewModels.Stadiums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectStadium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel viewModel)
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
    }
}
