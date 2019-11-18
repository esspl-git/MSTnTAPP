namespace MSTnTAPP.Models
{
    public class ChatbotModel
    {
        public interface IIntent
        {
            string IntentName { get; set; }
        }
        public class IntentInfo : IIntent
        {
            public string IntentName { get; set; }
            public RequestParameters InputParameter { get; set; } = new RequestParameters();

            public bool? IsRequestedFromChatbot { get; set; } = false;
        }

        public class RequestParameters
        {
            public string MetroRefNumber { get; set; }
            public string ContainerNumber { get; set; }
            public string CustomerRefNumber { get; set; }
        }
    }
}
