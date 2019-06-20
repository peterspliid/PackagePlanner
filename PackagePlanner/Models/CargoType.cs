using System.Data;

namespace PackagePlanner.Models
{
    public class CargoType
    {
            public string Id { get; set; }
            public string Name { get; set; }

            public CargoType(DataRow row)
            {
                Id = (string)row[0];
                Name = (string)row[1];
            }
    }
}