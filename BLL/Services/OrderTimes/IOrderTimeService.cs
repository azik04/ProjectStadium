using Domain.Entity;
using Domain.Response;
using Domain.ViewModels.Orders;

namespace BLL.Services.OrderTimes;

public interface IOrderTimeService
{
    IBaseResponse<List<OrderTime>> GetAll();
}
