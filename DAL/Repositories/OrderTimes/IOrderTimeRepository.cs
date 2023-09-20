using Domain.Entity;

namespace DAL.Repositories.OrderTimes;
public interface IOrderTimeRepository
{
    Task<bool> Create(OrderTime entity);
    IQueryable<OrderTime> GetAll();
}
