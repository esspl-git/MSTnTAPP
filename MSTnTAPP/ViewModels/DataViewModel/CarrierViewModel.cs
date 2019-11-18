using MSTnTAPP.Models.Request;
using MSTnTAPP.Models.Response;
using MSTnTAPP.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MSTnTAPP.ViewModels.DataViewModel
{
    public class CarrierViewModel: BaseViewModel
    {
        #region Public Variable And Properties
        public bool isBusy { get { return _isBusy; } set { _isBusy = value; OnPropertyChanged("isBusy"); } }
        public bool isLoaded { get { return _isLoaded; } set { _isLoaded = value; OnPropertyChanged("isLoaded"); } }

        //TODO during API config
        //public ObservableCollection<CarrierDetails> CarrierList { get; set; }
        public ShipmentTrackingService trackingService;
        public ShipmentBaseRequest requestObject;
        public ShipmentTransportLegsResponse responseObject;
        #endregion

        #region Private Variables
        private bool _isBusy { get; set; }
        private bool _isLoaded { get; set; }
        #endregion

        public CarrierViewModel(ShipmentBaseRequest requestObject)
        {
            //CarrierList = new ObservableCollection<CarrierDetails>()
            //{
            //    new CarrierDetails()
            //    {
            //        CarrierDate = "July 10 2019 12:26 PM",
            //        CarrierVisibility = true,
            //        CarrierTitle = "In gate",
            //        CarrierDescription = "CONTAINER: MRKU4772644 40HC VESSEL: CMA CGM NERVAL LOCATION: FELIXSTOWE.",
            //        CarrierImage = "timeline.png"
            //    },
            //    new CarrierDetails()
            //    {
            //        CarrierDate = "July 18 2019 11:46 AM",
            //        CarrierVisibility = true,
            //        CarrierTitle = "Loaded on vessel",
            //        CarrierDescription = "CONTAINER: MRKU4772644 40HC VESSEL: CMA CGM NERVAL LOCATION: FELIXSTOWE.",
            //        CarrierImage = "timeline.png"
            //    },
            //    new CarrierDetails()
            //    {
            //        CarrierDate = "July 18 2019 07:46 PM",
            //        CarrierVisibility = true,
            //        CarrierTitle = "Vessel deprature",
            //        CarrierDescription = "CONTAINER: MRKU4772644 40HC VESSEL: CMA CGM NERVAL LOCATION: FELIXSTOWE.",
            //        CarrierImage = "timelinebold.png"
            //    },
            //    new CarrierDetails()
            //    {
            //        CarrierDate = "October 05 2019 12:31 AM",
            //        CarrierVisibility = false,
            //        CarrierTitle = "Vessel arrival",
            //        CarrierDescription = "CONTAINER: MRKU4772644 40HC VESSEL: CMA CGM NERVAL LOCATION: AMBARLI.",
            //        CarrierImage = "timeline.png"
            //    },
            //};
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
                //CarrierList.Clear();
                await Task.Delay(150);
                //responseObject = await trackingService.GetAddressParties(requestObject.JobType, requestObject.JobId);
                //if (responseObject.ReturnCode == "ERR_SUCCESS")
                //{
                //    foreach (AddressParty a in responseObject.AddressParties)
                //    {
                //        AddressList.Add(a);
                //    }
                //}
                //else
                //{
                //    //Error
                //}
            }
            catch (Exception e)
            {
                //Exception
            }
            finally
            {
                isLoaded = true;
                isBusy = false;
            }
        }
        #endregion
    }
}
