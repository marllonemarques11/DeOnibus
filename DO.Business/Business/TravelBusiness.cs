using DO.Business.Contracts;
using DO.Data.Contracts;
using DO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
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

        public async Task<bool> InsertTravels(List<Travel> travels)
        {
            DataTable travelsDT = ConvertToDataTable<Travel>(travels);
            return await _travelRepository.InsertTravels(travelsDT);
        }

        public async Task<bool> DeleteTravels(string objectsId)
        {
            return await _travelRepository.DeleteTravels(objectsId);
        }

        public static DataTable ConvertToDataTable<T>(List<T> list)
        {
            DataTable dt = new DataTable();
            if (list.Count > 0)
            {
                Type listType = list.ElementAt(0).GetType();
                PropertyInfo[] properties = listType.GetProperties();
                foreach (PropertyInfo property in properties)
                    dt.Columns.Add(new DataColumn() { ColumnName = property.Name });
                foreach (object item in list)
                {
                    DataRow dr = dt.NewRow();
                    foreach (DataColumn col in dt.Columns)
                        dr[col] = listType.GetProperty(col.ColumnName).GetValue(item, null);
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}
