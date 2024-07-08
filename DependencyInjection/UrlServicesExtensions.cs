using Microsoft.Extensions.DependencyInjection.Extensions;
using TinyUrl.Services;

namespace TinyUrl.DependencyInjection;

public static class UrlServicesExtensions
{
    public static IServiceCollection AddTinyUrlServices(this IServiceCollection services)
    {
        services.TryAddSingleton<ITokenGeneratorService, TokenGeneratorService>();
        services.TryAddSingleton<ICacheService, CacheService>();
        services.TryAddSingleton<IUrlService, UrlService>();

        return services;
    }
}

