using Domain.Response;
using Domain.ViewModels.Auth;
using System.Security.Claims;

namespace BLL.Services.Account;

public interface IAccountService
{
    Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

    Task<BaseResponse<ClaimsIdentity>> Login(LogInViewModel model);

    Task<BaseResponse<bool>> ChangePassword(ChangePassViewModel model);
}
