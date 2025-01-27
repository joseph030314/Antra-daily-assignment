using cache.Services;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CacheController : ControllerBase
    {
        private readonly CacheService _cacheService;

        public CacheController(CacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpPost("cache-categories")]
        public IActionResult CacheCategories([FromBody] List<string> categories)
        {
            _cacheService.CacheCategories(categories, TimeSpan.FromMinutes(30));
            return Ok("Categories cached successfully.");
        }

        [HttpGet("get-categories")]
        public IActionResult GetCategories()
        {
            var categories = _cacheService.GetCategories();
            return Ok(categories ?? new List<string>());
        }

        [HttpPost("cache-products")]
        public async Task<IActionResult> CacheProducts([FromBody] List<string> products)
        {
            await _cacheService.CacheProductListAsync(products, TimeSpan.FromMinutes(60));
            return Ok("Products cached successfully.");
        }

        [HttpGet("get-products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _cacheService.GetProductListAsync();
            return Ok(products ?? new List<string>());
        }

        [HttpPost("cache-shipper-info")]
        public async Task<IActionResult> CacheShipperInfo([FromBody] Dictionary<string, string> shipperInfo)
        {
            await _cacheService.CacheShipperInfoAsync(shipperInfo, TimeSpan.FromHours(1));
            return Ok("Shipper info cached successfully.");
        }

        [HttpGet("get-shipper-info")]
        public async Task<IActionResult> GetShipperInfo()
        {
            var shipperInfo = await _cacheService.GetShipperInfoAsync();
            return Ok(shipperInfo ?? new Dictionary<string, string>());
        }
    }
}
