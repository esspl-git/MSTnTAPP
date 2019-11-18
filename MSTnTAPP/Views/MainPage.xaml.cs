using MSTnTAPP.Helpers;
using MSTnTAPP.Models.BindableModels;
using MSTnTAPP.Util;
using MSTnTAPP.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        #region Variables
        protected readonly IAuthHelper authHelper;
        protected MainViewModel viewModel;
        #endregion

        #region Constructor
        //For New Instance
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainViewModel();
        }

        //For Notifiaction Tapped From Sys.Trey
        public MainPage(ShipmentModelView s)
        {
            if (!B2CConstants.tokenRequested)
            {
                _showSignin();
            }
            InitializeComponent();
            BindingContext = viewModel = new MainViewModel();

            if (s != null)
            {
                NotificationViewModel.UpdateNotifications(Constants.Notification_VM_Instance);
                MainViewModel.UpdateBadgeAttributes(viewModel, true);
                Navigation.PushAsync(new JobDetailsTabbedPage((ShipmentModelView)s));
            }
        }
        #endregion

        #region Private Events
        private async void _showSignin()
        {
            await Navigation.PushAsync(new SigninPage());
        }
        #endregion

        #region Obsolete Code
        [Obsolete]
        async void LogoutUser()
        {
            try
            {
                var userContext = await authHelper.SignOutAsync();
                CommonHelper.WriteLog("Signout complete", 3);
                CommonHelper.WriteLog(userContext.AccessToken, 3);
                LocalStorageHelper lsh = new LocalStorageHelper();
                lsh.SaveLocalInfo("accessToken", "");
                B2CConstants.tokenRequested = false;
            }
            catch (Exception e)
            {

            }
            finally
            {
                await Navigation.PushAsync(new SigninPage());
            }
        }
        #endregion
    }
}