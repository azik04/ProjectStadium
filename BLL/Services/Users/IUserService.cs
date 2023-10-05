using Domain.Entity;
using Domain.Response;
using Domain.ViewModels.Users;

namespace BLL.Services.Users;

public interface IUserService
{
    Task<IBaseResponse<User>> Create(UserViewModel model);

    BaseResponse<Dictionary<int, string>> GetRoles();

    Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();

    Task<IBaseResponse<bool>> DeleteUser(long id);
}
