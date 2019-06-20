using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using PackagePlanner.Models;

namespace PackagePlanner.Controllers
{
    public class SelectController : ApiController
    {
        public string GET(string CustomerID, string type, double price, double discount)
        {
            PlannedPackage package = new PlannedPackage()
            {
                CustomerId = CustomerID,
                CargoTypeId = type,
                Price = price,
                Discount = discount

            };

            return "done logging in database";
        }
    }
}