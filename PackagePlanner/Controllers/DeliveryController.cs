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
            Utilities.ShortestPathCalculator.ShortestPathFlight(wc, apiRequestParams.fromDestination, apiRequestParams.toDestination);


            var deliveryData = new DeliveryData()
            {
                price = apiRequestParams.packageWidth,
                route = new List<string>(),
                success = true,
                time = 8
            };

            return deliveryData;
        }
    }
}
