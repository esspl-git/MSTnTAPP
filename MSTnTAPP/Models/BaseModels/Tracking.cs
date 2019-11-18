using System;

namespace MSTnTAPP.Models
{
    public class Tracking
    {
        public string LocationType { get; set; }
        public string LocationName { get; set; }
        public DateTime? OriginalEstimated { get; set; }
        public DateTime? CurrentEstimated { get; set; }
        public DateTime? ConfirmedActual { get; set; }
    }
}
