using MSTnTAPP.Models;
using MSTnTAPP.Services;
using MSTnTAPP.ViewModels;
using MSTnTAPP.Util;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSTnTAPP.Models.BindableModels;
using FormsControls.Base;

namespace MSTnTAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDetailsPage : AnimationPage
    {
        #region Variables
        JobDetailsViewModel dvm;
        ShipmentModelView shipment;
        List<viewrelationObject> relatedObject;
        BoxView LastSelected;
        #endregion

        public JobDetailsPage(ShipmentModelView shipment)
        {
            this.shipment = shipment;
            InitializeComponent();
            JobName.Text = shipment.JobReferenceNumber;

            BindingContext = dvm = new JobDetailsViewModel(shipment);

            OverviewContainer.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    Command = new Command(() => tabClick(dvm.OverviewPosition))
                });

            TrackingContainer.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    Command = new Command(() => tabClick(dvm.TrackingPosition))
                });

            AddressesContainer.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    Command = new Command(() => tabClick(dvm.AddressesPosition))
                });

            ReferencesContainer.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    Command = new Command(() => tabClick(dvm.ReferencesPosition))
                });

            CarrierContainer.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    Command = new Command(() => tabClick(dvm.CarrierPosition))
                });

            ContainerContainer.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    Command = new Command(() => tabClick(dvm.ContainerPosition))
                });

            DocumentContainer.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    Command = new Command(() => tabClick(dvm.DocumentPosition))
                });

            MapContainer.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    Command = new Command(() => tabClick(dvm.MapPosition))
                });

            relatedObject = dvm.ViewrelationObjectList;
            LastSelected = new BoxView();
        }

        #region Page Events
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private void settingsNavigation_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Logout());
        }
        private async void OnBackIconTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private void carousel_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
                NavigateMarker(e.NewValue);
        }

        [Obsolete]
        private void carousel_Scrolled(object sender, CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs e)
        {
            //NavigateMarker((int)e.NewValue);
            // e.newvalue for scroll is not showing accurate
            //if (isFired)
            //{
            //    isFired = false;
            //    int value = -1;

            //    //CarrouselView Plugin in start and at end position the scroll direction is showing reverse : left scroll in ScrolledEventArgs shoing as right 
            //    //For that reason both the cases are handled.
            //    if (carousel.Position == ((ObservableCollection<View>)carousel.ItemsSource).Count - 1 || carousel.Position == 0)
            //    {
            //        isFired = false;
            //        isClicked = true;
            //    }
            //    else
            //    {

            //        if (e.Direction == CarouselView.FormsPlugin.Abstractions.ScrollDirection.Right)
            //        {
            //            value = carousel.Position + 1;
            //        }
            //        else if (e.Direction == CarouselView.FormsPlugin.Abstractions.ScrollDirection.Left)
            //        {
            //            value = carousel.Position - 1;
            //        }
            //        if (value >= 0 && value <8)
            //        {
            //            NavigateMarker(value);
            //        }
            //    }
            //}
        }
        #endregion


        public void tabClick(int index)
        {
            carousel.Position = index;
        }
        public void NavigateMarker(int index)
        {
            try
            {
                string marker = relatedObject.Find(
                    delegate (viewrelationObject vro)
                    {
                        return vro.Position == index;
                    }).Pointer;
                switch (marker)
                {
                    case "Overview":
                        LastSelected.IsVisible = false;
                        OverviewMarker.IsVisible = true;
                        LastSelected = OverviewMarker;
                        scroll.ScrollToAsync(OverviewContainer, ScrollToPosition.MakeVisible, true);
                        break;
                    case "Tracking":
                        LastSelected.IsVisible = false;
                        TrackingMarker.IsVisible = true;
                        LastSelected = TrackingMarker;
                        scroll.ScrollToAsync(TrackingContainer, ScrollToPosition.MakeVisible, true);
                        break;
                    case "Addresses":
                        LastSelected.IsVisible = false;
                        AddressesMarker.IsVisible = true;
                        LastSelected = AddressesMarker;
                        scroll.ScrollToAsync(AddressesContainer, ScrollToPosition.MakeVisible, true);
                        break;
                    case "Reference":
                        LastSelected.IsVisible = false;
                        ReferencesMarker.IsVisible = true;
                        LastSelected = ReferencesMarker;
                        scroll.ScrollToAsync(ReferencesContainer, ScrollToPosition.MakeVisible, true);
                        break;
                    case "Container":
                        LastSelected.IsVisible = false;
                        ContainerMarker.IsVisible = true;
                        LastSelected = ContainerMarker;
                        scroll.ScrollToAsync(ContainerContainer, ScrollToPosition.MakeVisible, true);
                        break;
                    case "Carrier":
                        LastSelected.IsVisible = false;
                        CarrierMarker.IsVisible = true;
                        LastSelected = CarrierMarker;
                        scroll.ScrollToAsync(CarrierContainer, ScrollToPosition.MakeVisible, true);
                        break;
                    case "Document":
                        LastSelected.IsVisible = false;
                        DocumentMarker.IsVisible = true;
                        LastSelected = DocumentMarker;
                        scroll.ScrollToAsync(DocumentContainer, ScrollToPosition.MakeVisible, true);
                        break;
                    case "Map":
                        LastSelected.IsVisible = false;
                        MapMarker.IsVisible = true;
                        LastSelected = MapMarker;
                        scroll.ScrollToAsync(MapContainer, ScrollToPosition.MakeVisible, true);
                        break;
                }
            }
            catch (NullReferenceException e)
            {
                // isFired = false;
            }

        }
    }
}