using System.Collections.Generic;

namespace MSTnTAPP.Models.Response
{
   public class ShipmentCarrierTrackingEventResponse:BaseAPIResponse
    {
        public List<CarrierTrackingEvent> CarrierTrackingEvents { get; set; }
    }
}
