using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;
using StockAppWebApi.Repository;
using StockAppWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//  thiết lập StockAppContext khi khởi chạy app
var setting = builder.Configuration.GetRequiredSection("ConnectionStrings");
builder.Services.AddDbContext<StockAppContext>(options =>
{
    options.UseSqlServer(setting["DefaultConnection"]);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

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
