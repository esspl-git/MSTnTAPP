using System.Collections.Generic;

namespace MSTnTAPP.Models.Response
{
    public class ShipmentTrackingResponse : BaseAPIResponse
    {
        public List<Tracking> TrackingInfoList { get; set; }
    }
}
