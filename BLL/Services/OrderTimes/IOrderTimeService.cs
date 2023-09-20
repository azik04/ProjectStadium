using Domain.Entity;
using Domain.Response;
using Domain.ViewModels.Orders;
using Domain.ViewModels.OrderTimes;

namespace BLL.Services.OrderTimes;

public interface IOrderTimeService
{
    Task<IBaseResponse<OrderTime>> CreateAsync(CreateOrderTimeViewModel model);
    IBaseResponse<List<OrderTime>> GetAll();
}
