using MSTnTAPP.ViewModels;
using MSTnTAPP.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSTnTAPP.Models;

namespace MSTnTAPP.Views.ChatbotView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatbotPage : ContentPage
    {
        public bool ReturnPage;
        public Shipment shipment;

        static readonly string TAG = "ChatbotPage";
        ChatbotPageViewModel vm;

        public ChatbotPage()
        {
            InitializeComponent();
            this.BindingContext = vm = new ChatbotPageViewModel();
            Constants.Chatbot_VM_Instance = vm;
        }

        //scroll bar tap
        public void ScrollTap(object sender, System.EventArgs e)
        {
            lock (new object())
            {
                if (BindingContext != null)
                {
                    var vm = BindingContext as ChatbotPageViewModel;

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        while (vm.DelayedMessages.Count > 0)
                        {
                            vm.Messages.Insert(0, vm.DelayedMessages.Dequeue());
                        }
                        vm.ShowScrollTap = false;
                        vm.LastMessageVisible = true;
                        vm.PendingMessageCount = 0;
                    });


                }

            }
        }

        public void OnListTapped(object sender, ItemTappedEventArgs e)
        {
            chatInput.UnFocusEntry();
        }
    }
}