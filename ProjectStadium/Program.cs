using BLL.Services.Orders;
using BLL.Services.OrderTimes;
using BLL.Services.Stadiums;
using DAL.Repositories.Orders;
using DAL.Repositories.OrderTimes;
using DAL.Repositories.Stadiums;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IStadiumRepository, StadiumRepository>();
builder.Services.AddScoped<IStadiumService, StadiumService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderTimeRepository, OrderTimeRepository>();
builder.Services.AddScoped<IOrderTimeService, OrderTimeService>();   
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
