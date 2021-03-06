﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DO.Web.Models
{
    public class DeOnibusModel
    {
        public List<TravelModel> FavoriteTravels { get; set; }
        [JsonProperty(PropertyName = "results")]
        public List<TravelModel> TravelsAvailable { get; set; }
    }
}
