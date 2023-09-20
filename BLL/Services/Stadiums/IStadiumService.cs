using Domain.Entity;
using Domain.Response;
using Domain.ViewModels.Stadiums;

namespace BLL.Services.Stadiums;
public interface IStadiumService
{
    Task<IBaseResponse<Stadium>> CreateAsync(CreateStadiumViewModel model);
    IBaseResponse<List<Stadium>> GetAll();
    Task<IBaseResponse<Stadium>> UpdateAsync(UpdateStadiumViewModel model, long id);
    Task<IBaseResponse<Stadium>> DeleteAsync(long id);
}
