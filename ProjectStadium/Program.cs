using BLL.Services.Account;
using BLL.Services.Orders;
using BLL.Services.OrderTimes;
using BLL.Services.Stadiums;
using DAL;
using Microsoft.EntityFrameworkCore;
using ProjectStadium;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.InitializeRepositories();
builder.Services.InitializeServices();

builder.Services.AddHttpClient();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseInMemoryDatabase("TEST"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
