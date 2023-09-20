using Domain.Entity;

namespace DAL.Repositories.Stadiums;
public class StadiumRepository : IStadiumRepository
{
    private readonly ApplicationDbContext _db;
    public StadiumRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Stadium entity)
    {
        await _db.Stadiums.AddAsync(entity);
        await _db.AddAsync(entity);
        return true;
    }
    public IQueryable<Stadium> GetAll() => _db.Stadiums;
    public async Task<Stadium> Update(Stadium entity)
    {
        _db.Stadiums.Update(entity);
        await _db.AddAsync(entity);
        return entity;
    }
    public async Task<bool> Delete(Stadium entity)
    {
        _db.Stadiums.Remove(entity);
        await _db.AddAsync(entity);
        return true;
    }

    public IQueryable<Stadium> GetByName(long id)
    {
        return _db.Stadiums.FirstOrDefault(x => x.Id == id);
    }
}
