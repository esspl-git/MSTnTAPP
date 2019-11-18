using System;
using System.Collections.Generic;
using System.Text;

namespace MSTnTAPP.Util
{
    public static class ChatbotConstants
    {
        public const string LUISEndPointURL = "LUISEndPointURL";
        public const string LUISSubscriptionKey = "LUISSubscriptionKey";
        public const string LUISApplicationID = "LUISApplicationID";

        public static class HelpIntents
        {
            public const string LogoutIntent = "HELP_LOGOUT";
            public const string SearchIntent = "HELP_SEARCH";
            public const string DownloadIntent = "HELP_DOWNLOAD";
            public const string UseChatbotIntent = "HELP_USECHATBOT";
        }

        public static class SearchIntents
        {
            public const string MetroRefNumberIntent = "SEARCH_METROREFERENCENUMBER";
            public const string ContainerIntent = "SEARCH_CONTAINERNUMBER";
            public const string CustomerRefNumberIntent = "SEARCH_CUSTOMERREFERENCENUMBER";
        }
    }
}
