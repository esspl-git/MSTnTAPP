using System;

namespace MSTnTAPP.Models
{
    public class Delivery
    {
        public string Reference { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? PODate { get; set; }
        public string Address { get; set; }
    }
}
