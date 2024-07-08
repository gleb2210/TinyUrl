using Microsoft.AspNetCore.Mvc;
using TinyUrl.Models;
using TinyUrl.Services;

namespace TinyUrl.Controllers
{
    [ApiController]
    [Route("api/cache")]
    public class CacheController : Controller
    {
        private readonly ICacheService _cacheService;

        public CacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult GetCache()
        {

            var cache = _cacheService.GetCache();

            if (cache == null)
            {
                return NotFound();
                
            }

            return Ok(cache.Values.ToList());
        }
    }
}
