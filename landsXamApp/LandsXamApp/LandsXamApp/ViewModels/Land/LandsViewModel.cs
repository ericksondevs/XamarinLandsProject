namespace LandsXamApp.ViewModels.Land
{
    using System;
    using Models;
    using System.Collections.ObjectModel;
    using LandsXamApp.ViewModels.BaseViewModel;
    using LandsXamApp.Services;
    using Xamarin.Forms;
    using System.Collections.Generic;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using System.Linq;

    public class LandsViewModel : ViewModelBase
    {
        #region Services
        private ApiService apiService;
        #endregion
        #region Attributes
        private ObservableCollection<Land> lands;
        private bool isRefreshing;
        private string filter;
        private List<Land> landsList;
        #endregion

        #region Properties
        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        public string Filter
        {
            get { return this.filter; }
            set {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion
        #region Constructor
        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }
        #endregion

        #region Methods
        private async void LoadLands()
        {
            this.IsRefreshing = true;
            var response = await this.apiService.GetList<Land>("https://restcountries.eu", "/rest", "/v2/all");
            
            if(response.IsSuccess)
            {
                this.landsList = (List<Land>)response.Result;
                this.Lands = new ObservableCollection<Land>(this.landsList);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
            }
            this.IsRefreshing = false;
        }
        private void Search()
        {
            if (string.IsNullOrWhiteSpace(this.Filter))
            {
                this.Lands = new ObservableCollection<Land>(this.landsList);
            }
            else
            {
                this.Lands = new ObservableCollection<Land>(this.landsList.Where(x => x.Name.ToLower().Contains(this.Filter.ToLower()) ||
                x.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion

        #region commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLands);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }
        #endregion
    }
}
