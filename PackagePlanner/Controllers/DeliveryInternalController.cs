using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using PackagePlanner.Models;

namespace PackagePlanner.Controllers
{
    public class DeliveryInternalController : ApiController
    {
        public Delivery Get(string fromDestination, string toDestination, int packageWeight, string cargoType, string recorded, int packageLength, int packageWidth, int packageHeight)
        {
            ApiRequestParams apiRequestParams = new ApiRequestParams()
            {
                fromDestination = fromDestination,
                toDestination = toDestination,
                packageWeight = packageWeight,
                cargoType = cargoType,
                recorded = recorded,
                packageHeight = packageHeight,
                packageLength = packageLength,
                packageWidth = packageWidth
            };

            DeliveryData deliv = Utilities.ShortestPathCalculator.ShortestPathFlight(apiRequestParams);

            var delivery = new Delivery()
            {
                best = deliv,
                cheapest = deliv,
                fastest = deliv
            };

            return delivery;
        }

        public Delivery Get()
        {
            DeliveryData deliv = new DeliveryData() { success = false };
            return new Delivery()
            {
                best = deliv,
                cheapest = deliv,
                fastest = deliv
            };
        }
    }
}
