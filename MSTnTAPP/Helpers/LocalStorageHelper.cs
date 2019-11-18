using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MSTnTAPP.Helpers
{
    public class LocalStorageHelper
    {
        private Dictionary<string, string> localCache = new Dictionary<string, string>();

        public async Task<string> GetLocalInfo(string dataKey)
        {
            string data = "";
            try
            {
                data = await SecureStorage.GetAsync(dataKey);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("Exception in reading cache", 1);
                CommonHelper.WriteLog(ex.ToString(), 1);
            }
            return data;
        }
        public async void SaveLocalInfo(string dataKey, string dataValue)
        {
            try
            {
                CommonHelper.WriteLog("SaveLocalInfo called", 1);
                await SecureStorage.SetAsync(dataKey, dataValue);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("Exception in writing to cache", 1);
                CommonHelper.WriteLog(ex.ToString(), 1);
            }
        }

    }
}
