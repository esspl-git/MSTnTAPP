using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MSTnTAPP.Services
{
    public class RestApiClient
    {
        static readonly HttpClient _client;
        static readonly string _serviceUrl = "http://10.0.2.2/RestApiStubService.svc/";

        static RestApiClient()
        {
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromSeconds(20);
        }

        public async Task<string> GetAsync(string url)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await _client.GetAsync($"{_serviceUrl}{url}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                //Create an instance of BaseApiResult
                return null;
            }
        }

        public async Task<string> PostAsync<TParameter>(TParameter arg, string apiName)
        {
            var json = JsonConvert.SerializeObject(arg);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(apiName, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
            }
            else
            {
                return null;
            }

            return null;
        }

        public async Task<string> PostAsync(string url, object arg)
        {
            var content = new StringContent(JsonConvert.SerializeObject(arg), Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync($"{_serviceUrl}{url}", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return null;
            }

            return null;
        }
    }
}
