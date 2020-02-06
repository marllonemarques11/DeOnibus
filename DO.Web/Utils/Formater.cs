using DO.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DO.Web.Utils
{
    public class Formater
    {
        public void RemoveNumbersWithoutSense(List<TravelModel> travelModels)
        {
            foreach (var travel in travelModels)
            {
                if(travel.Price >= 10000)
                {
                    travel.Price = travel.Price / 100;
                }
                else if (travel.Price >= 1000)
                {
                    travel.Price = travel.Price / 10;
                }
                if (travel.Price.ToString().Length > 3)
                {
                    travel.Price = Math.Truncate(travel.Price * 100) / 100;
                }
            }
        }
    }
}
