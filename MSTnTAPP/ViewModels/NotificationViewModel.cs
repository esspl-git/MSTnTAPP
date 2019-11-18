using System;
using System.Collections.Generic;
using System.Text;
using MSTnTAPP.Models;
using MSTnTAPP.Services;
using Xamarin.Forms;

namespace MSTnTAPP.ViewModels
{
    public class NotificationViewModel : BaseViewModel
    {
        static readonly string TAG = "NotificationViewModel";

        IList<Notification> notifications;
        IList<Notification> recentNotifications;
        IList<Notification> olderNotifications;
        IList<MasterNotification> masterNotifiactionList;

        bool hasNotification;
        bool showEmptyMessage;
        bool isBusy;

        public Command<Notification> RemoveCommand
        {
            get
            {
                return new Command<Notification>((notification) =>
                {
                    System.Diagnostics.Debug.WriteLine("------------------------------------inside Refresh Command");
                    if(notification != null)
                    {
                        //NotificationDataModel.notifications.Remove(notification);
                    } else
                    {
                        //NotificationDataModel.notifications.Clear();
                    }
                    Notifications = NotificationService.GetNotificationList();
                });
            }
        }

        public Command RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsBusy = true;
                    Notifications = NotificationService.GetNotificationList();
                    IsBusy = false;
                });
            }
        }

        public NotificationViewModel()
        {
            System.Diagnostics.Debug.WriteLine("-------------------Inside vm constructor", TAG);

            Notifications = NotificationService.GetNotificationList();
            System.Diagnostics.Debug.WriteLine("notification array size: " + MasterNotifiactionList.Count, TAG);
        }

        public IList<Notification> Notifications
        {
            get { return notifications; }
            set
            {
                notifications = value;
                OnPropertyChanged();

                HasNotification = Notifications.Count > 0;
                ShowEmptyMessage = Notifications.Count == 0;

                RecentNotifications = NotificationService.GetRecentNotifications(Notifications);
                OlderNotifications = NotificationService.GetOlderNotifications(Notifications);
                MasterNotifiactionList = NotificationService.GetMasterNotificationList(RecentNotifications, OlderNotifications);
            }
        }

        public IList<Notification> RecentNotifications
        {
            get { return recentNotifications; }
            set
            {
                recentNotifications = value;
                OnPropertyChanged();
            }
        }

        public IList<Notification> OlderNotifications
        {
            get { return olderNotifications; }
            set
            {
                olderNotifications = value;
                OnPropertyChanged();
            }
        }

        public IList<MasterNotification> MasterNotifiactionList
        {
            get { return masterNotifiactionList; }
            set
            {
                masterNotifiactionList = value;
                OnPropertyChanged();
            }
        }

        public bool HasNotification
        {
            get { return hasNotification; }
            set
            {
                hasNotification = value;
                OnPropertyChanged();
            }
        }

        public bool ShowEmptyMessage
        {
            get { return showEmptyMessage; }
            set
            {
                showEmptyMessage = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public static void AddNotification(Notification notification)
        {
            //NotificationDataModel.notifications.Insert(0, notification);
        }

        public static void UpdateNotifications(NotificationViewModel vm)
        {
            vm.Notifications = NotificationService.GetNotificationList();
        }
    }
}
