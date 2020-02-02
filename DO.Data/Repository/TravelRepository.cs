using DO.Data.Contracts;
using DO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DO.Data.Repository
{
    public class TravelRepository : ITravelRepository
    {
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DeOnibusDB;Integrated Security=True";
        private SqlTransaction transaction;

        public Task<List<Travel>> GetTravels()
        {
            string query = @"select * from tbTravel";
            try
            {
                List<Travel> travels = new List<Travel>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Travel travel = new Travel();
                            travel.ObjectId = Convert.ToString(reader["ObjectId"]);
                            travel.Origin = Convert.ToString(reader["Origin"]);
                            travel.Destination = Convert.ToString(reader["Destination"]);
                            travel.DepartureDate = Convert.ToDateTime(reader["DepartureDate"]);
                            travel.ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"]);
                            travel.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                            travel.UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"]);
                            travel.Price = Convert.ToDouble(reader["Price"]);
                            travel.BussClass = Convert.ToString(reader["BussClass"]);
                            travels.Add(travel);
                        }
                    }
                    conn.Close();
                }
                return Task.FromResult(travels);
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public Task<bool> InsertTravels(DataTable travels)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    var bc = new SqlBulkCopy(conn)
                    {
                        DestinationTableName = "dbo.tbTravel"
                    };
                    bc.WriteToServer(travels);

                    conn.Close();
                }
                return Task.FromResult(true);
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteTravel(string objectId)
        {
            string query = @"delete from tbTravel where ObjectId = @ObjectId";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@ObjectId", objectId);
                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                return Task.FromResult(true);
            }
            catch (SqlException ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
