using Domain.Entity;

namespace DAL.Repositories.OrderTimes;
public interface IOrderTimeRepository
{
    IQueryable<OrderTime> GetAll();
}
