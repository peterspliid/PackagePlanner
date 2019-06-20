using System.Data;

namespace PackagePlanner.Models
{
    public class CargoSize
    {
        public string Id { get; set; }
        public int MaxSize { get; set; }
        public string Unit { get; set; }

        public CargoSize(DataRow row)
        {
            Id = (string)row[0];
            MaxSize = (int)row[1];
            Unit = (string)row[2];
        }
    }
}