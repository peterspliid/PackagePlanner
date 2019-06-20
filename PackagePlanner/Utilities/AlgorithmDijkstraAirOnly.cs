using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PackagePlanner.Models;

namespace PackagePlanner.Utilities
{
    public static class AlgorithmDijkstraAirOnly
    {
        public static double GetTotalPrice()
        {
            //ALL this can be replaced with new algorithm class

            ApiRequestParams parameters = new ApiRequestParams();
            parameters.SetApiRequestParamsToDefault();

            double totalPrice = APIHandling.GetPriceFromOceanicAirlinesAPI(parameters.UpdateAndFormatDictionary());
            Console.Write("totalprice: " + totalPrice);
            return totalPrice;
        }
    }
}