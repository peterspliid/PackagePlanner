using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PackagePlanner.Utilities
{
    public sealed class Database
    {
        public static Database Instance
        {
            get { return Nested.instance; }
        }
        private SqlConnection _connection;

        private Database()
        {
            _connection = ConnectToDatabase();
            _connection.Open();
        }

        ~Database()
        {
            _connection.Close();
        }

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly Database instance = new Database();
        }

        private SqlConnection ConnectToDatabase()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PackagePlanner"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            return connection;
        }

        public List<string> GetCities()
        {
            var queryString = @"SELECT name FROM [dbo].[City]";
            return ExecuteQuery<string>(queryString);
        }

        public List<string> GetWeightCatagories()
        {
            var queryString = @"SELECT name FROM [dbo].[WeightCategory]";
            return ExecuteQuery<string>(queryString);
        }

        public List<Models.Connection> GetConnections()
        {
            string queryString = @"SELECT Place1, Place2, ConnectionType FROM [dbo].[Connection]";
            return ExecuteQueryToObject<Models.Connection>(queryString);
        }

        public List<T> ExecuteQueryToObject<T>(string queryString)
        {
            var returnValues = new List<T>();

            DataTable dataTable = new DataTable();
            var query = new SqlCommand(queryString, _connection);
            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(query);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                T item = (T)Activator.CreateInstance(typeof(T), row);
                returnValues.Add(item);
            }

            return returnValues;
        }
        public List<string> GetCargoTypes()
        {
            var queryString = @"SELECT name FROM [dbo].[CargoType]";
            return ExecuteQuery<string>(queryString);
        }

        public List<T> ExecuteQuery<T>(string queryString)
        {
            var returnValues = new List<T>();

            var query = new SqlCommand(queryString, _connection);
            var results = query.ExecuteReader();

            while (results.Read())
            {
                returnValues.Add((T)results[0]);
            }

            results.Close();
            return returnValues;
        }
    }
}