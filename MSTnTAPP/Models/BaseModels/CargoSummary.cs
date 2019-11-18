using System.Collections.Generic;

namespace MSTnTAPP.Models
{
    public class CargoSummary
    {
        public List<Container> Containers { get; set; }
        public List<CargoDetail> CargoDetails { get; set; }
        public List<Delivery> Deliveries { get; set; }
        public List<Collection> Collections { get; set; }
    }
}
