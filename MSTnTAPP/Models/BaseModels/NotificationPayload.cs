namespace MSTnTAPP.Models
{
    public class NotificationPayload
    {
        public long ShipmentId { get; set; }
        public string JobReferenceNumber { get; set; }
        public string TransportType { get; set; }
    }
}
