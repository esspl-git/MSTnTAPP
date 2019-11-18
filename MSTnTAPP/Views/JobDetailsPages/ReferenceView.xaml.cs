using MSTnTAPP.Models.Request;
using MSTnTAPP.ViewModels.DataViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views.JobDetailsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReferenceView : ContentPage
    {
        ReferenceViewModel rvm;
        public ReferenceView(ShipmentBaseRequest requestObject)
        {
            InitializeComponent();
            BindingContext = rvm = new ReferenceViewModel(requestObject);
        }
    }
}