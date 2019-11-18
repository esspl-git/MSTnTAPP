using System;

namespace MSTnTAPP.Models
{
    public class Notification
    {
        public long NotificationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReceiptDateTime { get; set; }
        public NotificationPayload Payload { get; set; }
        public bool IsRead { get; set; }
        public string NotificationDate { get => ReceiptDateTime.ToString("MMM dd, yyyy"); }
        public string NotificationTime { get => ReceiptDateTime.ToString("HH:mm tt"); }
        public string NotificationTimestamp {
            get
            {
                DateTime now = DateTime.Now;
                string currentTime = now.ToString("HH:mm tt");
                if(DateTime.Compare(now.Date, ReceiptDateTime.Date) == 0 && NotificationTime.Equals(currentTime))
                {
                    return "Now";
                }
                return NotificationTime;
            }
        }
        public string ImageUrl
        {
            get
            {
                if (Payload.TransportType == "1")
                {
                    return "plane.png";
                }
                else if (Payload.TransportType == "2")
                {
                    return "ship.png";
                }
                else if (Payload.TransportType == "3")
                {
                    return "truck.png";
                }
                return "";
            }
        }
    }
}
