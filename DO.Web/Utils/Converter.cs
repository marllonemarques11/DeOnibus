using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DO.Web.Models;
using DO.Domain.Entities;

namespace DO.Web.Utils
{
    public class Converter
    {
        public List<Travel> ModeltoEntity(List<TravelModel> models)
        {
            List<Travel> entities = new List<Travel>();

            foreach (var model in models)
            {
                Travel entity = new Travel();

                entity.ObjectId = model.ObjectId;
                entity.Origin = model.Origin;
                entity.Destination = model.Destination;
                entity.DepartureDate = model.DepartureDate;
                entity.ArrivalDate = model.ArrivalDate;
                entity.BussClass = model.BussClass;
                entity.CreatedAt = model.CreatedAt;
                entity.UpdatedAt = model.UpdatedAt;
                entity.Price = model.Price;
                entities.Add(entity);
            }
            return entities;
        }

        public List<TravelModel> EntitytoMODEL(List<Travel> entities)
        {
            List<TravelModel> models = new List<TravelModel>();

            foreach (var entity in entities)
            {
                TravelModel model = new TravelModel();

                model.ObjectId = entity.ObjectId;
                model.Origin = entity.Origin;
                model.Destination = entity.Destination;
                model.DepartureDate = entity.DepartureDate;
                model.ArrivalDate = entity.ArrivalDate;
                model.BussClass = entity.BussClass;
                model.CreatedAt = entity.CreatedAt;
                model.UpdatedAt = entity.UpdatedAt;
                model.Price = entity.Price;
                models.Add(model);
            }
            return models;
        }
    }
}
