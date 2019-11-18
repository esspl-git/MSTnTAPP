using FormsControls.Base;
using MSTnTAPP.Helpers;
using MSTnTAPP.Util;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SigninPage : AnimationPage
    {
        #region Variables
        protected readonly IAuthHelper authHelper;
        protected readonly LocalStorageHelper localStorageHelper;
        #endregion

        public SigninPage()
        {
            InitializeComponent();
            authHelper = DependencyService.Get<IAuthHelper>();
            localStorageHelper = new LocalStorageHelper();
        }

        #region Page events
        #region Click Events
        //Login Button Clicked
        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            activityLoader.IsVisible = true;

            B2CConstants.tokenRequested = true;
            AuthenticateUser();
        }

        //Registration Button Clicked
        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage { PageAnimation = Constants.pageAnimationFromRight });
        }

        //Terms Link Clicked
        private void TnCclicked(object sender, EventArgs e)
        {
            Device.OpenUri(new System.Uri("https://www.esspl.com/"));
        }
        #endregion
        #endregion

        #region Private Events
        private async void AuthenticateUser()
        {
            CommonHelper.WriteLog("AuthenticateUser ENTRY", 3);
            try
            {
                //Go to Login Page
                /* Exception 
                 * if loggin not Completed
                 * If No Internet Connection
                 * If Connection Timeout
                 */
                var userContext = await authHelper.SignInInteractivelyAsync();

                //Save accessToken to localstorage for future loggin in
                localStorageHelper.SaveLocalInfo("accessToken", userContext.AccessToken);

                //Go to refreshed Main Page - Tabbed Page
                await Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                activityLoader.IsVisible = false;
                B2CConstants.tokenRequested = false;

                //Go to SigninPage for Signin Intractively
                await Navigation.PushAsync(new SigninPage { PageAnimation = Constants.pageAnimationFromRight });
            }
        }
        #endregion
    }
}