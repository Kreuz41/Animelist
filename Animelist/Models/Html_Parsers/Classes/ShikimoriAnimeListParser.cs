using AngleSharp.Html.Dom;
using Animelist.Models.HtmlParsers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Animelist.Models.HtmlParsers.Classes
{
    internal class ShikimoriAnimeListParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            //Контейнер того, что собираем
            List<string> list = new List<string>();

            //Получаем все теги типа article у которых есть класс c-anime 
            IEnumerable<AngleSharp.Dom.IElement> items = document.QuerySelectorAll("article").
                Where(item => item.ClassName != null && item.ClassName.Contains("c-anime"));

            //Заполняем контейнер list
            foreach(var item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}
