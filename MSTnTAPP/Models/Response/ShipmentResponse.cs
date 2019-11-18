using System.Collections.Generic;

namespace MSTnTAPP.Models.Response
{
    public class ShipmentResponse : BaseAPIResponse
    {
        public List<Shipment> Shipments { get; set; }
    }
}
