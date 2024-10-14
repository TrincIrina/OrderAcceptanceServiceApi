using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAcceptanceServiceApi.Model;
using OrderAcceptanceServiceApi.Repository;
using OrderAcceptanceServiceApi.Controller;

var builder = WebApplication.CreateBuilder(args);

// добавление сервисов в IoC-контейнер
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IProductInOrderRepository, ProductInOrderRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers(); // добавить контроллеры в приложение

app.Run();
