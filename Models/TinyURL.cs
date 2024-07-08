namespace TinyUrl.Models
{
    public class TinyURL
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public int Clicked { get; set; } = 0;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}