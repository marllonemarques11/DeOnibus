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
                entity.Company = model.Company.Name;
                entity.Origin = model.Origin;
                entity.Destination = model.Destination;
                entity.DepartureDate = model.DepartureDate.iso;
                entity.ArrivalDate = model.ArrivalDate.iso;
                entity.BussClass = model.BusClass;
                entity.CreatedAt = model.CreatedAt;
                entity.UpdatedAt = model.UpdatedAt;
                entity.Price = model.Price;
                entities.Add(entity);
            }
            return entities;
        }

        public List<TravelModel> EntitytoModel(List<Travel> entities)
        {
            List<TravelModel> models = new List<TravelModel>();

            foreach (var entity in entities)
            {
                TravelModel model = new TravelModel();

                model.ObjectId = entity.ObjectId;
                model.Company.Name = entity.Company;
                model.Origin = entity.Origin;
                model.Destination = entity.Destination;
                model.DepartureDate.iso = entity.DepartureDate;
                model.ArrivalDate.iso = entity.ArrivalDate;
                model.BusClass = entity.BussClass;
                model.CreatedAt = entity.CreatedAt;
                model.UpdatedAt = entity.UpdatedAt;
                model.Price = entity.Price;
                models.Add(model);
            }
            return models;
        }
    }
}
