using MSTnTAPP.Models.Request;
using MSTnTAPP.ViewModels.DataViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views.JobDetailsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Carrier : ContentPage
    {
        CarrierViewModel cvm;
        public Carrier(ShipmentBaseRequest requestObject)
        {
            InitializeComponent();
            BindingContext = cvm = new CarrierViewModel(requestObject);
        }
    }
}