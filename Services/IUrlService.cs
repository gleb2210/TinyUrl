using TinyUrl.Models;

namespace TinyUrl.Services
{
    public interface IUrlService
    {
        string CreateTinyUrl();
        bool SaveUrl(TinyURL url);
        TinyURL DeleteUrl(string token);
    }
}
