using System.Data;

namespace PackagePlanner.Models
{
    public class PlannedPackage
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string CargoTypeId { get; set; }
        public double Price { get; set; }
        public double DeliveryTime { get; set; }
        public double Discount { get; set; }
        public string FromCityId { get; set; }
        public string ToCityId { get; set; }
        public string PriceCategoryId { get; set; }
        public double PackageHight { get; set; }
        public double PackageWidth { get; set; }
        public double PackageLength { get; set; }

        public PlannedPackage(DataRow row)
        {
            Id = (string)row[0];
            CustomerId = (string)row[1];
            CargoTypeId = (string)row[2];
            Price = (double)row[3];
            DeliveryTime = (double)row[4];
            Discount = (double)row[5];
            FromCityId = (string)row[6];
            ToCityId = (string)row[7];
            PriceCategoryId = (string)row[8];
            PackageHight = (double)row[9];
            PackageWidth = (double)row[10];
            PackageLength = (double)row[11];
        }
    }
}