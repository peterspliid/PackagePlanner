using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using PackagePlanner.Models;

namespace PackagePlanner.Controllers
{
    public class DeliveryController : ApiController
    {
        public DeliveryData Get(string fromDestination, string toDestination, int packageWeight, string cargoType, string recorded, int packageLength, int packageWidth, int packageHeight)
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
            Utilities.WeightCalculator wc = new Utilities.WeightCalculator(apiRequestParams);
            List<string> path = Utilities.ShortestPathCalculator.ShortestPathFlight(wc, apiRequestParams.fromDestination, apiRequestParams.toDestination);

            int pricePerSegment = Utilities.PriceTimeCalc.calcPrice(packageWidth, packageHeight, packageLength, packageWeight);
            int price = path.Count * pricePerSegment;
            var deliveryData = new DeliveryData()
            {
                price = price,
                route = path,
                success = true,
                time = 8 * path.Count
            };

            return deliveryData;
        }
    }
}
