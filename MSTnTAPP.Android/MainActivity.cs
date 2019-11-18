using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using MSTnTAPP.Helpers;
using Microsoft.Identity.Client;
using Android.Content;

//To avail GoogleApiAvailability class from Xamarin.GooglePlayServices.Base package
using Android.Gms.Common;

//To avail types from Xamarin.Firebase.Messaging package
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using MSTnTAPP.Util;
using MSTnTAPP.ViewModels;
using System.Collections.Generic;
using MSTnTAPP.Models;

namespace MSTnTAPP.Droid
{
    [Activity(Label = "MSTnTAPP", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme.Splash", 
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,ScreenOrientation =ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly string TAG = "MainActivity";
        public static App app;

        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            app = new App();
            FormsControls.Droid.Main.Init(this);
            LoadApplication(app);
            
            var authenticationService = DependencyService.Get<IAuthHelper>();
            authenticationService.SetParent(this);

            IsPlayServicesAvailable();
            CreateNotificationChannel();

            Log.Debug(TAG, "InstanceID token: " + FirebaseInstanceId.Instance.Token);

            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug(TAG, "Key: {0} Value: {1}", key.ToString(), Convert.ToString(value));
                }
            }

            NotificationTapped(Intent);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        // To be uncommented later
        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    Log.Error(TAG, GoogleApiAvailability.Instance.GetErrorString(resultCode));
                else
                {
                    Log.Warn(TAG, "This device is not supported");
                    Finish();
                }
                return false;
            }
            else
            {
                Log.Debug(TAG, "Google Play Services is available");
                return true;
            }
        }

        // To be uncommented later
        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.Default)
            {

                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        // To be uncommented later
        private void NotificationTapped(Intent intent)
        {
            if (intent.Extras != null)
            {
                var shipmentId = long.Parse((string)intent.Extras.Get(Constants.SHIPMENT_ID_KEY));
                var jobReference = (string)intent.Extras.Get(Constants.JOB_REFERENCE_KEY);
                //Shipment shipment = ((List<Shipment>)ListDataModel.shipments).Find(
                //delegate (Shipment sm)
                //{
                //    return sm.JobReferenceNumber.ToLowerInvariant().Contains(jobReference.Trim().ToLowerInvariant());
                //});
                //app.Notify(true, shipment);
            }
        }
    }
}