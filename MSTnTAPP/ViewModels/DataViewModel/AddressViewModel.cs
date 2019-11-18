using MSTnTAPP.Models;
using MSTnTAPP.Models.Request;
using MSTnTAPP.Models.Response;
using MSTnTAPP.Services;
using System;
using System.Collections.ObjectModel;

namespace MSTnTAPP.ViewModels.DataViewModel
{
    public class AddressViewModel : BaseViewModel
    {
        #region  Public Variables
        public ObservableCollection<AddressParty> AddressList { get; set; }
        public ShipmentTrackingService trackingService;
        public ShipmentBaseRequest requestObject;
        public ShipmentAddressPartiesResponse responseObject;
        public bool isBusy { get { return _isBusy; } set { _isBusy = isLoaded = value; OnPropertyChanged("isBusy"); } }
        public bool isLoaded { get { return _isLoaded; } set { _isLoaded = value; OnPropertyChanged("isLoaded"); } }
        #endregion

        #region Private Variables
        private bool _isBusy { get; set; }
        private bool _isLoaded { get; set; }
        #endregion

        public AddressViewModel(ShipmentBaseRequest requestObject)
        {
            AddressList = new ObservableCollection<AddressParty>();
            trackingService = new ShipmentTrackingService();
            this.requestObject = requestObject;
            LoadData();
        }

        #region Methods
        private async void LoadData()
        {
            try
            {
                isLoaded = false;
                isBusy = true;
                AddressList.Clear();
                responseObject = await trackingService.GetAddressParties(requestObject.JobType, requestObject.JobId);
                if (responseObject.ReturnCode == "ERR_SUCCESS")
                {
                    foreach (AddressParty a in responseObject.AddressParties)
                    {
                        AddressList.Add(a);
                    }
                }
                else
                {
                   //Error
                }
            }
            catch (Exception e)
            {
                //Exception
            }
            finally
            {
                isBusy = false;
                isLoaded = true;
            }

        }
        #endregion
    }
}
