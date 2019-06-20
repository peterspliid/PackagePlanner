using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using PackagePlanner.Models;

namespace PackagePlanner.Controllers
{
    public class DeliveryController : ApiController
    {
        public Delivery Get()
        {
            var delivery = new Delivery()
            {
                best = new DeliveryData()
                {
                    price = 100,
                    time = 2,
                    success = true,
                    route = new List<string>() { "Darfur", "Tripoli", "Somewhere"}
                },
                cheapest = new DeliveryData()
                {
                    price = 15,
                    time = 4,
                    success = true,
                    route = new List<string>() { "Darfur", "Tripoli", "Somewhere" }
                },
                fastest = new DeliveryData()
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
