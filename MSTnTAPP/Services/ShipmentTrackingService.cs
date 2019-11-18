using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSTnTAPP.Models;
using MSTnTAPP.Models.Response;
using MSTnTAPP.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MSTnTAPP.Services
{
    public class ShipmentTrackingService
    {
        #region Members & Properties

        private RestApiClient _apiClient = null;

        private RestApiClient RestClient
        {
            get
            {
                if(_apiClient == null)
                {
                    _apiClient = new RestApiClient();
                }

                return _apiClient;
            }
        }

        #endregion

        #region Public Methods

        public async Task<ShipmentResponse> GetRecentSearches(int maxItemCount)
        {
            string rawResponse;
            if (Constants.API_MODE_ONLINE)
            {
                string url = $"/GetRecentSearches?maxItemCount={maxItemCount}";
                rawResponse = await RestClient.GetAsync(url);
            }
            else
            {
                await Task.Delay(150);
                rawResponse = OfflineAPIResponse.GetRecentSearch;
            }


            JObject jobject = JObject.Parse(rawResponse);
            var response = JsonConvert.DeserializeObject<ShipmentResponse>(jobject.ToString());

            return response;
        }

        public async Task<ShipmentResponse> GetShipments(string searchOn, string searchTerm, int takeItemCount, int skipItemCount)
        {
            string rawResponse;
            if (Constants.API_MODE_ONLINE)
            {
               string url = $"/GetShipments?searchOn={searchOn}&searchTerm={searchTerm}&takeItemCount={takeItemCount}&skipItemCount={skipItemCount}";
               rawResponse = await RestClient.GetAsync(url);
                
            }
            else
            {
                await Task.Delay(150);
                rawResponse = OfflineAPIResponse.GetShipments;
            }

            JObject jobject = JObject.Parse(rawResponse);
            var response = JsonConvert.DeserializeObject<ShipmentResponse>(jobject.ToString());

            return response;
        }
        
        
        #region ShipmentDetail APIs
        public async Task<ShipmentTrackingResponse> GetTrackingData(string jobType, string jobId)
        {
            string rawResponse;
            if (Constants.API_MODE_ONLINE)
            {
                string url = $"/GetTrackingData?jobType={jobType}&jobId={jobId}";
                rawResponse = await RestClient.GetAsync(url);
            }
            else
            {
                await Task.Delay(150);
                rawResponse = OfflineAPIResponse.GetTrackingdata;
                
            }
            JObject jobject = JObject.Parse(rawResponse);
            var response = JsonConvert.DeserializeObject<ShipmentTrackingResponse>(jobject.ToString());

            return response;
        }

        public async Task<ShipmentAddressPartiesResponse> GetAddressParties(string jobType, string jobId)
        {
            string rawResponse;
            if (Constants.API_MODE_ONLINE)
            {
                string url = $"/GetAddressParties?jobType={jobType}&jobId={jobId}";
                rawResponse = await RestClient.GetAsync(url);
            }
            else
            {
                await Task.Delay(150);
                rawResponse = OfflineAPIResponse.GetAddressParties;

            }
            JObject jobject = JObject.Parse(rawResponse);
            var response = JsonConvert.DeserializeObject<ShipmentAddressPartiesResponse>(jobject.ToString());

            return response;
        }

        public async Task<ShipmentReferenceResponse> GetReferences(string jobType, string jobId)
        {
            string rawResponse;
            if (Constants.API_MODE_ONLINE)
            {
                string url = $"/GetReferences?jobType={jobType}&jobId={jobId}";
                rawResponse = await RestClient.GetAsync(url);
            }
            else
            {
                await Task.Delay(150);
                rawResponse = OfflineAPIResponse.GetReferences;
            }
            JObject jobject = JObject.Parse(rawResponse);
            var response = JsonConvert.DeserializeObject<ShipmentReferenceResponse>(jobject.ToString());

            return response;
        }

        #endregion

        #region Other APIs
        public async Task<GetTnTAppSettingsResponse> GetTnTAppSettings()
        {
            string url = $"/GetTnTAppSettings";
            string rawResponse = await RestClient.GetAsync(url);
            JObject jobject = JObject.Parse(rawResponse);
            var response = JsonConvert.DeserializeObject<GetTnTAppSettingsResponse>(jobject.ToString());

            return response;
        }

        public async Task<BaseAPIResponse> SetNotificationReadStatus(string notificationId)
        {
            string url = $"SetNotificationReadStatus";
            var data = new { notificationId = notificationId };
            string rawResponse = await RestClient.PostAsync(url, data);
            JObject jobject = JObject.Parse(rawResponse);
            var response = JsonConvert.DeserializeObject<BaseAPIResponse>(jobject.ToString());

            return response;
        }

        public async Task<BaseAPIResponse> RegisterDeviceNotificationKey(string deviceId, string deviceNotificationKey)
        {
            string url = $"RegisterDeviceNotificationKey";
            var data = new { deviceId = deviceId, deviceNotificationKey = deviceNotificationKey };
            string rawResponse = await RestClient.PostAsync(url, data);
            JObject jobject = JObject.Parse(rawResponse);
            var response = JsonConvert.DeserializeObject<BaseAPIResponse>(jobject.ToString());

            return response;
        }

        public IList<SearchCriterion> GetSearchTypeList()
        {
            ObservableCollection<SearchCriterion> res = new ObservableCollection<SearchCriterion>()
                {
                    new SearchCriterion(Util.Enum.SearchCriterion.METRO_REFERENCE_NUMBER.GetHashCode(), Constants.SEARCH_TYPE_METRO_REF_NUM),
                    new SearchCriterion(Util.Enum.SearchCriterion.CONTAINER_NUMBER.GetHashCode(), Constants.SEARCH_TYPE_CONTAINER_NUM),
                    new SearchCriterion(Util.Enum.SearchCriterion.OWN_CUSTOMER_REFERENCE_NUMBER.GetHashCode(), Constants.SEARCH_TYPE_CUSTOMER_REF_NUM)
                };
            return res;
        }
        #endregion

        #endregion

        #region Private Methods

        private BaseAPIResponse GenerateErrorResponse<TResponse>(string errorCode, string errorMessage) where TResponse : BaseAPIResponse, new()
        {
            TResponse response = new TResponse();
            ((BaseAPIResponse)response).ReturnCode = errorCode;
            ((BaseAPIResponse)response).ReturnMessage = errorMessage;

            return response;
        }
        #endregion
    }
}
