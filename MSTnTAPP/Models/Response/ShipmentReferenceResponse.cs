using System.Collections.Generic;
using System.Text;

namespace MSTnTAPP.Models.Response
{
    public class ShipmentReferenceResponse:BaseAPIResponse
    {
        public List<Reference> References { get; set; }
    }
}
