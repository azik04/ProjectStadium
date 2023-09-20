using Domain.Entity;

namespace DAL.Repositories.OrderTimes;
public class OrderTimeRepository : IOrderTimeRepository
{
    private readonly ApplicationDbContext _db;
    public OrderTimeRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(OrderTime entity)
    {
        await _db.OrderTimes.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;    
    }

    public IQueryable<OrderTime> GetAll() => _db.OrderTimes;
}
