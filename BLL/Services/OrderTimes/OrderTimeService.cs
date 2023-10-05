using DAL.Repositories.OrderTimes;
using Domain.Entity;
using Domain.Response;

namespace BLL.Services.OrderTimes;
public class OrderTimeService : IOrderTimeService
{
    private readonly IOrderTimeRepository _repository;
    public OrderTimeService (IOrderTimeRepository repository)
    {
        _repository = repository;
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
