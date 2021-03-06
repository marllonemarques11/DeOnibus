﻿using DO.Data.Contracts;
using DO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DO.Data.Repository
{
    public class TravelRepository : ITravelRepository
    {
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DeOnibusDB;Integrated Security=True";
        private SqlTransaction transaction;

        public async Task<List<Travel>> GetTravels()
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
                            travel.Company = Convert.ToString(reader["Company"]);
                            travels.Add(travel);
                        }
                    }
                    conn.Close();
                }
                return await Task.FromResult(travels);
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<bool> InsertTravels(DataTable travels)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    var bc = new SqlBulkCopy(conn, SqlBulkCopyOptions.FireTriggers, transaction);

                    bc.DestinationTableName = "dbo.tbTravel";
                    bc.ColumnMappings.Add("ObjectId", "ObjectId");
                    bc.ColumnMappings.Add("Origin", "Origin");
                    bc.ColumnMappings.Add("Destination", "Destination");
                    bc.ColumnMappings.Add("DepartureDate", "DepartureDate");
                    bc.ColumnMappings.Add("ArrivalDate", "ArrivalDate");
                    bc.ColumnMappings.Add("CreatedAt", "CreatedAt");
                    bc.ColumnMappings.Add("UpdatedAt", "UpdatedAt");
                    bc.ColumnMappings.Add("Price", "Price");
                    bc.ColumnMappings.Add("BussClass", "BussClass");
                    bc.ColumnMappings.Add("Company", "Company");

                    bc.WriteToServer(travels);

                    transaction.Commit();

                    conn.Close();
                }
                return await Task.FromResult(true);
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteTravels(string objectsId)
        {
            string query = @"delete from tbTravel where ObjectId in (select * from STRING_SPLIT(@ObjectsId, ','))";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("@ObjectsId", objectsId);
                        command.CommandText = query;
                        command.Connection = conn;
                        int rowsAffected = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                return await Task.FromResult(true);
            }
            catch (SqlException ex)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
