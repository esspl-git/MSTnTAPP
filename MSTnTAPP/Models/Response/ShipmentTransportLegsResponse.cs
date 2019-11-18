using System.Collections.Generic;

namespace MSTnTAPP.Models.Response
{
    public class ShipmentTransportLegsResponse : BaseAPIResponse
    {
        public List<TransportLeg> TransportLegs { get; set; }
    }
}
