using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using PackagePlanner.Models;

namespace PackagePlanner.Controllers
{
    public class DeliveryInternalController : ApiController
    {
        public Delivery Get()
        {
            var delivery = new Delivery()
            {
                best = new Models.DeliveryData()
                {
                    price = 100,
                    time = 2,
                    success = true,
                    route = new List<string>() { "Darfur", "Tripoli", "Somewhere"}
                },
                cheapest = new Models.DeliveryData()
                {
                    price = 15,
                    time = 4,
                    success = true,
                    route = new List<string>() { "Darfur", "Tripoli", "Somewhere" }
                },
                fastest = new Models.DeliveryData()
                {
                    price = 100,
                    time = 2,
                    success = true,
                    route = new List<string>() { "Darfur", "Tripoli", "Somewhere" }
                }
            };

            return delivery;
        }
    }
}
