namespace LandsXamApp
{
	using LandsXamApp.Views.Login;
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;
	public partial class App : Application
	{
		#region Constructors
		public App ()
		{
			InitializeComponent();
            this.MainPage = new NavigationPage(new LoginPage());

        }
		#endregion
		protected override void OnStart ()
		{
			// Handle when your app starts
		}
		#region Methods
		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
		#endregion
	}
}
