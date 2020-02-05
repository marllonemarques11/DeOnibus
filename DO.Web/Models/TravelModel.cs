using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DO.Web.Models
{
    public class TravelModel
    {
        [JsonProperty(PropertyName = "objectId")]
        public string objectId { get; set; }

        [JsonProperty(PropertyName = "Company")]
        public CompanyModel Company { get; set; }

        [JsonProperty(PropertyName = "Origin")]
        public string Origin { get; set; }

        [JsonProperty(PropertyName = "Destination")]
        public string Destination { get; set; }

        [JsonProperty(PropertyName = "DepartureDate")]
        public DepartureDateModel DepartureDate { get; set; }

        [JsonProperty(PropertyName = "ArrivalDate")]
        public ArrivalDate ArrivalDate { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public DateTime createdAt { get; set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public DateTime updatedAt { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public Double Price { get; set; }

        [JsonProperty(PropertyName = "BusClass")]
        public string BusClass { get; set; }
    }
}
