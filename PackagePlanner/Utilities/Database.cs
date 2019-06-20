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


        public void SetCity(Models.City city)
        {
            var queryString = @"INSERT into [dbo].[City]" +
                "(Id, name)" +
                "VALUES(@Id, @Name)";
            SqlCommand cmd = new SqlCommand(queryString, _connection);
            cmd.Parameters.Add("@Id", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = city.Id;
            cmd.Parameters["@Name"].Value = city.Name;

            cmd.ExecuteNonQuery();
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

        public List<Models.CargoSizeCategory> GetCargoSize()
        {
            string queryString = @"SELECT Id, MaxSize, Unit FROM [dbo].[CargoSizeCategory]";
            return ExecuteQueryToObject<Models.CargoSizeCategory>(queryString);
        }

        public List<Models.CargoType> GetCargoTypes()
        {
            string queryString = @"SELECT Id, Name FROM [dbo].[CargoType]";
            return ExecuteQueryToObject<Models.CargoType>(queryString);
        }

        public List<Models.Config> GetConfigs()
        {

            string queryString = @"SELECT Name, Value FROM [dbo].[Config]";
            return ExecuteQueryToObject<Models.Config>(queryString);
        }

        public List<Models.PriceCategory> GetPriceCategory()
        {
            string queryString = @"SELECT Id, CargoSizeCategoryId, WeightCategoryId, Price, Currency FROM [dbo].[PriceCategory]";
            return ExecuteQueryToObject<Models.PriceCategory>(queryString);
        }

        public List<Models.WeightCategory> GetWeightCategory()
        {
            string queryString = @"SELECT Id, CargoSizeCategoryId, WeightCategoryId, Price, Currency FROM [dbo].[WeightCategory]";
            return ExecuteQueryToObject<Models.WeightCategory>(queryString);
        }
        public List<Models.Customer> GetCustomers()
        {
            string queryString = @"SELECT Id, Name, FROM [dbo].[Customer]";
            return ExecuteQueryToObject<Models.Customer>(queryString);
        }

        public void SetPlannedPackage(Models.City PlannedPackage)
        {
            var queryString = @"INSERT into [dbo].[PlannedPackage]" +
                "(Id, " +
                "CustomerId, " +
                "CargoTypeId, " +
                "Price, " +
                "DeliveryTime, " +
                "Discount, " +
                "FromCityId, " +
                "ToCityId, " +
                "PriceCategoryId, " +
                "PriceCategory(Id)," +
                " PackageHight, " +
                "PackageWidth, " +
                "PackageLength)" +

                "VALUES(@Id, @Name)";

            SqlCommand cmd = new SqlCommand(queryString, _connection);
            cmd.Parameters.Add("@Id", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = city.Id;
            cmd.Parameters["@Name"].Value = city.Name;

            cmd.ExecuteNonQuery();
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

        public List<string> GetCustomers()
        {
            var queryString = @"SELECT id FROM [dbo].[Customer]";
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