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
            //replace with call to algorithm
            int totalPrice = APIHandling.GetPriceFromOceanicAirlinesAPI();
            return totalPrice;
        }
    }
}