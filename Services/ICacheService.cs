using System.Collections.Concurrent;
using TinyUrl.Models;

namespace TinyUrl.Services
{
    public interface ICacheService
    {
        bool ContainsToken(string token);
        bool AddNewUrl(TinyURL tinyURL);
        TinyURL DeleteUrl(string token);
        TinyURL GetUrl(string token);
        IDictionary<string, TinyURL> GetCache();
    }
}
