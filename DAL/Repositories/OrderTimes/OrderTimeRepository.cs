using Domain.Entity;

namespace DAL.Repositories.OrderTimes;
public class OrderTimeRepository : IOrderTimeRepository
{
    private readonly ApplicationDbContext _db;
    public OrderTimeRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public IQueryable<OrderTime> GetAll() => _db.OrderTimes;
}
