using AngleSharp.Html.Dom;

namespace Animelist.Models.HtmlParsers.Interfaces
{
    internal interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document); // Сам парсинг
    }
}
