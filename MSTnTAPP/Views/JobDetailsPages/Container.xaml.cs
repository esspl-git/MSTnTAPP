using MSTnTAPP.Models.Request;
using MSTnTAPP.ViewModels.DataViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views.JobDetailsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Container : ContentPage
    {
        ContainerViewModel cvm;
        public Container(ShipmentBaseRequest requestObject)
        {
            InitializeComponent();
            BindingContext = cvm = new ContainerViewModel(requestObject);
        }
    }
}