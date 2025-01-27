using cache.Services;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(
    builder.Configuration.GetSection("RedisCacheSettings:ConnectionString").Value));

builder.Services.AddSingleton<CacheService>();

var app = builder.Build();

app.MapControllers();
app.Run();
