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
        

        private const string getarticles = "http://m4xwe11o.ddns.net:8000/api/articles";
        private const string getadministrators = "http://m4xwe11o.ddns.net:8000/api/administrators";

        private HttpClient _client = new HttpClient();
        private ObservableCollection<Article> _articles;

        public ObservableCollection<MckbAdministrators> _administrator;

        public class MckbAdministrators
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public bool IsAuthor { get; set; }
            public bool IsLocked { get; set; }
            public bool login { get; set; }
        }

        void sendRegistration(object sender, System.EventArgs e)
        {
            GetAdministrators();
        }

        protected async void GetAdministrators()
        {
            var response = await _client.GetStringAsync(getadministrators);
            var administrators = JsonConvert.DeserializeObject<List<MckbAdministrators>>(response);
            _administrator = new ObservableCollection<MckbAdministrators>(administrators);
            for (int i = 0; i < _administrator.Count; i++)
            {
                if (username.Text == _administrator[i].Username && password.Text == _administrator[i].Password)
                {
                    _administrator[i].login = true;
                    System.Diagnostics.Debug.WriteLine("Username: " + _administrator[i].Username + " \nPassword: " + _administrator[i].Password + " \nIsAuthor: " + _administrator[i].IsAuthor + " \nIsLocked: " + _administrator[i].IsLocked + " \nLogin: " + _administrator[i].login);
                    await DisplayAlert("Info", "Login successful\nproceed on Read Tab", "OK");
                    editButton.IsEnabled = true;
                }
            }
        }


        void showAgb(object sender, System.EventArgs e)
        {
            DisplayAlert("AGB", "These are the AGB", "OK");
        }

        void editButtonClicked(object sender, System.EventArgs e)
        {
            DisplayAlert("WARN", "Edit function not implemented yet", "DISMISS");
        }

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            // Measing how long a request takes - START
            DateTime Jan1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan javaSpan = DateTime.UtcNow - Jan1970;
            var time = DateTime.Now.Millisecond.ToString();
            var time3 = DateTime.UtcNow.ToString();

            System.Diagnostics.Debug.WriteLine(javaSpan + " Sending Request");

            var content = await _client.GetStringAsync(getarticles);
            var articles = JsonConvert.DeserializeObject<List<Article>>(content);

            DateTime Jan19702 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan javaSpan2 = DateTime.UtcNow - Jan19702;
            var time2 = DateTime.Now.Millisecond.ToString();
            var time4 = DateTime.UtcNow.ToString();
            System.Diagnostics.Debug.WriteLine(javaSpan2 + " Received Request");
            // Measing how long a request takes - END

            _articles = new ObservableCollection<Article>(articles);

            IList<ArticleGroup> group = new List<ArticleGroup>();
            var groupF1 = new ArticleGroup("F1", "F1");
            var groupF3 = new ArticleGroup("F3", "F3");
            var groupF4 = new ArticleGroup("F4", "F4");

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
