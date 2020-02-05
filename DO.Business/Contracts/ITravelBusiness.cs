using DO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DO.Business.Contracts
{
    public interface ITravelBusiness
    {
        Task<List<Travel>> GetTravels();
        bool InsertTravels(List<Travel> travels);
        Task<bool> DeleteTravels(string objectId);
    }
}
