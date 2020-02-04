using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DO.Web.Models
{
    public class ArrivalDate
    {
        [JsonProperty(PropertyName = "__type")]
        public string __type { get; set; }
        [JsonProperty(PropertyName = "iso")]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime iso { get; set; }
    }
}
