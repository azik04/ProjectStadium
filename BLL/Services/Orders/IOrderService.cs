using Domain.Entity;
using Domain.Response;
using Domain.ViewModels.Orders;
using Domain.ViewModels.Stadiums;

namespace BLL.Services.Orders;
public interface IOrderService
{
    Task<IBaseResponse<Order>> CreateAsync(CreateOrderViewModel model);
    IBaseResponse<List<Order>> GetAll();
}
