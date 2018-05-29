using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MCKB
{
    public partial class MainPage : TabbedPage
    {
        private const string Url = "http://m4xwe11o.ddns.net:8000/api/articles";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Article> _articles;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {

            IList<ArticleGroup> group = new List<ArticleGroup>();
            var groupF1 = new ArticleGroup("F1", "F1");
            var groupF3 = new ArticleGroup("F3", "F3");
            var groupF4 = new ArticleGroup("F4", "F4");

            var content = await _client.GetStringAsync(Url);
            var articles = JsonConvert.DeserializeObject<List<Article>>(content);
            _articles = new ObservableCollection<Article>(articles);

            for (int i = 0; i < _articles.Count; i++)
            {
                if (_articles[i].Title.Contains("F1") && (_articles[i].Title.Contains("ADC") || _articles[i].Title.Contains("CAN") || _articles[i].Title.Contains("SPI") || _articles[i].Title.Contains("UART")))
                {
                    System.Diagnostics.Debug.WriteLine("Adding " + _articles[i].Title + " to Article Group F1");
                    groupF1.Add(
                        new Article { Title = _articles[i].Title, Description = _articles[i].Description, Articletext = _articles[i].Articletext, ImageUrl = "https://png.icons8.com/ios/50/000000/electronics-filled" }
                    );
                    System.Diagnostics.Debug.WriteLine(groupF1.Count);
                }

                if (_articles[i].Title.Contains("F3") && (_articles[i].Title.Contains("ADC") || _articles[i].Title.Contains("CAN") || _articles[i].Title.Contains("SPI") || _articles[i].Title.Contains("UART")))
                {
                    System.Diagnostics.Debug.WriteLine("Adding " + _articles[i].Title + " to Article Group F1");
                    groupF3.Add(
                        new Article { Title = _articles[i].Title, Description = _articles[i].Description, Articletext = _articles[i].Articletext, ImageUrl = "https://png.icons8.com/color/50/000000/electronics" }
                    );
                    System.Diagnostics.Debug.WriteLine(groupF3.Count);
                }

                if (_articles[i].Title.Contains("F4") && (_articles[i].Title.Contains("ADC") || _articles[i].Title.Contains("CAN") || _articles[i].Title.Contains("SPI") || _articles[i].Title.Contains("UART")))
                {
                    System.Diagnostics.Debug.WriteLine("Adding " + _articles[i].Title + " to Article Group F1");
                    groupF4.Add(
                        new Article { Title = _articles[i].Title, Description = _articles[i].Description, Articletext = _articles[i].Articletext, ImageUrl = "https://png.icons8.com/ultraviolet/50/000000/electronics" }
                    );
                    System.Diagnostics.Debug.WriteLine(groupF4.Count);
                }

            }
            group.Add(groupF1);
            group.Add(groupF3);
            group.Add(groupF4);

            articleListView.ItemsSource = group;

            base.OnAppearing();
        }
    }
}
