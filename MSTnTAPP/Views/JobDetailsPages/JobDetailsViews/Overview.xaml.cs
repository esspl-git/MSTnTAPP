using MSTnTAPP.Models.BindableModels;
using MSTnTAPP.ViewModels.DataViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views.JobDetailsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Overview : ContentView
    {
        OverviewViewModel ovm;
        public Overview(ShipmentModelView shipment)
        {
            InitializeComponent();
            BindingContext = new OverviewViewModel(shipment);
        }
        public Overview()
        {
            InitializeComponent();
        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {

        }
    }
}