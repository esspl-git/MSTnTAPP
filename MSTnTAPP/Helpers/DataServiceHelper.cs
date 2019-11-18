using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using MSTnTAPP.Models;
using Newtonsoft.Json;

namespace MSTnTAPP.Helpers
{
    public class DataServiceHelper
    {
        HttpClient _client;

        //=== Initialize the client when the helper object is created
        public DataServiceHelper()
        {
            _client = new HttpClient();
        }

        /*****
         * This is the common method to call an API. This method calls API and returns the data in string format.
         * Expected output from API is JSON string
         * TBD: Extensive testing and error handling
         * ****/
        public async Task<string> CallApi(ApiRequestModel req, string apiName, string methodName)
        {
            System.Diagnostics.Debug.WriteLine("===========CallApi Inside==========");
            CommonHelper.WriteLog("DataServiceHelper.CallApi Calling API: " + apiName + "/" + methodName, 3);
            var uri = new Uri(string.Format(CommonHelper.DataServiceUrl, apiName, methodName));
            //var uri = new Uri(string.Format(CommonHelper.DataServiceUrl, apiName, "6"));
            System.Diagnostics.Debug.WriteLine(uri.ToString());
            try
            {
                LocalStorageHelper lsh = new LocalStorageHelper();
                req.userId = lsh.GetLocalInfo("LoginId").Result;
                req.sessionId = lsh.GetLocalInfo("SessionId").Result;

                var json = JsonConvert.SerializeObject(req);
                CommonHelper.WriteLog("DataServiceHelper.CallApi request: " + json, 3);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = _client.PostAsync(uri, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    CommonHelper.WriteLog("DataServiceHelper.CallApi Successful", 3);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    CommonHelper.WriteLog(responseContent, 3);
                    //ApiResponseModel arm = JsonConvert.DeserializeObject<ApiResponseModel>(responseContent);
                    return responseContent;
                }
                else
                {
                    CommonHelper.WriteLog("DataServiceHelper.CallApi failed", 3);
                    CommonHelper.WriteLog(response.StatusCode.ToString(), 3);
                }
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("DataServiceHelper.CallApi Exception", 3);
                CommonHelper.WriteLog(ex.ToString(), 1);
            }
            return null;
        }

        /*****
         * This is a sample method to call API and Search shipments. 
         * This is just a sample and not final code. 
         * ****/
        public List<ShipmentModel> SearchShipment()
        {
            System.Diagnostics.Debug.WriteLine("===========SearchShipment Inside==========");
            SearchRequestModel srm = new SearchRequestModel();
            srm.metroId = 12;
            srm.shipmentNo = 3333;
            srm.custmerId = 1234;
            string apiResp = CallApi(srm, "Shipment", "SearchShipment").Result;
            System.Diagnostics.Debug.WriteLine("Call API Complete");
            if (apiResp != null)
            {
                SearchResponseModel resp = JsonConvert.DeserializeObject<SearchResponseModel>(apiResp);
                return resp.listObjects;
            }
            else
                return null;
        }

        public void SaveUserToken(string fbToken)
        {
            System.Diagnostics.Debug.WriteLine("===========SaveUserToken Inside==========");
            UserTokenModel utm = new UserTokenModel();
            utm.userToken = fbToken;
            string apiResp = CallApi(utm, "Shipment", "SaveUserToken").Result;
            System.Diagnostics.Debug.WriteLine("Save Token Complete");
        }
    }
}
