using FormsControls.Base;
using MSTnTAPP.Helpers;
using MSTnTAPP.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logout : AnimationPage
    {
        #region Variables
        protected readonly IAuthHelper authHelper;
        protected LocalStorageHelper localStorageHelper;
        #endregion

        public Logout()
        {
            InitializeComponent();
            authHelper = DependencyService.Get<IAuthHelper>();
            localStorageHelper = new LocalStorageHelper();
        }

        #region Page Events
        private void OnBackIconTapped(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
        private async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var userContext = await authHelper.SignOutAsync();

                localStorageHelper.SaveLocalInfo("accessToken", "");
                B2CConstants.tokenRequested = false;
                await Application.Current.MainPage.Navigation.PushAsync(new SigninPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert($"Exception:", ex.ToString(), "Dismiss");
            }
        }
        #endregion
    }
}