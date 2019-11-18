using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using MSTnTAPP.Services;
using System.Threading.Tasks;
using MSTnTAPP.Helpers;
using MSTnTAPP.Views.ChatbotView;
using MSTnTAPP.Views;
using MSTnTAPP.Models;
using MSTnTAPP.Models.BindableModels;

namespace MSTnTAPP.ViewModels
{
    public class ChatbotPageViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }

        public Queue<ChatbotMessage> DelayedMessages { get; set; } = new Queue<ChatbotMessage>();
        public ObservableCollection<ChatbotMessage> Messages { get; set; } = new ObservableCollection<ChatbotMessage>();
        public string textToSend;
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }

        public ChatbotMessage ChatbotResponse { get; set; }

        ChatbotModel.IntentInfo ChatIntentInfo { get; set; }

        ShipmentTrackingService shipmentTrackingService;
        private SingleSearchViewCell singleSearchViewCell;

        public Command<String> OnSendCommand
        {
            get
            {
                return new Command<String>(async (text) =>
                {
                    System.Diagnostics.Debug.WriteLine("------------------------------------inside OnSendCommand");
                    if (!string.IsNullOrEmpty(text))
                    {
                        Messages.Insert(0, new ChatbotMessage() { Text = text, IsBotResponse = false });
                        TextToSend = string.Empty;

                        //ChatIntentInfo = await LUISClientService.ResolveIntent(text);

                        //ChatbotResponse = await LUISClientService.ProcessIntent();
                        //if (LastMessageVisible)
                        //{
                        //    Messages.Insert(0, ChatbotResponse);
                        //}
                        //else
                        //{
                        //    DelayedMessages.Enqueue(ChatbotResponse);
                        //    PendingMessageCount++;
                        //}
                    }
                });
            }
        }

        public Command<Shipment> GoToDetailsCommand
        {
            get
            {
                return new Command<Shipment>(async (shipment) =>
                {
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        await Task.Delay(300);
                        await Navigation.PushAsync(new JobDetailsPage(new ShipmentModelView(shipment)));
                    }
                    else if (Device.RuntimePlatform == Device.Android)
                    {
                        await Task.Delay(300);
                        await Navigation.PushAsync(new JobDetailsTabbedPage(new ShipmentModelView(shipment)));
                    }
                    System.Diagnostics.Debug.WriteLine("------------------------------------inside GoToDetailsCommand");
                });
            }
        }

        public ChatbotPageViewModel()
        {
            Messages.Insert(0, ChatbotResponseHelper.GetWelcomeMessage());

            MessageAppearingCommand = new Command<ChatbotMessage>(OnMessageAppearing);
            MessageDisappearingCommand = new Command<ChatbotMessage>(OnMessageDisappearing);

            shipmentTrackingService = new ShipmentTrackingService();
        }

        public String TextToSend
        {
            get { return textToSend; }
            set
            {
                textToSend = value;
                OnPropertyChanged();
            }
        }

        void OnMessageAppearing(ChatbotMessage message)
        {
            var idx = Messages.IndexOf(message);
            if (idx <= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    while (DelayedMessages.Count > 0)
                    {
                        Messages.Insert(0, DelayedMessages.Dequeue());
                    }
                    ShowScrollTap = false;
                    LastMessageVisible = true;
                    PendingMessageCount = 0;
                });
            }
        }

        void OnMessageDisappearing(ChatbotMessage message)
        {
            var idx = Messages.IndexOf(message);
            if (idx >= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ShowScrollTap = true;
                    LastMessageVisible = false;
                });

            }
        }
    }
}
