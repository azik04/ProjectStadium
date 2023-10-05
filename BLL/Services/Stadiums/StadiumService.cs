using DAL.Repositories.Stadiums;
using Domain.Entity;
using Domain.Enums;
using Domain.Response;
using Domain.ViewModels.Stadiums;

namespace BLL.Services.Stadiums;
public class StadiumService : IStadiumService
{
    private readonly IStadiumRepository _repository;
    public StadiumService(IStadiumRepository repository)
    {
        _repository = repository;
    }

    public async Task<IBaseResponse<Stadium>> CreateAsync(CreateStadiumViewModel model)
    {
        try
        {
            var stadium = new Stadium()
            {
                StadiumAdress = model.StadiumAdress,
                StadiumName = model.StadiumName,
            };
            await _repository.Create(stadium);
            return new BaseResponse<Stadium>()
            {
                Data = stadium,
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<Stadium>()
            {
                Description = $"[CreateAsync] {ex.Message}",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
    }
    public IBaseResponse<List<Stadium>> GetAll()
    {
        try
        {
            var stadium = _repository.GetAll().ToList();
            _repository.GetAll();
            return new BaseResponse<List<Stadium>>()
            {
                Data = stadium,
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        catch(Exception ex)
        {
            return new BaseResponse<List<Stadium>>()
            {
                Description = $"[GetAll] {ex.Message}",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
    }    
    public async Task<IBaseResponse<Stadium>> DeleteAsync(long id)
    {
        try
        {
            var stadium = _repository.GetAll().SingleOrDefault(x => x.Id == id);
            await _repository.Delete(stadium);
            return new BaseResponse<Stadium>
            {
                Data = stadium,
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        catch(Exception ex)
        {
            return new BaseResponse<Stadium>
            {
                Description = $"[GetAll] {ex.Message}",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
    }

    public async Task<IBaseResponse<Stadium>> GetByName(string name)
    {
        try
        {
            var stadium = _repository.GetAll().SingleOrDefault(x => x.StadiumName == name);
            if (stadium == null)
            {
                return new BaseResponse<Stadium>()
                {
                    Description = "Стадион не найден",
                    StatusCode = StatusCode.StadiumNotFound,
                };
            }
            return new BaseResponse<Stadium>()
            {
                StatusCode = StatusCode.OK,
                Data = stadium
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<Stadium>()
            {
                Description = $"[GetCar] : {ex.Message}",
                StatusCode = StatusCode.Error
            };
        }
    }
}
