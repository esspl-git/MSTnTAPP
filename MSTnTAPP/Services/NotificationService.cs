
using MSTnTAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MSTnTAPP.Services
{
    public class NotificationService
    {
        static NotificationService()
        {}

        public static IList<Notification> GetNotificationList()
        {
            //In future this method will contain API call to gather all notification data.
            //return NotificationDataModel.notifications;
            return new List<Notification>();
        }

        public static IList<Notification> GetRecentNotifications(IList<Notification> notifications)
        {
            IList<Notification> recentNotifications = new ObservableCollection<Notification>();
            foreach (var noty in notifications)
            {
                if (DateTime.Compare(noty.ReceiptDateTime.Date, DateTime.Now.Date) == 0)
                {
                    recentNotifications.Add(noty);
                }
            }

            return recentNotifications;
        }

        public static IList<Notification> GetOlderNotifications(IList<Notification> notifications)
        {
            IList<Notification> olderNotifications = new ObservableCollection<Notification>();
            foreach (var noty in notifications)
            {
                if (DateTime.Compare(noty.ReceiptDateTime.Date, DateTime.Now.Date) != 0)
                {
                    olderNotifications.Add(noty);
                }
            }

            return olderNotifications;
        }

        public static IList<MasterNotification> GetMasterNotificationList(IList<Notification> recentNotifications, IList<Notification> olderNotifications)
        {
            MasterNotification today = new MasterNotification("Today", "");
            today.AddRange(recentNotifications);
            MasterNotification earlier = new MasterNotification("Earlier", "");
            earlier.AddRange(olderNotifications);
            return new ObservableCollection<MasterNotification> {
                today,
                earlier
            };
        }
    }
}
