using System;
using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Messaging;
using MSTnTAPP.Util;
using MSTnTAPP.ViewModels;

namespace MSTnTAPP.Droid.Services
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    class MetroFirebaseMessagingService : FirebaseMessagingService
    {
        static readonly string TAG = "MetroFirebaseMessagingService";

        //receives notification when app is in foreground
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(TAG, "--------Service called-------");
            HandleNotification(message);
        }

        /*public Notification GenerateNotification(Intent intent)
        {
            if (intent.Extras != null)
            {
                var shipmentId = long.Parse((string)intent.Extras.Get(Constants.SHIPMENT_ID_KEY));
                var jobReference = (string)intent.Extras.Get(Constants.JOB_REFERENCE_KEY);
                var transportType = (string)intent.Extras.Get(Constants.TRANSPORT_TYPE_KEY);
                var title = (string)intent.Extras.Get("Title");
                var description = (string)intent.Extras.Get("Description");
                Shipment shipment = ((List<Shipment>)ListDataModel.shipments).Find(
                delegate (Shipment sm)
                {
                    return sm.JobReferenceNumber.ToLowerInvariant().Contains(jobReference.Trim().ToLowerInvariant());
                });
                app.Notify(true, shipment);
            }
        }*/

        private void HandleNotification(RemoteMessage message)
        {
            int id = DateTime.Now.Millisecond;
            Log.Debug(TAG, "message data: " + message.Data); // this will return android.support.v4.util.ArrayMap
            Log.Debug(TAG, "message data: " + message.Data.GetEnumerator().ToString()); //  Android.Runtime.JavaDictionary`2+<GetEnumerator>c__Iterator0[System.String,System.String]
            Log.Debug(TAG, "From: " + message.From); //From: sender
            Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
            var intent = message.ToIntent();

            if (intent.Extras != null)
            {
                foreach (var key in intent.Extras.KeySet())
                {
                    var value = intent.Extras.GetString(key);
                    Log.Debug(TAG, "Key: {0} Value: {1}", key.ToString(), Convert.ToString(value));
                }
            }

            Models.Notification notification = new Models.Notification
            {
                Title = message.GetNotification().Title,
                Description = message.GetNotification().Body,
                ReceiptDateTime = DateTime.Now,
                Payload = new Models.NotificationPayload(),
                IsRead = false
            };

            if (intent.Extras.ContainsKey(Constants.SHIPMENT_ID_KEY))
            {
                notification.Payload.ShipmentId = long.Parse(((string)intent.Extras.Get(Constants.SHIPMENT_ID_KEY)).Trim());
            }

            if (intent.Extras.ContainsKey(Constants.JOB_REFERENCE_KEY))
            {
                notification.Payload.JobReferenceNumber = ((string)intent.Extras.Get(Constants.JOB_REFERENCE_KEY)).Trim();
            }

            if (intent.Extras.ContainsKey(Constants.TRANSPORT_TYPE_KEY))
            {
                notification.Payload.TransportType = ((string)intent.Extras.Get(Constants.TRANSPORT_TYPE_KEY)).Trim();
            }

            NotificationViewModel.AddNotification(notification);
            NotificationViewModel.UpdateNotifications(Constants.Notification_VM_Instance);
            MainViewModel.UpdateBadgeAttributes(Constants.Main_VM_Instance, false, Constants.Main_VM_Instance.UnreadNotificationCount + 1);
        }
    }
}