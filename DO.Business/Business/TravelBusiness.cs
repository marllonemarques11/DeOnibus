using DO.Business.Contracts;
using DO.Data.Contracts;
using DO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public async Task<List<Travel>> GetTravels()
        {
            return await _travelRepository.GetTravels();
        }

        public bool InsertTravels(List<Travel> travels)
        {
            DataTable travelsDT = ConvertToDataTable(travels);
            return _travelRepository.InsertTravels(travelsDT);
        }

        public async Task<bool> DeleteTravels(string objectsId)
        {
            return await _travelRepository.DeleteTravels(objectsId);
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
