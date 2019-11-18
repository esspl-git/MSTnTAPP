using MSTnTAPP.Models.Request;
using MSTnTAPP.ViewModels.DataViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views.JobDetailsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReferenceView : ContentView
    {
        ReferenceViewModel rvm;
        public ReferenceView(ShipmentBaseRequest requestObject)
        {
            InitializeComponent();
            BindingContext = rvm = new ReferenceViewModel(requestObject);
        }
        public ReferenceView()
        {
            InitializeComponent();
        }
    }
}