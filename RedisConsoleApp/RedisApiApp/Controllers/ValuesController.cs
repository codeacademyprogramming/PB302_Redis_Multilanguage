using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using RedisApiApp.Services;
using RedisConsoleApp;

namespace RedisApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICacheService _redisService;

        public ValuesController(ICacheService redisService)
        {
            _redisService = redisService;
        }
         
        [OutputCache(Duration = 10)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));

            return Ok(new { data = _redisService.Get<Product>("pr-1").ToString() });
        }
    }
}
