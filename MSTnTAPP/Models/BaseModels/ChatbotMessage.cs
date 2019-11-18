using MSTnTAPP.Models.BindableModels;
using MSTnTAPP.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSTnTAPP.Models
{
    public class ChatbotMessage
    {
        public string Text { get; set; }
        public string SearchTerm { get; set; }
        public string SearchType { get; set; }
        public Shipment ShipmentObj { get; set; }
        public List<ChatbotMessage> SearchedItems { get; set; }
        public bool IsBotResponse { get; set; }
        public bool IsSingleSearch { get; set; }
        public bool IsMultiSearch { get; set; }
        public INavigation Navigation { get { return Application.Current.MainPage.Navigation; } }

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
    }
}
