using System;

namespace MSTnTAPP.Models
{
    public class CarrierTrackingEvent
    {
        public string EventType { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventText { get; set; }
    }
}
