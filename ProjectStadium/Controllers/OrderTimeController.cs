using BLL.Services.OrderTimes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectStadium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTimeController : ControllerBase
    {
        private readonly IOrderTimeService _service;
        public OrderTimeController(IOrderTimeService service)
        {
            _service = service;
        }
        public IActionResult GetAll()
        {
            var response = _service.GetAll();
            return Ok(response.Data);
        }
    }
}
