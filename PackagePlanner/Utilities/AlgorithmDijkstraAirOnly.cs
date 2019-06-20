using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PackagePlanner.Models;

namespace PackagePlanner.Utilities
{
    public static class AlgorithmDijkstraAirOnly
    {
        public static int GetTotalPrice()
        {
            //ALL this can be replaced with new algorithm class
            //replace with call to algorithm
            ApiRequestParams parameters = new ApiRequestParams();
            parameters.SetApiRequestParamsToDefault();

            int totalPrice = APIHandling.GetPriceFromTelstarAPI(parameters.UpdateAndFormatDictionary());
            Console.Write("totalprice: " + totalPrice);
            return totalPrice;
        }
    }
}