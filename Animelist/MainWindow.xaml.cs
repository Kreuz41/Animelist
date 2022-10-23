using Animelist.Models.HtmlParsers;
using Animelist.Models.HtmlParsers.Classes;
using System.Windows;
using System.Collections;

namespace Animelist
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(new ShikimoriAnimeListParser());

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            MainListBox.ItemsSource = arg2;
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Ok");
        }

        ParserWorker<string[]> parser;

        private void ButtonGoToAnimeList_Click(object sender, RoutedEventArgs e)
        {
            parser.ParserSettings = new ShikimoriAnimeListParserSettings(1, 2);
            parser.Start();
        }
    }
}
