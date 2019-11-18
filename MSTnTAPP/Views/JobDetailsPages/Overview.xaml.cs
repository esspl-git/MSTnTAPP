using MSTnTAPP.Models.BindableModels;
using MSTnTAPP.ViewModels.DataViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views.JobDetailsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Overview : ContentPage
    {
        OverviewViewModel ovm;
        public Overview(ShipmentModelView shipment)
        {
            InitializeComponent();
            BindingContext = new OverviewViewModel(shipment);
        }
    }
}