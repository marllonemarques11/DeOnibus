using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Domain.Entities
{
    public class Travel
    {
        public int ID { get; set; }
        public string ObjectId { get; set; }
        public string Company { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public double Price { get; set; }
        public string BussClass { get; set; }
    }
}
