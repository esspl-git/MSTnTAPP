using System.Collections.Generic;

namespace MSTnTAPP.Models.Response
{
    public class ShipmentAddressPartiesResponse : BaseAPIResponse
    {
        public List<AddressParty> AddressParties { get; set; }
    }
}
