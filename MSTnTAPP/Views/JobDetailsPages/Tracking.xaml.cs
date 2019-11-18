using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSTnTAPP.ViewModels.DataViewModel;
using MSTnTAPP.Models.Request;

namespace MSTnTAPP.Views.JobDetailsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tracking : ContentPage
    {
        TrackingViewModel tvm;
        public Tracking(ShipmentBaseRequest requestObject)
        {
            InitializeComponent();
            BindingContext = tvm = new TrackingViewModel(requestObject);
        }
    }
}