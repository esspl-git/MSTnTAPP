using MSTnTAPP.Models.Request;
using MSTnTAPP.ViewModels.DataViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views.JobDetailsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Address : ContentPage
    {
        AddressViewModel avm;
        public Address(ShipmentBaseRequest requestObject)
        {
            InitializeComponent();
            BindingContext = avm = new AddressViewModel(requestObject);
        }
    }
}