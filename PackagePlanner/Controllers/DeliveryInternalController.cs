using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using PackagePlanner.Models;

namespace PackagePlanner.Controllers
{
    public class DeliveryInternalController : ApiController
    {
        public Delivery Get(string fromDestination, string toDestination, int? packageWeight, string cargoType, int? packageLength, int? packageWidth, int? packageHeight, int? discount)
        {
            if (!packageWeight.HasValue || !packageLength.HasValue || !packageHeight.HasValue || !packageWeight.HasValue)
            {
                return ReturnError();
            }
            ApiRequestParams apiRequestParams = new ApiRequestParams()
            {
                fromDestination = fromDestination,
                toDestination = toDestination,
                packageWeight = packageWeight.Value,
                cargoType = cargoType,
                recorded = "false",
                packageHeight = packageHeight.Value,
                packageLength = packageLength.Value,
                packageWidth = packageWidth.Value
            };

            DeliveryData deliv = Utilities.ShortestPathCalculator.ShortestPathFlight(apiRequestParams, discount);

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
            return ReturnError();
        }

        private Delivery ReturnError()
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
