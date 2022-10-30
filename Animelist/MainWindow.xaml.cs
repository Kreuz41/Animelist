using Animelist.Models.HtmlParsers;
using Animelist.Models.HtmlParsers.Classes;
using System.Windows;
using Animelist.Models.Html_Parsers.Classes;
using System.Collections.Generic;
using System.Windows.Input;

namespace Animelist
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        List<ShikimoriAnimeListParser> titles = new List<ShikimoriAnimeListParser>();

        private void Parser_OnNewData(object arg1, ShikimoriAnimeListParser[] arg2)
        {
            titles.AddRange(arg2);
            MainList.ItemsSource = titles;
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Ok");
        }

        ParserWorker<ShikimoriAnimeListParser[]> firstTitlesPageParser;
        ParserWorker<ShikimoryMaxPageParser[]> maxPageParser;

        private void ButtonGoToAnimeList_Click(object sender, RoutedEventArgs e)
        {

            firstTitlesPageParser = new ParserWorker<ShikimoriAnimeListParser[]>(new ShikimoriAnimeListParser());

            firstTitlesPageParser.OnCompleted += Parser_OnCompleted;
            firstTitlesPageParser.OnNewData += Parser_OnNewData;

            firstTitlesPageParser.ParserSettings = new ShikimoriAnimeListParserSettings(1, 2);
            firstTitlesPageParser.Start();

            maxPageParser = new ParserWorker<ShikimoryMaxPageParser[]>(new ShikimoryMaxPageParser());
            maxPageParser.ParserSettings = new ShikimoriAnimeListParserSettings(1, 2);

            maxPageParser.OnCompleted += Parser_OnCompleted;
            maxPageParser.OnNewData += Pars_OnNewData;
            maxPageParser.Start();
        }

        private void Pars_OnNewData(object arg1, ShikimoryMaxPageParser[] arg2)
        {
            MaxPageLb.Content = arg2[0].maxValue;
        }

        private void BackLb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void NextLb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
