using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackagePlanner.Utilities
{
    public static class ShortestPathCalculator
    {
        public static List<Models.Connection> connections;
        public static List<Models.Connection> flightConnections;
        public static List<Models.City> cities;
        public static Dictionary<string, Models.ConnectionData> oaConnectionsData;
        static ShortestPathCalculator()
        {
            cities = Database.Instance.GetCity();
        }
        public static Models.DeliveryData ShortestPathFlight(Models.ApiRequestParams apiRequestParams, int? discount)
        {
            WeightCalculator wc = new WeightCalculator(apiRequestParams);
            PathWithWeights pathWithWeights = Dijkstra.DijkstraAlgorithm(wc, cities, apiRequestParams.fromDestination, apiRequestParams.toDestination, "time", true);
            List<string> path = pathWithWeights.path;
            if (path == null || CantFly(apiRequestParams))
            {
                return new Models.DeliveryData()
                {
                    success = false
                };
            }
            int pricePerSegment = PriceTimeCalc.calcPrice(apiRequestParams.packageWidth, apiRequestParams.packageHeight, apiRequestParams.packageLength, apiRequestParams.packageWeight);
            int price = path.Count * pricePerSegment;
            if (discount.HasValue)
            {
                price *= (100 - discount.Value);
                price /= 100;
            }
            var deliveryData = new Models.DeliveryData()
            {
                price = price,
                route = path,
                success = true,
                time = 8 * path.Count
            };

            return deliveryData;
        }

        public static Models.DeliveryData ShortestPath(Models.ApiRequestParams apiRequestParams, int? discount, string type)
        {
            WeightCalculator wc = new WeightCalculator(apiRequestParams);
            PathWithWeights pathWithWeights = Dijkstra.DijkstraAlgorithm(wc, cities, apiRequestParams.fromDestination, apiRequestParams.toDestination, type, false);
            int price = 0;
            int time = 0;
            if (pathWithWeights == null || pathWithWeights.path == null || pathWithWeights.path.Count == 0)
            {
                return new Models.DeliveryData()
                {
                    success = false
                };
            }
            foreach (Weight weight in pathWithWeights.weigths)
            {
                price += weight.price;
                time += weight.time;
            }
            if (discount.HasValue)
            {
                price *= (100 - discount.Value);
                price /= 100;
            }
            return new Models.DeliveryData()
            {
                price = price,
                route = pathWithWeights.path,
                success = true,
                time = time
            };
        }

        public static bool CantFly(Models.ApiRequestParams apiRequestParams)
        {
            return apiRequestParams.packageHeight > 200 || apiRequestParams.packageLength > 200 || apiRequestParams.packageWidth > 200 || apiRequestParams.packageWeight > 20 || apiRequestParams.recorded == "true" || (apiRequestParams.cargoType != "refr" && apiRequestParams.cargoType != "weap" && apiRequestParams.cargoType != "std");
        }
    }
}