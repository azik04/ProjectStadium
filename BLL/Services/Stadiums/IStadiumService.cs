using Domain.Entity;
using Domain.Response;
using Domain.ViewModels.Stadiums;

namespace BLL.Services.Stadiums;
public interface IStadiumService
{
    Task<IBaseResponse<Stadium>> CreateAsync(CreateStadiumViewModel model);
    IBaseResponse<List<Stadium>> GetAll();
    Task<IBaseResponse<Stadium>> GetByName(string name);
    Task<IBaseResponse<Stadium>> DeleteAsync(long id);
}
