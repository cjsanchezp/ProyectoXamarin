using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TodoApp
{
	public partial class App : Application
	{
        private static TodoDatabase database;

        public static TodoDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoDatabase();
                }
                return database;
            }
        }
        
		public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new CreatePage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
