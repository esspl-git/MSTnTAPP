using FormsControls.Base;
using MSTnTAPP.ViewModels;
using MSTnTAPP.Views;
using MSTnTAPP.Views.ChatbotView;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MSTnTAPP.Util
{
    public static class Constants
    {
        public const string AIR_TRANSPORT_TYPE = "Air";
        public const string WATER_TRANSPORT_TYPE = "Water";
        public const string LAND_TRANSPORT_TYPE = "Road";
        public const string SHIPMENT_ID_KEY = "SHIPMENT_ID";
        public const string JOB_REFERENCE_KEY = "JOB_REFERENCE_NUMBER";
        public const string TRANSPORT_TYPE_KEY = "TRANSPORT_TYPE";
        public const string SEARCH_TYPE_METRO_REF_NUM = "Reference Number";
        public const string SEARCH_TYPE_CUSTOMER_REF_NUM = "Own Customer Reference Number";
        public const string SEARCH_TYPE_CONTAINER_NUM = "Container Number";

        public const double LIST_FRAME_HEIGHT = 290;
        public const string API_BASE_URL = "http://my.api.com/"; //API base URL goes here

        public static NavigationPage Business_History_Instance = new NavigationPage(new MainPage());
        public static NavigationPage Chat_History_Instance = new NavigationPage(new ChatbotPage());

        public static MainViewModel Main_VM_Instance = new MainViewModel();
        public static NotificationViewModel Notification_VM_Instance = new NotificationViewModel();
        public static ChatbotPageViewModel Chatbot_VM_Instance = new ChatbotPageViewModel();
    
        public static PageAnimation pageAnimationFromRight = new PageAnimation()
        {
            BounceEffect = false,
            Duration = AnimationDuration.Short,
            Type = AnimationType.Slide,
            Subtype = AnimationSubtype.FromRight
        };
        public static PageAnimation pageAnimationFromLeft = new PageAnimation()
        {
            BounceEffect = false,
            Duration = AnimationDuration.Short,
            Type = AnimationType.Slide,
            Subtype = AnimationSubtype.FromLeft
        };
        public static PageAnimation pageAnimationFromTop = new PageAnimation()
        {
            BounceEffect = false,
            Duration = AnimationDuration.Short,
            Type = AnimationType.Slide,
            Subtype = AnimationSubtype.FromTop
        };
        public static PageAnimation pageAnimationFromBottom = new PageAnimation()
        {
            BounceEffect = false,
            Duration = AnimationDuration.Short,
            Type = AnimationType.Slide,
            Subtype = AnimationSubtype.FromBottom
        };

        public static bool API_MODE_OFFLINE = true;
        public static bool API_MODE_ONLINE = false;
    } 
}
