using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSTnTAPP.ViewModels.DataViewModel;
using MSTnTAPP.Models.Request;

namespace MSTnTAPP.Views.JobDetailsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Document : ContentPage
    {
        DocumentViewModel dvm;
        public Document(ShipmentBaseRequest requestObject)
        {
            InitializeComponent();
            BindingContext = dvm = new DocumentViewModel(requestObject);
        }
    }
}