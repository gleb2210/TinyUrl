namespace TinyUrl.Config
{
    public class TokenConfig : ITokenConfig
    {
        public int TokenLength { get; set; }
        public string TokenDictionary { get; set; }
    }
}
