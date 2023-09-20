using DAL.Repositories.Orders;
using Domain.Entity;
using Domain.Response;
using Domain.ViewModels.Orders;

namespace BLL.Services.Orders;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    public OrderService (IOrderRepository repository)
    {
        _repository = repository;
    }
    public async Task<IBaseResponse<Order>> CreateAsync(CreateOrderViewModel model)
    {
        try
        {
            var order = new Order()
            {
                CreateDateTime = DateTime.Now,
                StadiumId = model.StadiumId,
                UserId = model.UserId,
                OrderDateTime = DateTime.Now,
            };
            await _repository.Create(order);
            return new BaseResponse<Order>()
            {
                Data = order,
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<Order>
            {
                Description = $"[CreateAsync] {ex.Message}",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
    }

    public IBaseResponse<List<Order>> GetAll()
    {
        try
        {
            var order = _repository.GetAll().ToList();
            _repository.GetAll();
            return new BaseResponse<List<Order>>()
            {
                Data = order,
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Order>>
            {
                Description = $"[GetAll] {ex.Message}",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
    }

    public async Task<IBaseResponse<Order>> UpdateAsync(UpdateOrderViewModel model, long id)
    {
        try
        {
            var find = _repository.GetAll().SingleOrDefault(x => x.Id == id);
            var order = new Order()
            {
                StadiumId = model.StadiumId,
                UserId = model.UserId,
                OrderDateTime = model.OrderDateTime,
            };
            await _repository.Update(order);
            return new BaseResponse<Order>
            {
                Data = order,
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<Order>
            {
            Description = $"[UpdateAsync] {ex.Message}",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
    }
    public async Task<IBaseResponse<Order>> DeleteAsync(long id)
    {
        try
        {
            var order = _repository.GetAll().SingleOrDefault(x => x.Id == id);
            await _repository.Delete(order);
            return new BaseResponse<Order>
            {
                Data = order,
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<Order>
            {
                Description = $"[DeleteAsync] {ex.Message}",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
    }
}
