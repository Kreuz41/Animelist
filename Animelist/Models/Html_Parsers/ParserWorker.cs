using AngleSharp.Html.Parser;
using Animelist.Models.HtmlParsers.Classes;
using Animelist.Models.HtmlParsers.Interfaces;
using AngleSharp.Html.Dom;
using System;

namespace Animelist.Models.HtmlParsers
{
    internal class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;

        HtmlLoader loader;
        bool isActive;
        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }
        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }
        public IParserSettings ParserSettings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        public event Action<object, T> OnNewData; // Событие на добавление данных
        public event Action<object> OnCompleted; // Событие на завершение

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public void Start()
        {
            isActive = true;
            Worker();
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void Worker()
        {
            for(int i = parserSettings.StartPoint; i < parserSettings.EndPoint; i++)
            {
                if(!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }
                string source = await loader.GetSourceByPageId(i);
                HtmlParser domParser = new HtmlParser();
                IHtmlDocument document = await domParser.ParseDocumentAsync(source);
                T result = parser.Parse(document);
                OnNewData?.Invoke(this, result);
            }


            OnCompleted?.Invoke(this);
            isActive = false;
        }
    }
}
