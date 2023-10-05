using Domain.Entity;
namespace DAL.Repositories.Orders;
public interface IOrderRepository 
{
    Task<bool> Create(Order entity);
    IQueryable<Order> GetAll();
}
