using DO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DO.Data.Contracts
{
    public interface ITravelRepository
    {
        Task<List<Travel>> GetTravels();
        bool InsertTravels(DataTable travel);
        Task<bool> DeleteTravels(string objectId);
    }
}
