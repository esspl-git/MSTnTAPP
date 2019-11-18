using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
//using ESSPL.Solutions.EVA.Portal.SignalR;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

using MSTnTAPP.Helpers;
using MSTnTAPP.Util;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web;
using MSTnTAPP.Model.Models;

namespace MSTnTAPP.Services
{
    // [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LUISClientService
    {
        //private MetroDataService metroDataService;

        private static string SubscriptionKey;
        private static string ApplicationId;
        private static string EndPoint;
        private static string returnResponse = string.Empty;
        public static ChatbotModel.IntentInfo ResolvedIntent { get; set; }
        public static string ChatbotResponse { get; set; }
        public static async Task<ChatbotModel.IntentInfo> ResolveIntent(string phrase)
        {
            ReadLUISConfiguration();
            ResolvedIntent = await RecognizeUserInput(phrase);
            return ResolvedIntent;
        }

        public static async Task<ChatbotMessage> ProcessIntent()
        {
            var answer = "Sorry, I couldn't get you.";
            var intentName = ResolvedIntent.IntentName;

            var responseObj = new ChatbotMessage()
            {
                Text = answer,
                IsBotResponse = true
            };

            if (intentName.Equals("HELLO"))
            {
                responseObj = ChatbotResponseHelper.HelloIntentResponse();
            } else if(intentName.Equals("NONE"))
            {
                responseObj = ChatbotResponseHelper.NoneIntentResponse();
            }
            else if (intentName.Equals("BYE"))
            {
                responseObj = ChatbotResponseHelper.ByeIntentResponse();
            }
            else if (intentName.StartsWith("HELP_"))
            {
                responseObj = ChatbotResponseHelper.HelpIntentResponse(intentName);
            }
            else if (intentName.StartsWith("SEARCH_"))
            {
                if(!string.IsNullOrEmpty(ResolvedIntent.InputParameter.MetroRefNumber))
                {
                    var metroRefNum = ResolvedIntent.InputParameter.MetroRefNumber;
                    Debug.WriteLine("----------------Metro ref number: " + metroRefNum);

                    responseObj = await ChatbotResponseHelper.SearchIntentResponse(intentName, metroRefNum);
                } else if(!string.IsNullOrEmpty(ResolvedIntent.InputParameter.ContainerNumber))
                {
                    var containerNum = ResolvedIntent.InputParameter.ContainerNumber;
                    Debug.WriteLine("----------------Container number: " + containerNum);

                    responseObj = await ChatbotResponseHelper.SearchIntentResponse(intentName, containerNum);
                } else if(!string.IsNullOrEmpty(ResolvedIntent.InputParameter.CustomerRefNumber))
                {
                    var customerRefNum = ResolvedIntent.InputParameter.CustomerRefNumber;
                    Debug.WriteLine("----------------Customer ref number: " + customerRefNum);

                    responseObj = await ChatbotResponseHelper.SearchIntentResponse(intentName, customerRefNum);
                }


            }

            return responseObj;
        }

        private static ChatbotModel.IntentInfo GetIntentInfoFromLUISResponse(LuisResult LUISResult)
        {
            if (LUISResult == null)
            {
                LUISResult = new LuisResult();
            }
            ChatbotModel.IntentInfo intent = new ChatbotModel.IntentInfo();

            // Extract the value from LUISJsonResponse and populate it in the intent object.
            intent.IntentName = LUISResult.TopScoringIntent.Intent?.ToString().Trim().ToUpper() ?? string.Empty;
            intent.InputParameter.MetroRefNumber = GetEntityValueFromLUISEntity(LUISResult, "mstnt_metrorefnumber");
            intent.InputParameter.ContainerNumber = GetEntityValueFromLUISEntity(LUISResult, "mstnt_containernumber");
            intent.InputParameter.CustomerRefNumber = GetEntityValueFromLUISEntity(LUISResult, "mstnt_customerrefnumber");

            return intent;
        }

        private static string GetEntityValueFromLUISEntity(LuisResult LUISResult, string key)
        {
            try
            {
                string luisEntityValue = string.Empty;
                if (LUISResult?.Entities.Count > 0)
                    luisEntityValue = LUISResult?.Entities?.Where(a => a.Type == key).FirstOrDefault().Entity;
                return luisEntityValue;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private static async Task<ChatbotModel.IntentInfo> RecognizeUserInput(string phrase)
        {
            string input = phrase.Trim();

            if (input.Length > 0)
            {
                // Create client with SuscriptionKey and AzureRegion
                var client = new LUISRuntimeClient(new ApiKeyServiceClientCredentials(SubscriptionKey));
                client.Endpoint = EndPoint;

                // Predict
                try
                {
                    var result = await client.Prediction.ResolveAsync(ApplicationId, input);

                    return GetIntentInfoFromLUISResponse(result);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("---------------------------" + ex.Message);
                    returnResponse = ex + "\nSomething went wrong. Please Make sure your app is published and try again.\n";
                }
            }

            return null;

        }

        private static void ReadLUISConfiguration()
        {

            //EndPoint = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/e39ee0cf-130b-4f3f-aa88-2ebd23ea9661?subscription-key=7c6ea5255872447b830a35cfdd1f13f9&timezoneOffset=-360&q=";
            
            EndPoint = AppSettingsManager.Settings[ChatbotConstants.LUISEndPointURL];
            SubscriptionKey = AppSettingsManager.Settings[ChatbotConstants.LUISSubscriptionKey];
            ApplicationId = AppSettingsManager.Settings[ChatbotConstants.LUISApplicationID];

            if (string.IsNullOrWhiteSpace(EndPoint))
            {
                throw new ArgumentException("Missing \"LUIS.Region\" in appsettings.json");
            }
            if (string.IsNullOrWhiteSpace(SubscriptionKey))
            {
                throw new ArgumentException("Missing \"LUIS.SubscriptionKey\" in appsettings.json");
            }
            if (string.IsNullOrWhiteSpace(ApplicationId))
            {
                throw new ArgumentException("Missing \"LUIS.ApplicationId\" in appsettings.json");
            }
        }
    }
}
