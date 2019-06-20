using System.Data;

namespace PackagePlanner.Models
{
    public class Customer
    {
        public string id { get; set; }
        public string Name { get; set; }

        public Customer(DataRow row)
        {
            id = (string)row[0];
            Name = (string)row[1];
        }
    }
}