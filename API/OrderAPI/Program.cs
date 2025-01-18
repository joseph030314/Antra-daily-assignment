using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.IRepositories;
using Order.ApplicationCore.Contracts.IServices;
using Order.Infrastructure.Data;
using Order.Infrastructure.Repositories;
using Order.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("OrderDb2025JAN"));
});

builder.Services.AddAutoMapper(typeof(Program));

// Service injection
builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddScoped<IOrderDetailRepositoryAsync, OrderDetailRepositoryAsync>();

// Repository injection
builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
