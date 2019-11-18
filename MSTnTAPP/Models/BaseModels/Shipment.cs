using System;

namespace MSTnTAPP.Models
{
    public class Shipment
    {
        public string JobId { get; set; }
        public string JobType { get; set; }
        public string JobReferenceNumber { get; set; }
        public string TransportType { get; set; }
        public string TransportDirection { get; set; }
        public string ConsigneeName { get; set; }
        public DateTime? DateSailed { get; set; }


        //Required for overview tab
        public string CustomerReference { get; set; }
        public string PlaceOfReceipt { get; set; }
        public string VesselName { get; set; }
        public string PortOfLoading { get; set; }
        public string PortOfDischarge { get; set; }
        public string FinalDestination { get; set; }
        public DateTime? ETA { get; set; }
        public string Pieces { get; set; }
        public string Summary { get; set; }
        public string ShipperName { get; set; }
    }
}
