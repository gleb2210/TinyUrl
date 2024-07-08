using System.Collections.Concurrent;
using TinyUrl.Models;

namespace TinyUrl.Services
{
    public class CacheService : ICacheService
    {
        //in the real world this would be some form of a distributed cache such as Redis
        private ConcurrentDictionary<string, TinyURL> _cache = new();

        public bool ContainsToken(string token)
        {
            return _cache.ContainsKey(token);
        }

        public bool AddNewUrl(TinyURL tinyURL)
        {
            if (!_cache.TryAdd(tinyURL.Token, tinyURL))
                return false;
            return true;
        }

        public TinyURL DeleteUrl(string token)
        {
            if(token == null) return null;

            if (!_cache.TryRemove(token, out TinyURL url))
                return null;

            return url;
        }

        public TinyURL GetUrl(string token)
        {
            _cache.TryGetValue(token, out TinyURL tinyUrl);

            if (tinyUrl != null)
            {
                tinyUrl.Clicked++;
            }

            return tinyUrl;
        }

        public IDictionary<string, TinyURL> GetCache()
        {
            return _cache;
        }
    }
}
