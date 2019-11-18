using MSTnTAPP.Models;
using MSTnTAPP.Services;
using MSTnTAPP.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSTnTAPP.Helpers
{
    public class ChatbotResponseHelper
    {
        static ShipmentTrackingService shipmentTrackingService = new ShipmentTrackingService();

        public static string greeting = String.Format("Hey there! I am your personal assistant Bob. " +
                "You can ask me anything related to shipment or you can ask any question from below example.\n\n");
        public static string searchExample = String.Format("1. How do I search for a shipment ?\n" +
            "2. Please show me the details of shipment ####\n" +
            "3. What is final destination of my shipment id ####\n" +
            "4. Show me the ETA of job ####");

        public static ChatbotMessage GetWelcomeMessage()
        {
            return new ChatbotMessage() { Text = (greeting + searchExample), IsBotResponse = true };
        }

        public static ChatbotMessage HelloIntentResponse()
        {
            return GetWelcomeMessage();
        }

        public static ChatbotMessage NoneIntentResponse()
        {
            return new ChatbotMessage() { Text = String.Format("Please clarify your interest."), IsBotResponse = true };
            //return String.Format("Please clarify your interest.");
        }

        public static ChatbotMessage ByeIntentResponse()
        {
            return new ChatbotMessage()
            {
                Text = String.Format("I hope you found what you were looking for.\n" +
                "Keep coming back. Thank you."),
                IsBotResponse = true
            };
            /*return String.Format("I hope you found what you were looking for.\n" +
                "Keep coming back. Thank you.");*/
        }

        public static ChatbotMessage HelpIntentResponse(string intentName)
        {
            string response = "";

            switch (intentName)
            {
                case ChatbotConstants.HelpIntents.LogoutIntent:
                    response = String.Format("Here are the steps to logout from the application.\n\n" +
                        "1. Tap on the white cogwheel icon present at the top-right corner of every page.\n\n" +
                        "2. In the page that you will be redirected to, tap on the SIGN OUT button present at the center of the page.\n\n" +
                        "This way you will be out of the application.");
                    break;
                case ChatbotConstants.HelpIntents.SearchIntent:
                    response = String.Format("You can search a shipment or a job using three parameters, namely\n\n" +
                        "1. Metro Reference Number\n" +
                        "2. Container Number &\n" +
                        "3. Customer Reference Number\n\n" +
                        "To search a shipment\n\n" +
                        "1. Go to the home page by clicking on the left most menu from the bottom navigation bar.\n\n" +
                        "2. Click on the dropdown from the topmost panel to open a popup where you can select any one of the above parameters. " +
                        "Scroll the list vertically to traverse among the options. Select an option by positioning it at the middle and tap on the OK button.\n\n" +
                        "3. Now in the text field above type the term you want to search and tap on the SEARCH button. " +
                        "The search results will be populated in a panel named \"Search Results\" placed just below the Search panel.");
                    break;
                case ChatbotConstants.HelpIntents.DownloadIntent:
                    response = String.Format("Here are the steps to download a document.\n\n" +
                        "1. Navigate to the DOCUMENTS section in the job details page.\n\n" +
                        "2. For each document you can find a download icon there. " +
                        "Tap on that icon to download the associated document to your device.");
                    break;
                case ChatbotConstants.HelpIntents.UseChatbotIntent:
                    response = String.Format("To be written...");
                    break;
                default:
                    response = String.Format("Please rephrase your question.");
                    break;
            }

            return new ChatbotMessage()
            {
                Text = response,
                IsBotResponse = true
            };

            //return response;
        }

        public static async Task<ChatbotMessage> SearchIntentResponse(string intentName, string entity)
        {
            string response = "";
            bool isValidEntity = true;

            var responseObj = new ChatbotMessage()
            {
                IsBotResponse = true
            };

            if (entity.Length < 4)
            {
                response = "Please enter at least 4 characters for {0} of the shipment.";
                isValidEntity = false;
            }

            switch (intentName)
            {
                case ChatbotConstants.SearchIntents.MetroRefNumberIntent:
                    if (isValidEntity)
                    {
                        var SearchedItemListResponse = await shipmentTrackingService.GetShipments(Constants.SEARCH_TYPE_METRO_REF_NUM, entity, AppSettings.ListItemCount, 0);
                        var SearchedItemList = SearchedItemListResponse != null ? SearchedItemListResponse.Shipments : null;

                        //Delete Later
                        if (SearchedItemList != null && entity.Equals("j0001"))
                        {
                            SearchedItemList = ((List<Shipment>)SearchedItemList).FindAll(
                                delegate (Shipment sm)
                                    {
                                        return sm.JobReferenceNumber.ToLowerInvariant().Contains(entity);
                                    });
                        }

                        responseObj = PopulateResponseObj(SearchedItemList, Constants.SEARCH_TYPE_METRO_REF_NUM, entity, responseObj);
                    }
                    else
                    {
                        response = String.Format(response, Constants.SEARCH_TYPE_METRO_REF_NUM.ToLower());
                        responseObj.Text = response;
                    }
                    break;
                case ChatbotConstants.SearchIntents.ContainerIntent:
                    if(isValidEntity)
                    {
                        var SearchedItemListResponse = await shipmentTrackingService.GetShipments(Constants.SEARCH_TYPE_CONTAINER_NUM, entity, AppSettings.ListItemCount, 0);
                        var SearchedItemList = SearchedItemListResponse != null ? SearchedItemListResponse.Shipments : null;

                        responseObj = PopulateResponseObj(SearchedItemList, Constants.SEARCH_TYPE_CONTAINER_NUM, entity, responseObj);
                    } else
                    {
                        response = String.Format(response, Constants.SEARCH_TYPE_CONTAINER_NUM.ToLower());
                        responseObj.Text = response;
                    }
                    break;
                case ChatbotConstants.SearchIntents.CustomerRefNumberIntent:
                    if (isValidEntity)
                    {
                        var SearchedItemListResponse = await shipmentTrackingService.GetShipments(Constants.SEARCH_TYPE_CUSTOMER_REF_NUM, entity, AppSettings.ListItemCount, 0);
                        var SearchedItemList = SearchedItemListResponse != null ? SearchedItemListResponse.Shipments : null;

                        responseObj = PopulateResponseObj(SearchedItemList, Constants.SEARCH_TYPE_CUSTOMER_REF_NUM, entity, responseObj);
                    }
                    else
                    {
                        response = String.Format(response, Constants.SEARCH_TYPE_CUSTOMER_REF_NUM.ToLower());
                        responseObj.Text = response;
                    }
                    break;
                default:
                    response = String.Format("Please rephrase your question.");
                    responseObj.Text = response;
                    break;
            }

            
            return responseObj;
        }

        private static ChatbotMessage PopulateResponseObj(IList<Shipment> searchedItemList, string searchType, string searchTerm, ChatbotMessage responseObj)
        {
            var response = "Sorry you don't have any shipments for the given metro rerefence number.";
            var text = "Below are the details of the shipment with {0} {1}.\n\n" +
                        "Final Destination: {2}\n" +
                        "Estimated Time of Arrival: {3}";

            if (searchedItemList != null)
            {
                if (searchedItemList.Count == 1)
                {
                    var shipment = searchedItemList[0];
                    response = String.Format(text, searchType.ToLower(), shipment.JobReferenceNumber, shipment.FinalDestination, shipment.ETA);
                    responseObj.IsSingleSearch = true;
                    responseObj.ShipmentObj = shipment;
                }
                else if (searchedItemList.Count > 1)
                {
                    response = (searchedItemList.Count < AppSettings.ListItemCount) ?
                        String.Format("I have found {0} matches for {1} {2}.", searchedItemList.Count, searchType.ToLower(), searchTerm.ToUpper()) :
                        String.Format("Here are the first {0} matches for {1} {2}.", AppSettings.ListItemCount, searchType.ToLower(), searchTerm.ToUpper());
                    responseObj.IsMultiSearch = true;
                    List<ChatbotMessage> searchedItems = new List<ChatbotMessage>();

                    foreach (var shipment in searchedItemList)
                    {
                        var searchedItem = new ChatbotMessage()
                        {
                            Text = String.Format(text, searchType.ToLower(), shipment.JobReferenceNumber, shipment.FinalDestination, shipment.ETA),
                            ShipmentObj = shipment
                        };
                        searchedItems.Add(searchedItem);
                    }
                    responseObj.SearchedItems = searchedItems;
                }
            }

            responseObj.Text = response;
            return responseObj;
        }
    }
}
