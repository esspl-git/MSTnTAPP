using MSTnTAPP.Models.Request;
using MSTnTAPP.ViewModels.DataViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views.JobDetailsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Address : ContentView
    {
        AddressViewModel avm;
        public Address(ShipmentBaseRequest requestObject)
        {
            InitializeComponent();
            BindingContext = avm = new AddressViewModel(requestObject);
        }
        public Address()
        {
            InitializeComponent();
        }
    }
}