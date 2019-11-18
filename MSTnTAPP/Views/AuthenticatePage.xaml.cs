using MSTnTAPP.Helpers;
using MSTnTAPP.Util;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthenticatePage : ContentPage
    {
        #region Variables
        protected readonly IAuthHelper authHelper;
        protected readonly LocalStorageHelper localStorageHelper;
        #endregion

        public AuthenticatePage()
        {
            InitializeComponent();
            authHelper = DependencyService.Get<IAuthHelper>();
            localStorageHelper = new LocalStorageHelper();
        }

        #region Page events
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!B2CConstants.tokenRequested)
            {
                B2CConstants.tokenRequested = true;
                AuthenticateUser();
            }
        }
        #endregion

        #region Private Events
        async void AuthenticateUser()
        {
            CommonHelper.WriteLog("AuthenticateUser ENTRY", 3);
            try
            {
                //Get Login Status 
                /* Exception 
                 * if Not logged in
                 * If No Internet Connection
                 * If Connection Timeout
                 */
                var userContext = await authHelper.AcquireTokenAsync();

                //Save accessToken to localstorage for future loggin in
                localStorageHelper.SaveLocalInfo("accessToken", userContext.AccessToken);

                //Go to refreshed Main Page - Tabbed Page
                await Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                //tokenRequested is needed to avoid multiple onappearing calls 
                B2CConstants.tokenRequested = false;

                //Go to SigninPage for Signin Intractively
                await Navigation.PushAsync(new SigninPage { PageAnimation = Constants.pageAnimationFromTop });
            }
        }
        #endregion
    }
}