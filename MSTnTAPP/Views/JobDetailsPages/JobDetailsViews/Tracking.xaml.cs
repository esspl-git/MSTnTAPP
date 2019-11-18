using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSTnTAPP.ViewModels.DataViewModel;
using MSTnTAPP.Models.Request;

namespace MSTnTAPP.Views.JobDetailsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tracking : ContentView
    {
        TrackingViewModel tvm;
        public Tracking(ShipmentBaseRequest requestObject)
        {
            InitializeComponent();
            BindingContext = tvm = new TrackingViewModel(requestObject);
        }
        public Tracking()
        {
            InitializeComponent();
        }
    }
}