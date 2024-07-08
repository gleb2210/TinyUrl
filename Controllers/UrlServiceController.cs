using Microsoft.AspNetCore.Mvc;
using TinyUrl.Models;
using TinyUrl.Services;

namespace TinyUrl.Controllers
{
    [ApiController]
    [Route("api/urlservice")]
    public class UrlServiceController : Controller
    {
        private readonly IUrlService _urlService;
        private readonly ICacheService _cacheService;

        public UrlServiceController(
            IUrlService urlService,
            ICacheService cacheService)
        {
            _urlService = urlService;
            _cacheService = cacheService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTinyUrl(UrlRequest req)
        {
            var context = HttpContext;

            //try to create a URL to make sure its valid and can be parsed
            if (!Uri.TryCreate(req.Url, UriKind.Absolute, out _))
            {
                return BadRequest("Bad URL");
            }

            var token = _urlService.CreateTinyUrl();
            var shortUrl = $"{context.Request.Scheme}://{context.Request.Host}/api/{ControllerContext.RouteData.Values["controller"]}/{token}";

            var tinyUrl = new TinyURL
            {
                Id = Guid.NewGuid(),
                Url = req.Url,
                ShortUrl = shortUrl,
                Token = token,
                Clicked = 0
            };

            if (!_urlService.SaveUrl(tinyUrl))
            {
                return BadRequest("Unable to create a short url");
            }

            return Ok(tinyUrl);
        }

        [HttpGet("{token}")]
        public ActionResult RedirectToLongUrl(string token)
        {

            var shortUrl = _cacheService.GetUrl(token);

            if (shortUrl == null)
            {
                return NotFound();
            }

            return Redirect(shortUrl.Url);
        }

        [HttpDelete("{token}")]
        public ActionResult DeleteUrl(string token)
        {
            var shortUrl = _cacheService.GetUrl(token);

            if (shortUrl == null)
            {
                return NotFound();
            }

            var deletedUrl = _urlService.DeleteUrl(token);
            if (deletedUrl == null)
            {
                Results.BadRequest("Unable to delete");
            }

            return Ok(deletedUrl);
        }
    }
}
