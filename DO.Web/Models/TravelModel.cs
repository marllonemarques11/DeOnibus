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
        public string ObjectId { get; set; }

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
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updatedAt")]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Double Price { get; set; }

        [JsonProperty(PropertyName = "BusClass")]
        public string BusClass { get; set; }
    }
}
