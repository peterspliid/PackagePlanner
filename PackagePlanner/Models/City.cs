using System.Data;

namespace PackagePlanner.Models
{
    public class City
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public City(DataRow row)
        {
            Id = (string)row[0];
            Name = (string)row[1];
        }
    }
}