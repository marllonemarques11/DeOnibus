using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DO.Web.Models
{
    public class TravelViewModel
    {
        public string ObjectId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public float Price { get; set; }
        public string BussClass { get; set; }
    }
}
