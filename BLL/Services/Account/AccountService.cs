using DAL.Repositories;
using Domain.Entity;
using Domain.Enum;
using Domain.Enums;
using Domain.Helpers;
using Domain.Response;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Domain.ViewModels.Auth;

namespace BLL.Services.Account;
public class AccountService : IAccountService
{
    private readonly IBaseRepository<User> _userRepository;
    private readonly ILogger<AccountService> _logger;

    public AccountService(IBaseRepository<User> userRepository,
        ILogger<AccountService> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
    {
        try
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
            if (user != null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь с таким логином уже есть",
                };
            }

            user = new User()
            {
                Name = model.Name,
                Role = Role.User,
                Password = HashPasswordHelper.HashPassowrd(model.Password),
            };

            await _userRepository.Create(user);
            var result = Authenticate(user);

            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                Description = "Объект добавился",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[Register]: {ex.Message}");
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<BaseResponse<ClaimsIdentity>> Login(LogInViewModel model)
    {
        try
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
            if (user == null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь не найден"
                };
            }

            if (user.Password != HashPasswordHelper.HashPassowrd(model.Password))
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Неверный пароль или логин"
                };
            }
            var result = Authenticate(user);

            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[Login]: {ex.Message}");
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<BaseResponse<bool>> ChangePassword(ChangePassViewModel model)
    {
        try
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.UserName);
            if (user == null)
            {
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.UserNotFound,
                    Description = "Пользователь не найден"
                };
            }

            user.Password = HashPasswordHelper.HashPassowrd(model.NewPassword);
            await _userRepository.Update(user);

            return new BaseResponse<bool>()
            {
                Data = true,
                StatusCode = StatusCode.OK,
                Description = "Пароль обновлен"
            };

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[ChangePassword]: {ex.Message}");
            return new BaseResponse<bool>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    private ClaimsIdentity Authenticate(User user)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
        return new ClaimsIdentity(claims, "ApplicationCookie",
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
    }


}