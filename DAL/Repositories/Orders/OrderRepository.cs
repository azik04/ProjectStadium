using Domain.Entity;
using Microsoft.EntityFrameworkCore;

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
    public IQueryable<Order> GetAll() => _db.Orders.Include(x => x.StadiumId);
}
