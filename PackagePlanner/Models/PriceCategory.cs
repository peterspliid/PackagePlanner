using System.Data;

namespace PackagePlanner.Models
{
    public class PriceCategory
    {
        public string Id { get; set; }
        public string CargoSizeCategoryId { get; set; }
        public string WeightCategoryId { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        public PriceCategory(DataRow row)
        {
            Id = (string)row[0];
            CargoSizeCategoryId = (string)row[1];
            WeightCategoryId = (string)row[2];
            Price = (double)row[3];
            Currency = (string)row[4];
        }
    }
}