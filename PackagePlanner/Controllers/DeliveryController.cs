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

            return Utilities.ShortestPathCalculator.ShortestPathFlight(apiRequestParams, null);
            
            
        }

        public DeliveryData Get()
        {
            return new DeliveryData() { success = false };
        }
    }
}
