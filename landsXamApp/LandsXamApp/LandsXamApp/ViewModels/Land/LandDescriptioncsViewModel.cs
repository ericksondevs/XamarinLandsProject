namespace LandsXamApp.ViewModels.Land
{
    using Models;
    public class LandDescriptioncsViewModel
    {
        #region Properties
        public Land Land
        {
            get;set;
        }
        #endregion

        #region Constructors
        public LandDescriptioncsViewModel(Land landItemViewModel)
        {
            this.Land = landItemViewModel;
        }
        #endregion
    }
}
