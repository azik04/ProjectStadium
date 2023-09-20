using DAL.Repositories.OrderTimes;
using Domain.Entity;
using Domain.Response;
using Domain.ViewModels.OrderTimes;

namespace BLL.Services.OrderTimes;
public class OrderTimeService : IOrderTimeService
{
    private readonly IOrderTimeRepository _repository;
    public OrderTimeService (IOrderTimeRepository repository)
    {
        _repository = repository;
    }
    public async Task<IBaseResponse<OrderTime>> CreateAsync(CreateOrderTimeViewModel model)
    {
        try
        {
            var orderTime = new OrderTime()
            {
                CreateDateTime = DateTime.Now,
                OrderTimes = model.OrderTimes,
            };
            await _repository.Create(orderTime);
            return new BaseResponse<OrderTime>
            {
                Data = orderTime,
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<OrderTime>()
            {
                Description = $"[CreateAsync] {ex.Message}",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
    }

    public IBaseResponse<List<OrderTime>> GetAll()
    {
        try
        {
            var orderTime = _repository.GetAll().ToList();
            _repository.GetAll();
            return new BaseResponse<List<OrderTime>>
            {
                Data = orderTime,
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<OrderTime>>()
            {
                Description = $"[CreateAsync] {ex.Message}",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
    }
}
