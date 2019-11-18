using MSTnTAPP.Models;
using System.Collections.Generic;
using System.Linq;

namespace MSTnTAPP.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public int unreadNotificationCount { get; private set; }
        public string badgeColor { get; private set; }
        public string badgeTextColor { get; private set; }

        public MainViewModel()
        {
            UpdateBadgeAttributes(this, true);
        }

        public int UnreadNotificationCount
        {
            get {return unreadNotificationCount;}
            set
            {
                unreadNotificationCount = value;
                OnPropertyChanged("UnreadNotificationCount");
            }
        }

        public string BadgeColor
        {
            get { return badgeColor; }
            set
            {
                badgeColor = value;
                OnPropertyChanged("BadgeColor");
            }
        }

        public string BadgeTextColor
        {
            get { return badgeTextColor; }
            set
            {
                badgeTextColor = value;
                OnPropertyChanged("BadgeTextColor");
            }
        }

        public static void UpdateBadgeAttributes(MainViewModel vm, bool reloadBadgeText, int badgeText = 0)
        {
            //vm.UnreadNotificationCount = reloadBadgeText ? NotificationDataModel.notifications.Where(item => !item.IsRead).Count() : badgeText;
            vm.UnreadNotificationCount = reloadBadgeText ? new List<Notification>().Where(item => !item.IsRead).Count() : badgeText;
            if (vm.UnreadNotificationCount > 0)
            {
                vm.BadgeColor = "Red";
                vm.BadgeTextColor = "White";
            }
            else
            {
                vm.BadgeColor = "Transparent";
                vm.BadgeTextColor = "Transparent";
            }
        }
    }
}
