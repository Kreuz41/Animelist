using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Animelist.Models.HtmlParsers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Animelist.Models.Html_Parsers.Classes
{
    internal class ShikimoryMaxPageParser : IParser<ShikimoryMaxPageParser[]>
    {
        public string maxValue;

        public ShikimoryMaxPageParser(string maxValue)
        {
            this.maxValue = maxValue;
        }

        public ShikimoryMaxPageParser()
        {

        }

        public ShikimoryMaxPageParser[] Parse(IHtmlDocument document)
        {
            //Контейнер того, что собираем
            List<ShikimoryMaxPageParser> list = new List<ShikimoryMaxPageParser>();

            //Получаем все теги типа article у которых есть класс c-anime 
            IEnumerable<IElement> items = document.QuerySelectorAll("span").
                Where(item => item.ClassName != null && item.ClassName.Contains("link-total"));



            //Заполняем контейнер list
            foreach (var item in items)
            {
                ShikimoryMaxPageParser anime = new ShikimoryMaxPageParser(item.TextContent);
                list.Add(anime);
            }

            return list.ToArray();
        }
    }
}
