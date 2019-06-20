using System.Data;

namespace PackagePlanner.Models
{
    public class WeightCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public WeightCategory(DataRow row)
        {
            Id = (string)row[0];
            Name = (string)row[1];
        }
    }
}