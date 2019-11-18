using MSTnTAPP.Models;
using MSTnTAPP.Models.Request;
using MSTnTAPP.Models.Response;
using MSTnTAPP.Services;
using System;
using System.Collections.ObjectModel;

namespace MSTnTAPP.ViewModels.DataViewModel
{
    public class ReferenceViewModel:BaseViewModel
    {
        #region Public property and variables
        public ObservableCollection<Reference> ReferenceList { get; set; }

        public ShipmentTrackingService trackingService;
        public ShipmentBaseRequest requestObject;
        public ShipmentReferenceResponse responseObject;
        public bool isBusy { get { return _isBusy; } set { _isBusy = value; OnPropertyChanged("isBusy"); } }
        public bool isLoaded { get { return _isLoaded; } set { _isLoaded = value; OnPropertyChanged("isLoaded"); } }
        #endregion

        #region Private Property
        private bool _isBusy { get; set; }
        private bool _isLoaded { get; set; }
        #endregion

        public ReferenceViewModel(ShipmentBaseRequest requestObject)
        {
            ReferenceList = new ObservableCollection<Reference>();
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
                ReferenceList.Clear();
                responseObject = await trackingService.GetReferences(requestObject.JobType, requestObject.JobId);
                if (responseObject.ReturnCode == "ERR_SUCCESS")
                {
                    foreach (Reference a in responseObject.References)
                    {
                        ReferenceList.Add(a);
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
