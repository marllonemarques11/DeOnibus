using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DO.Web.Models;
using DO.Domain.Entities;
using System.Globalization;

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

                entity.ObjectId = model.objectId;
                entity.Company = model.Company.Name;
                entity.Origin = model.Origin;
                entity.Destination = model.Destination;
                entity.DepartureDate = DateTime.ParseExact(model.DepartureDate.iso.ToString().Replace("/", "-"), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                entity.ArrivalDate = DateTime.ParseExact(model.ArrivalDate.iso.ToString().Replace("/", "-"), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                entity.BussClass = model.BusClass;
                entity.CreatedAt = DateTime.ParseExact(model.createdAt.ToString().Replace("/", "-"), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                entity.UpdatedAt = DateTime.ParseExact(model.updatedAt.ToString().Replace("/", "-"), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
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
                model.Company = new CompanyModel();
                model.DepartureDate = new DepartureDateModel();
                model.ArrivalDate = new ArrivalDate();

                model.objectId = entity.ObjectId;
                model.Company.Name = entity.Company;
                model.Origin = entity.Origin;
                model.Destination = entity.Destination;
                model.DepartureDate.iso = entity.DepartureDate;
                model.ArrivalDate.iso = entity.ArrivalDate;
                model.BusClass = entity.BussClass;
                model.createdAt = entity.CreatedAt;
                model.updatedAt = entity.UpdatedAt;
                model.Price = entity.Price;
                models.Add(model);
            }
            return models;
        }
    }
}
