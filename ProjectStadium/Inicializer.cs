using BLL.Services.Account;
using BLL.Services.Orders;
using BLL.Services.OrderTimes;
using BLL.Services.Stadiums;
using BLL.Services.Users;
using DAL.Repositories.Orders;
using DAL.Repositories.OrderTimes;
using DAL.Repositories.Stadiums;
using DAL.Repositories.Users;

namespace ProjectStadium
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStadiumRepository, StadiumRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderTimeRepository, OrderTimeRepository>();

        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IStadiumService, StadiumService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IOrderTimeService, OrderTimeService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
