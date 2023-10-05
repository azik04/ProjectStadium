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
        await _db.SaveChangesAsync();
        return true;
    }
    public IQueryable<Stadium> GetAll() => _db.Stadiums;
    public async Task<Stadium> Update(Stadium entity)
    {
        _db.Stadiums.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
    public async Task<bool> Delete(Stadium entity)
    {
        _db.Stadiums.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

}
