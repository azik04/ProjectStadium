using Domain.Entity;

namespace DAL.Repositories.Stadiums;
public interface IStadiumRepository : IBaseRepository<Stadium>
{
    IQueryable<Stadium> GetByName(long id);
}
