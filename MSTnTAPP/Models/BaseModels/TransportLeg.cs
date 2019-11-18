using System;

namespace MSTnTAPP.Models
{
    public class TransportLeg
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? EstimatedDeparture { get; set; }
        public DateTime? ActualDeparture { get; set; }
        public DateTime? EstimatedArrival { get; set; }
        public DateTime? ActualArrival { get; set; }
        public string VoyageFlightNumber { get; set; }
    }
}
