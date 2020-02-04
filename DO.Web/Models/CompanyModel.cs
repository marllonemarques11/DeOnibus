using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DO.Web.Models
{
    public class CompanyModel
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
