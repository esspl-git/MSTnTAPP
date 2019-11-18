namespace MSTnTAPP.Models
{
    public class AppSettings
    {
        public string LUISServiceUrl { get; set; }
        public string AzureADAuthenticationUrl { get; set; }
        public string UserAuthenticationToken { get; set; }

        public static int ListItemCount = 5;
        public static int MaxListItemCount = 30;
    }
}
