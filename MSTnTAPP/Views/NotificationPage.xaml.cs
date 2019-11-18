using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MSTnTAPP.ViewModels;
using MSTnTAPP.Util;
using MSTnTAPP.CustomControl;
using MSTnTAPP.Models;
using MSTnTAPP.Models.BindableModels;

namespace MSTnTAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationPage : ContentPage
    {
        static readonly string TAG = "NotificationPage";
        NotificationViewModel vm;
        public NotificationPage()
        {
            System.Diagnostics.Debug.WriteLine("-------------------Inside page constructor", TAG);
            InitializeComponent();
            BindingContext = vm = new NotificationViewModel();
            Constants.Notification_VM_Instance = vm;
        }

        void OnNotificationSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Notification selectedItem = e.SelectedItem as Notification;
        }

        private async void OnNotificationTapped(object sender, ItemTappedEventArgs e)
        {
            Notification tappedItem = e.Item as Notification;

            if(!tappedItem.IsRead)
            {
                //var index = NotificationDataModel.notifications.IndexOf(tappedItem);
                //NotificationDataModel.notifications.Remove(tappedItem);
                tappedItem.IsRead = true;
                //NotificationDataModel.notifications.Insert(index, tappedItem);
                NotificationViewModel.UpdateNotifications(vm);
                MainViewModel.UpdateBadgeAttributes(Constants.Main_VM_Instance, false, Constants.Main_VM_Instance.UnreadNotificationCount - 1);
            }
            
            if (tappedItem.Payload.JobReferenceNumber != null)
            {
                //Shipment shipment = ((List<Shipment>)ListDataModel.shipments).Find(
                //delegate (Shipment sm)
                //{
                //    return sm.JobReferenceNumber.ToLowerInvariant().Contains(tappedItem.Payload.JobReferenceNumber.Trim().ToLowerInvariant());
                //});

                //await Navigation.PushAsync(new JobDetailsTabbedPage(new ShipmentModelView(shipment)));
            } else
            {
                DependencyService.Get<ToastAlert>().ShortAlert("Shipment not found.");
            }
        }

        //setting button click
        private void OnsettingsImageTapped(object sender, EventArgs args)
        {
            Constants.Business_History_Instance = (NavigationPage)Application.Current.MainPage;
            Application.Current.MainPage = new NavigationPage(new Logout());
            //await Navigation.PushAsync(new Logout());
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var image = ((Image)sender);
            var notification = image.BindingContext as Notification;
            bool isConfirmed = await DisplayAlert("Are you sure?", String.Format("You are about to delete a notification regarding the reference number {0}. Do you want to continue?", notification.Title), "Yes", "No");
            if(isConfirmed)
            {
                vm.RemoveCommand.Execute(notification);
                if(!notification.IsRead)
                {
                    MainViewModel.UpdateBadgeAttributes(Constants.Main_VM_Instance, false, Constants.Main_VM_Instance.UnreadNotificationCount - 1);
                }
            }
        }

        private async void OnDeleteAll(object sender, EventArgs e)
        {
            bool isConfirmed = await DisplayAlert("Are you sure?", "You are about to delete a all the notifications. Do you want to continue?", "Yes", "No");
            if (isConfirmed)
            {
                vm.RemoveCommand.Execute(null);
                MainViewModel.UpdateBadgeAttributes(Constants.Main_VM_Instance, false, 0);
            }
        }

        //chat button click
        private void OnChatImageTapped(object sender, EventArgs args)
        {
            /*NavigationPage navigation = (NavigationPage)Application.Current.MainPage;
            Constants.Business_History_Instance = (MainPage)navigation.CurrentPage;
            Application.Current.MainPage = new NavigationPage(Constants.Chat_History_Instance);*/
        }
    }
}