using Domain.Entity;

namespace DAL.Repositories.Orders;
public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _db;
    public OrderRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Order entity)
    {
        await _db.Orders.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }
    public IQueryable<Order> GetAll() => _db.Orders;
    public async Task<Order> Update(Order entity)
    {
        _db.Orders.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
    public async Task<bool> Delete(Order entity)
    {
        _db.Orders.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}
