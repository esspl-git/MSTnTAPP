using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSTnTAPP.ViewModels.DataViewModel;
using MSTnTAPP.Models.Request;

namespace MSTnTAPP.Views.JobDetailsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Document : ContentView
    {
        DocumentViewModel dvm;
        public Document(ShipmentBaseRequest requestObject)
        {
            InitializeComponent();
            BindingContext = dvm = new DocumentViewModel(requestObject);
        }
        public Document()
        {
            InitializeComponent();
        }

        private void DocumentList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selectedlist = e.Item as MSTnTAPP.Models.Document;
            var url = Selectedlist.DocumentUrl;
            if (Selectedlist.DocCode == "PDF")
            {
                Device.OpenUri(new System.Uri(url));
            }

            //ListContentView.IsVisible = false;
            //documentwebview.IsVisible = true;
            //Indicator.IsRunning = true;
            //DocHeader.Text = Selectedlist.DocumentName;
            //PDFViewer.Source = "https://docs.google.com/viewer?url=" + url;
        }

        private void Download_Tapped(object sender, EventArgs e)
        {
            //_ = dvm.Download_Tapped;
        }
        private void Show_Tapped(object sender, EventArgs e)
        {

        }

        private void webviewClose_Tapped(object sender, EventArgs e)
        {
            documentwebview.IsVisible = false;
            ListContentView.IsVisible = true;
            PDFViewer.Source = null;
        }

        private void PDFViewer_Navigated(object sender, WebNavigatedEventArgs e)
        {
            Indicator.IsRunning = false;
        }
    }
}