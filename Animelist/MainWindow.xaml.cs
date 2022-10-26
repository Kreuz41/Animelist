using Animelist.Models.HtmlParsers;
using Animelist.Models.HtmlParsers.Classes;
using System.Windows;
using Animelist.Models.Html_Parsers.Classes;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Collections.Generic;

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

        ParserWorker<ShikimoriAnimeListParser[]> parser;

        private void ButtonGoToAnimeList_Click(object sender, RoutedEventArgs e)
        {

            parser = new ParserWorker<ShikimoriAnimeListParser[]>(new ShikimoriAnimeListParser());

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;

            parser.ParserSettings = new ShikimoriAnimeListParserSettings(1, 3);
            parser.Start();
        }
    }
}
