using System.Collections.Generic;

namespace MSTnTAPP.Models.Response
{
    public class ShipmentDocumentResponse:BaseAPIResponse
    {
        public List<Document> Documents { get; set; }
    }
}
