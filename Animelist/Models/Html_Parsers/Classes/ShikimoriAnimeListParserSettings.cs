using Animelist.Models.HtmlParsers.Interfaces;

namespace Animelist.Models.HtmlParsers.Classes
{
    internal class ShikimoriAnimeListParserSettings : IParserSettings
    {
        public ShikimoriAnimeListParserSettings(int startPoint, int endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
        public string BaseUrl { get; set; } = "https://shikimori.one/animes";
        public string Prefix { get; set; } = "page/{CurrentId}"; 
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
