using MSTnTAPP.CustomControl;
using MSTnTAPP.Models;
using MSTnTAPP.Models.BindableModels;
using MSTnTAPP.Util;
using MSTnTAPP.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        #region Variables
        protected HomeViewModel hvm;
        #endregion

        public HomePage()
        {
            InitializeComponent();
            BindingContext = hvm = new HomeViewModel();
            SearchBy.SelectedIndex = 0;
        }

        #region Page Event
        public async void OnViewMore(object sender, EventArgs args)
        {
            string term = SearchTerm.Text;
            int type_Id = ((SearchCriterion)SearchBy.ItemsSource[SearchBy.SelectedIndex]).Id;
            string type_Name = ((SearchCriterion)SearchBy.ItemsSource[SearchBy.SelectedIndex]).Label;
            await hvm.GetNextItem(term, type_Id, type_Name);

            shipmentList.HeightRequest = (((ObservableCollection<ShipmentModelView>)shipmentList.ItemsSource).Count * (shipmentList.RowHeight * 0.8))+25;
        }
        private void OnsettingsImageTapped(object sender, EventArgs args)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Logout { PageAnimation = Constants.pageAnimationFromRight });
        }
        private async void SearchButtonClicked(object sender, EventArgs e)
        {
            string term = SearchTerm.Text;

            if (term == null || term.Length < 4)
            {
                DependencyService.Get<ToastAlert>().ShortAlert("Please Type atleast 4 chars.");
            }
            else
            {
                try
                {
                    int type_Id = ((SearchCriterion)SearchBy.ItemsSource[SearchBy.SelectedIndex]).Id;
                    string type_Name = ((SearchCriterion)SearchBy.ItemsSource[SearchBy.SelectedIndex]).Label;
                    ListFrame.IsVisible = true;
                    ListFrame.IsVisible = await hvm.SearchForItems(term, type_Id, type_Name);

                    shipmentList.HeightRequest = (((ObservableCollection<ShipmentModelView>)shipmentList.ItemsSource).Count * (shipmentList.RowHeight * 0.8)) + 25;
                    if (!ListFrame.IsVisible)
                    {
                        DependencyService.Get<ToastAlert>().ShortAlert("No relevent data found");
                    }
                }
                catch (Exception ex)
                {
                    DependencyService.Get<ToastAlert>().ShortAlert("Please select the type from dropdown");
                }
            }
        }
        private void SelectedPickervalueChanged(object sender, EventArgs args)
        {
            string Searchby = "Search By " + ((SearchCriterion)((CustomPicker)sender).ItemsSource[SearchBy.SelectedIndex]).Label;
            SearchTerm.Placeholder = Searchby;
        }
        private async void SearchTerm_Completed(object sender, EventArgs e)
        {
            string term = SearchTerm.Text;

            if (term == null || term.Length < 4)
            {
                DependencyService.Get<ToastAlert>().ShortAlert("Please Type atleast 4 chars.");
            }
            else
            {
                try
                {
                    int type_Id = ((SearchCriterion)SearchBy.ItemsSource[SearchBy.SelectedIndex]).Id;
                    string type_Name = ((SearchCriterion)SearchBy.ItemsSource[SearchBy.SelectedIndex]).Label;

                    var b = await hvm.SearchForItems(term, type_Id, type_Name);
                    shipmentList.HeightRequest = (((ObservableCollection<ShipmentModelView>)shipmentList.ItemsSource).Count * (shipmentList.RowHeight * 0.8))+25;
                    if (!b)
                    {
                        DependencyService.Get<ToastAlert>().ShortAlert("No relevent data found");
                    }
                }
                catch (Exception ex)
                {
                    DependencyService.Get<ToastAlert>().ShortAlert("Please select the type from dropdown");
                }
            }
        }
        private async void SearchList_IteamTapped(object sender, ItemTappedEventArgs e)
        {
            var Selectedlist = e.Item as ShipmentModelView;
            rootLayout.IsVisible = false;
            loaderlayout.IsVisible = true;
            DetailsLoader.IsRunning = true;

            if (Device.RuntimePlatform == Device.iOS)
            {
                await Task.Delay(300);
                await Navigation.PushAsync(new JobDetailsPage(Selectedlist) { PageAnimation = Constants.pageAnimationFromRight});
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                await Task.Delay(300);
                await Navigation.PushAsync(new JobDetailsTabbedPage(Selectedlist));
            }


            ((ListView)sender).SelectedItem = null;
            loaderlayout.IsVisible = false;
            rootLayout.IsVisible = true;
        }
        #endregion
    }
}