using Microsoft.Extensions.Options;
using TinyUrl.Config;

namespace TinyUrl.Services
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        private readonly Random random = new();
        private readonly ICacheService _cacheService;
        private readonly IOptionsMonitor<TokenConfig> _tokenConfig;

        public TokenGeneratorService(ICacheService cacheService,
            IOptionsMonitor<TokenConfig> tokenConfig)
        {
            _cacheService = cacheService;
            _tokenConfig = tokenConfig;
        }

        public string GenerateUniqueToken()
        {
            var config = _tokenConfig.CurrentValue;
            var codeChars = new char[config.TokenLength];

            while (true)
            {
                for (int i = 0; i < config.TokenLength; i++)
                {
                    int rnd = random.Next(config.TokenDictionary.Length - 1);
                    codeChars[i] = config.TokenDictionary[rnd];
                }

                var token = new string(codeChars);

                if (!_cacheService.ContainsToken(token))
                {
                    return token;
                }
            }
        }
    }
}
