namespace DAL.Repositories;
public interface IBaseRepository<T>
{
    Task<bool> Create(T entity);
    IQueryable<T> GetAll();
    Task<T> Update(T entity);
    Task<bool> Delete(T entity);
}
