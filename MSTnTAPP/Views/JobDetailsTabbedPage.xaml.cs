using MSTnTAPP.Models;
using MSTnTAPP.Models.BindableModels;
using MSTnTAPP.Models.Request;
using MSTnTAPP.Util;
using MSTnTAPP.Views.JobDetailsPages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDetailsTabbedPage : CustomControl.CustomTabPage
    {
        #region Variables
        Shipment shipment;
        public string TransportType { get; set; }
        #endregion

        public JobDetailsTabbedPage(ShipmentModelView shipment)
        {
            this.shipment = shipment;
            InitializeComponent();
            JobName.Text = shipment.JobReferenceNumber;

            TransportType = shipment.TransportTypeName;

            ShipmentBaseRequest requestObject = new ShipmentBaseRequest()
            {
                JobId = shipment.JobId,
                JobType = shipment.JobType
            };

            //TransportType dependent if/else
            if (TransportType == "Air")//Plane
            {
                Children.Add(new Overview(shipment));
                Children.Add(new JobDetailsPages.Tracking(requestObject));
                Children.Add(new Address(requestObject));
                Children.Add(new ReferenceView(requestObject));
                //Children.Add(new JobDetailsPages.Container(requestObject));
                Children.Add(new Carrier(requestObject));
                Children.Add(new JobDetailsPages.Document(requestObject));
            }
            else if (TransportType == "Sea")//Ship
            {
                Children.Add(new Overview(shipment));
                Children.Add(new JobDetailsPages.Tracking(requestObject));
                Children.Add(new Address(requestObject));
                Children.Add(new ReferenceView(requestObject));
                Children.Add(new JobDetailsPages.Container(requestObject));
                Children.Add(new Carrier(requestObject));
                Children.Add(new JobDetailsPages.Document(requestObject));
            }
            else if(TransportType == "Land")//Truck
            {
                Children.Add(new Overview(shipment));
                Children.Add(new JobDetailsPages.Tracking(requestObject));
                Children.Add(new Address(requestObject));
                Children.Add(new ReferenceView(requestObject));
                Children.Add(new JobDetailsPages.Container(requestObject));
                Children.Add(new Carrier(requestObject));
                Children.Add(new JobDetailsPages.Document(requestObject));
            }
        }

        #region Page Events
        private void settingsNavigation_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Logout());
        }
        private async void OnBackIconTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        #endregion
    }
}