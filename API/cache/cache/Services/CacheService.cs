using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace cache.Services
{
    public class CacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IDatabase _redisDatabase;

        public CacheService(IMemoryCache memoryCache, IConnectionMultiplexer redisConnection)
        {
            _memoryCache = memoryCache;
            _redisDatabase = redisConnection.GetDatabase();
        }

        // Categories (MemoryCache)
        public void CacheCategories(List<string> categories, TimeSpan expirationTime)
        {
            _memoryCache.Set("categories", categories, expirationTime);
        }

        public List<string> GetCategories()
        {
            return _memoryCache.TryGetValue("categories", out List<string> categories) ? categories : null;
        }

        // Products (Redis)
        public async Task CacheProductListAsync(List<string> products, TimeSpan expirationTime)
        {
            string serializedProducts = JsonSerializer.Serialize(products);
            await _redisDatabase.StringSetAsync("productList", serializedProducts, expirationTime);
        }

        public async Task<List<string>> GetProductListAsync()
        {
            string serializedProducts = await _redisDatabase.StringGetAsync("productList");
            return serializedProducts != null ? JsonSerializer.Deserialize<List<string>>(serializedProducts) : null;
        }

        // Shipper Info (Redis)
        public async Task CacheShipperInfoAsync(Dictionary<string, string> shipperInfo, TimeSpan expirationTime)
        {
            string serializedShipperInfo = JsonSerializer.Serialize(shipperInfo);
            await _redisDatabase.StringSetAsync("shipperInfo", serializedShipperInfo, expirationTime);
        }

        public async Task<Dictionary<string, string>> GetShipperInfoAsync()
        {
            string serializedShipperInfo = await _redisDatabase.StringGetAsync("shipperInfo");
            return serializedShipperInfo != null
                ? JsonSerializer.Deserialize<Dictionary<string, string>>(serializedShipperInfo)
                : null;
        }
    }
}
