using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using PackagePlanner.Models;

namespace PackagePlanner.Controllers
{
    public class SelectController : ApiController
    {
        public string GET(string fromDestination, string toDestination, int packageWeight, string cargoType, string recorded, int packageLength, int packageWidth, int packageHeight, int discount, int price, int time, string customerId)
        {
            PlannedPackage package = new PlannedPackage()
            {
                CustomerId = customerId,
                CargoTypeId = cargoType,
                Price = price,
                Discount = discount,
                FromCityId = fromDestination,
                ToCityId = toDestination,
                DeliveryTime = time,
                PackageHight = packageHeight,
                PackageLength = packageLength,
                PackageWidth = packageWeight,
                PriceCategoryId = "MN"
            };

            Utilities.Database.Instance.SetPlannedPackage(package);

            return "done logging in database";
        }
    }
}