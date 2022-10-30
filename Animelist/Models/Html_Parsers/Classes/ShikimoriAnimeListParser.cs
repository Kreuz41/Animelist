using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Animelist.Models.HtmlParsers.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Animelist.Models.Html_Parsers.Classes
{
    internal class ShikimoriAnimeListParser : IParser<ShikimoriAnimeListParser[]>
    {
        public string imagePath { get; set; }
        public string russianTitle { get; set; }
        public string englishTitle { get; set; }
        public string animeType { get; set; }
        public string yearOfARealise { get; set; }

        public ShikimoriAnimeListParser()
        {
              
        }
        public ShikimoriAnimeListParser(IElement element)
        {
            imagePath = GetImagePath(element);
            englishTitle = GetEnName(element);
            russianTitle = GetRuName(element);
            animeType = GetTitleType(element);
            yearOfARealise = GetYear(element);

        }
        /*
         * Метод, который возвращает русское имя
         */
        private string GetRuName(IElement element)
        {
            string ruName = element.Children[0].Children[1].Children[1].TextContent;

            return ruName;
        }

        /*
         * Метод, который возвращает год тайтла
         */
        private string GetYear(IElement element)
        {
            string year = element.Children[0].Children[2].Children[0].TextContent;

            return year;
        }

        /*
         * Метод, который возвращает тип тайтла
         */
        private string GetTitleType(IElement element)
        {
            string type = element.Children[0].Children[2].Children[1].TextContent;

            return type;
        }

        /*
         * Метод, который возвращает инглиш имя
         */
        private string GetEnName(IElement element)
        {
             string enName = element.Children[0].Children[1].Children[0].TextContent;

            return enName;
        }

        /*
         * Метод, который возвращает все дочерние элементы конкретного элемента
         */
        private IEnumerable GetChildren(IElement element)
        {
            IEnumerable children = element.Children;

            return children;
        }

        /*
         * Метод, который возвращает путь к изображению
         */
        private string GetImagePath(IElement element)
        {
            string path = element.Children[0].Children[0].Children[0].OuterHtml.ToString();
            char[] chars = path.ToCharArray();
            path = "";
            string src = "";
            for(int i = 0; i < chars.Length; i++)
            {
                if (src == "src")
                {
                    path += chars[i];
                    if (chars[i] == ' ')
                    {
                        break;
                    }
                    continue;
                }
                src += char.ToString(chars[i]);
                if (chars[i] == ' ')
                {
                    src = "";
                    continue;
                }
            }
            char[] chars2 = path.ToCharArray();
            path = "";
            for (int i = 2; i < chars2.Length - 2; i++)
                path += chars2[i].ToString();

            return path;
        }

        public ShikimoriAnimeListParser[] Parse(IHtmlDocument document)
        {
            //Контейнер того, что собираем
            List<ShikimoriAnimeListParser> list = new List<ShikimoriAnimeListParser>();

            //Получаем все теги типа article у которых есть класс c-anime 
            IEnumerable<IElement> items = document.QuerySelectorAll("article").
                Where(item => item.ClassName != null && item.ClassName.Contains("c-anime"));



            //Заполняем контейнер list
            foreach (var item in items)
            {
                ShikimoriAnimeListParser anime = new ShikimoriAnimeListParser(item);
                list.Add(anime);
            }

            return list.ToArray();
        }
    }
}
