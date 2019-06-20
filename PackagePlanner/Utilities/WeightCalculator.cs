using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackagePlanner.Utilities
{
    public class Weight
    {
        public int price { get; set; }
        public int time { get; set; }
        public string carrier { get; set; }
    }
    public class WeightCalculator
    {
        private Models.ApiRequestParams parameters { get; set; }

        private List<Models.Connection> connections;
        private List<Models.Connection> flightConnections;
        private Dictionary<string, Models.ConnectionData> connectionsData;
        private static Dictionary<string, Weight> cachedWeights = new Dictionary<string, Weight>();
        public WeightCalculator(Models.ApiRequestParams p, Dictionary<string, Models.ConnectionData> cd)
        {
            parameters = p;
            connectionsData = cd;
        }
        public Weight calc()
        {
            string cacheString = $"{parameters.fromDestination}-{parameters.toDestination}-{parameters.cargoType}-{parameters.packageWeight}-{parameters.packageLength}-{parameters.packageWidth}-{parameters.packageHeight}-{parameters.recorded}";
            if (cachedWeights.ContainsKey(cacheString))
            {
                return cachedWeights[cacheString];
            }
            Weight weight = new Weight
            {
                price = 1,
                time = 1,
                carrier = "oa"
            };
            cachedWeights[cacheString] = weight;
            return weight;

        }
    }
}