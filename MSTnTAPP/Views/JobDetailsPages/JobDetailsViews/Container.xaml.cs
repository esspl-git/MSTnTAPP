using MSTnTAPP.Models.Request;
using MSTnTAPP.ViewModels.DataViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views.JobDetailsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Container : ContentView
    {
        ContainerViewModel cvm;
        public Container(ShipmentBaseRequest requestObject)
        {
            InitializeComponent();
            BindingContext = cvm = new ContainerViewModel(requestObject);
        }
        public Container()
        {
            InitializeComponent();
        }

        private void ContainerList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MainContainer.IsVisible = false;
            SecondaryContainer.IsVisible = true;
            cvm.GetContainerDetails();
        }

        private void ContainerBack_Tapped(object sender, EventArgs e)
        {
            MainContainer.IsVisible = true;
            SecondaryContainer.IsVisible = false;
        }

        private void Showdetails_Tapped(object sender, EventArgs e)
        {
            MainContainer.IsVisible = false;
            SecondaryContainer.IsVisible = true;
            cvm.GetContainerDetails();
        }
    }
}