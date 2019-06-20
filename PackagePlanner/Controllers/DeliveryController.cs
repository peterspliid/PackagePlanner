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
                    success = true
                },
                cheapest = new DeliveryData()
                {
                    price = 15,
                    time = 4,
                    success = true
                },
                fastest = new DeliveryData()
                {
                    price = 100,
                    time = 2,
                    success = true
                }
            };

            return delivery;
        }
    }
}
