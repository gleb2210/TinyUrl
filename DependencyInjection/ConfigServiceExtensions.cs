using Microsoft.Extensions.Options;
using TinyUrl.Config;

namespace TinyUrl.DependencyInjection
{
    public static class ConfigServiceExtensions
    {
        
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<TokenConfig>(config.GetSection("TokenConfig"));

            services.AddSingleton<ITokenConfig>(sp =>
                sp.GetRequiredService<IOptions<TokenConfig>>().Value);

            return services;
        }
    }
}
