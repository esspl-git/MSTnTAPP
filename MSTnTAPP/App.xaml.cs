using MSTnTAPP.Helpers;
using MSTnTAPP.Models.BindableModels;
using MSTnTAPP.Models;
using MSTnTAPP.Views;
using Xamarin.Forms;
using FormsControls.Base;

namespace MSTnTAPP
{
    public partial class App : Application
    {
        public static string User = "User";
        public App()
        {
            InitializeComponent();

            //Register Azure Login Service
            DependencyService.Register<AzureAuthHelper>();

            //Navigate to Authentication Page
            MainPage = new AnimationNavigationPage(new AuthenticatePage());
            //MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            /* Send Scheduler Apis*/
        }

        protected override void OnResume()
        {
            //Check if Authenticated
            /* if Authenticated then go to mainpage
             * else go to authenticate page*/
        }


        //notification tapped
        public void Notify(bool hasNotification, Shipment shipment)
        {
            if (hasNotification)
            {
               MainPage = new NavigationPage(new MainPage(new ShipmentModelView(shipment)));
            }
        }
    }
}
