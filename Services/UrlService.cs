using TinyUrl.Models;

namespace TinyUrl.Services
{
    public class UrlService : IUrlService
    {
        ITokenGeneratorService _tokenGenService;
        ICacheService _cacheService;

        public UrlService(
            ITokenGeneratorService tokenGenService,
            ICacheService cacheService
            ) 
        {
            _tokenGenService = tokenGenService;
            _cacheService = cacheService;
        }

        public string CreateTinyUrl()
        {
            var token = _tokenGenService.GenerateUniqueToken();
            return token;
        }

        public bool SaveUrl(TinyURL url)
        {
            if(url == null) return false;

            if (_cacheService.ContainsToken(url.Token)) return false;

            if(!_cacheService.AddNewUrl(url))
                return false;

            return true;
        }

        public TinyURL DeleteUrl(string token)
        {
            if (token == null) return null;

            return _cacheService.DeleteUrl(token);
        }
    }
}
