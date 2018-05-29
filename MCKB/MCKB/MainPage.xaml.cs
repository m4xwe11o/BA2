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
            var time = DateTime.Now.Millisecond.ToString();
            var time3 = DateTime.UtcNow.ToString();
            IList<ArticleGroup> group = new List<ArticleGroup>();
            var groupF1 = new ArticleGroup("F1", "F1");
            var groupF3 = new ArticleGroup("F3", "F3");
            var groupF4 = new ArticleGroup("F4", "F4");

            System.Diagnostics.Debug.WriteLine(time3 + " Sending Request");

            var content = await _client.GetStringAsync(Url);
            var articles = JsonConvert.DeserializeObject<List<Article>>(content);

            var time2 = DateTime.Now.Millisecond.ToString();
            var time4 = DateTime.UtcNow.ToString();
            System.Diagnostics.Debug.WriteLine(time4 + " Received Request");

            _articles = new ObservableCollection<Article>(articles);

            for (int i = 0; i < _articles.Count; i++)
            {
                if (_articles[i].Title.Contains("F1") && ( _articles[i].Title.Contains("ADC") || _articles[i].Title.Contains("CAN") || _articles[i].Title.Contains("SPI") || _articles[i].Title.Contains("UART")))
                {
                    groupF1.Add(
                        new Article { Title = _articles[i].Title, Description = _articles[i].Description, Articletext = _articles[i].Articletext, ImageUrl = "https://png.icons8.com/ios/50/000000/electronics-filled.png" }
                    );
                }

                if (_articles[i].Title.Contains("F3") && (_articles[i].Title.Contains("ADC") || _articles[i].Title.Contains("CAN") || _articles[i].Title.Contains("SPI") || _articles[i].Title.Contains("UART")))
                {
                    groupF3.Add(
                        new Article { Title = _articles[i].Title, Description = _articles[i].Description, Articletext = _articles[i].Articletext, ImageUrl = "https://png.icons8.com/color/50/000000/electronics.png" }
                    );
                }

                if (_articles[i].Title.Contains("F4") && (_articles[i].Title.Contains("ADC") || _articles[i].Title.Contains("CAN") || _articles[i].Title.Contains("SPI") || _articles[i].Title.Contains("UART")))
                {
                    groupF4.Add(
                        new Article { Title = _articles[i].Title, Description = _articles[i].Description, Articletext = _articles[i].Articletext, ImageUrl = "https://png.icons8.com/ultraviolet/50/000000/electronics.png" }
                    );
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
