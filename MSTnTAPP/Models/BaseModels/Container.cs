using System.Collections.Generic;

namespace MSTnTAPP.Models
{
    public class Container
    {
        public string Type { get; set; }
        public string Number { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal Cube { get; set; }
        public int Cartons { get; set; }
        public string SealNumber { get; set; }
        public List<CargoDetail> CargoDetails { get; set; }

    }
}
