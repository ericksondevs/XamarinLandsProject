namespace LandsXamApp.ViewModels.Login
{
    using ViewModels.BaseViewModel;
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;
  
    public class LoginViewModel : ViewModelBase
    {

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string EmailorUsername
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        public bool IsRemembered { get; set; }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.EmailorUsername))
            {
                
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or username is required",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Password is required",
                    "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;
            if (!this.EmailorUsername.Equals("erick@gmail.com") || !this.Password.Equals("1234"))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                                "Error",
                                "Email/username or password incorrect.",
                                "Accept");
                this.Password = string.Empty;
                return;
            }

            this.isRunning = false;
            this.IsEnabled = true;

            this.email = string.Empty;
            this.password = string.Empty;

            MainViewModel.GetInstance().Lands = new Land.LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new Views.Land.LandPage());
        }

        public ICommand RegisterCommand { get; set; }
        #endregion
        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.isEnabled = true;

            this.EmailorUsername = "erick@gmail.com";
            this.password = "1234";
        }
        #endregion
    }
}
