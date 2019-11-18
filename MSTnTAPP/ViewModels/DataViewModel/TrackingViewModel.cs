using MSTnTAPP.Models.BindingModels;
using MSTnTAPP.Models;
using MSTnTAPP.Models.Request;
using MSTnTAPP.Models.Response;
using MSTnTAPP.Services;
using System;
using System.Collections.ObjectModel;

namespace MSTnTAPP.ViewModels.DataViewModel
{
    public class TrackingViewModel:BaseViewModel
    {
        #region Public Variables and Property
        public ObservableCollection<TrackingModelView> TrackingList { get; set; }
        public ShipmentTrackingService trackingService;
        public ShipmentBaseRequest requestObject;
        public ShipmentTrackingResponse responseObject;
        public bool isBusy { get { return _isBusy; } set { _isBusy = value; OnPropertyChanged("isBusy"); } }
        public bool isLoaded { get { return _isLoaded; } set { _isLoaded = value; OnPropertyChanged("isLoaded"); } }
        #endregion

        #region Private Property
        private bool _isBusy { get; set; }
        private bool _isLoaded { get; set; }
        #endregion

        public TrackingViewModel(ShipmentBaseRequest requestObject)
        {
            TrackingList = new ObservableCollection<TrackingModelView>();
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

                TrackingList.Clear();
                responseObject = await trackingService.GetTrackingData(requestObject.JobType, requestObject.JobId);
                if (responseObject.ReturnCode == "ERR_SUCCESS")
                {
                    foreach (Tracking a in responseObject.TrackingInfoList)
                    {
                        TrackingList.Add(new TrackingModelView(a));
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
                isLoaded = true;
                isBusy = false;
            }

        }
        #endregion

    }
}
