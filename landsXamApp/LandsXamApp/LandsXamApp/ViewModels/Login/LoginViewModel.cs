namespace LandsXamApp.ViewModels.Login
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    public class LoginViewModel
    {
        #region Properties
        public string EmailorUsername { get; set; }
        public string Password { get; set; }
        public bool IsRunning { get; set; }
        public bool IsRemembered { get; set; }
        #endregion

        #region Commands
        public ICommand LoginCommand {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private void Login()
        {
            throw new NotImplementedException();
        }

        public ICommand RegisterCommand { get; set; }
        #endregion
        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.EmailorUsername = "Funciona esta mierda";
        }
        #endregion

    }
}
