using Xamarin.Forms;

namespace MCKB
{
    public partial class App : Application
    {
        public App()
        {
            System.Diagnostics.Debug.WriteLine("Calling App");
            InitializeComponent();

            //MainPage = new MCKBPage();
            MainPage = new MainPage();
            //MainPage = new ArticlePage();
        }

        protected override void OnStart()
        {
            System.Diagnostics.Debug.WriteLine("Calling OnStart");
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            System.Diagnostics.Debug.WriteLine("Calling OnSleep");
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            System.Diagnostics.Debug.WriteLine("Calling OnResume");
            // Handle when your app resumes
        }
    }
}
