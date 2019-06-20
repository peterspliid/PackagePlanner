using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackagePlanner.Utilities
{
    public static class PriceTimeCalc
    {
        public static int calcPrice(double width, double height, double length, double weight)
        {
            List<Models.PriceCategory> priceCategories = Database.Instance.GetPriceCategory();
            List<Models.WeightCategory> weightCategories = Database.Instance.GetWeightCategory();
            List<Models.CargoSizeCategory> sizeCategories = Database.Instance.GetCargoSize();

            double largest = width < height && width < length ? width : (height < width && height < length ? height : length);

            if (largest <= 25)
            {
                return weight <= 1 ? 10 : (weight <= 5 ? 15 : 30);
            } else if (largest <= 40)
            {
                return weight <= 1 ? 15 : (weight <= 5 ? 25 : 60);
            } else
            {
                return weight <= 1 ? 20 : (weight <= 5 ? 35 : 90);
            }
        }
    }
}