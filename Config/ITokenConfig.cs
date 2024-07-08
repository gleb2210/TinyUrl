namespace TinyUrl.Config
{
    public interface ITokenConfig
    {
        public int TokenLength { get; set; }
        public string TokenDictionary { get; set; }
    }
}
