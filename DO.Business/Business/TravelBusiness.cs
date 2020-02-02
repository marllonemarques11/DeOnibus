using DO.Business.Contracts;
using DO.Data.Contracts;
using DO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DO.Business.Business
{
    public class TravelBusiness: ITravelBusiness
    {
        private ITravelRepository _travelRepository;

        public TravelBusiness(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public Task<List<Travel>> GetTravels()
        {
            return _travelRepository.GetTravels();
        }

        public Task<bool> InsertTravels(DataTable travels)
        {
            return _travelRepository.InsertTravels(travels);
        }

        public Task<bool> DeleteTravel(string objectId)
        {
            return _travelRepository.DeleteTravel(objectId);
        }
    }
}
