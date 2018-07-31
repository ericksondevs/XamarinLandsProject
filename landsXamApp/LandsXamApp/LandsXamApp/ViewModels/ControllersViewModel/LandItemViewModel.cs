namespace LandsXamApp.ViewModels.ControllersViewModel
{
    using GalaSoft.MvvmLight.Command;
    using LandsXamApp.ViewModels.Land;
    using LandsXamApp.Views.Land;
    using Models;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LandItemViewModel : Land
    {
        #region Commands
        public ICommand SelectLandCommand
        {
            get
            {
                return new RelayCommand(SelectLand);
            }
        }
        #endregion
        private async void SelectLand()
        {
            MainViewModel.GetInstance().Land = new LandDescriptioncsViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandDescription());
        }
    }
}
