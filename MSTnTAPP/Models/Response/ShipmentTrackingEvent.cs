using System.Collections.Generic;

namespace MSTnTAPP.Models.Response
{
    public class ShipmentTrackingEvent:BaseAPIResponse
    {
        public List<TrackingEvent> TrackingEvents { get; set; }
    }
}
