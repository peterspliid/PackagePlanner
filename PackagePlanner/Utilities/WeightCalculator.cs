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
        private static Dictionary<string, List<Weight>> cachedWeights = new Dictionary<string, List<Weight>>();
        public WeightCalculator(Models.ApiRequestParams p)
        {
            parameters = p;
            connections = Database.Instance.GetConnections();
            flightConnections = connections.Where(cn => cn.ConnectionType == "oa").ToList();
            connectionsData = new Dictionary<string, Models.ConnectionData>();
            foreach (Models.Connection con in connections)
            {
                if (con.ConnectionType == "oa")
                {
                    Models.ConnectionData conData = new Models.ConnectionData
                    {
                        Weight = 1,
                        Type = "oa"
                    };
                    connectionsData[($"{con.Place1}-{con.Place2}")] = conData;
                    connectionsData[($"{con.Place2}-{con.Place1}")] = conData;
                }
            }
        }
        public Weight calc(string from, string to, string type, bool onlyFlight = true)
        {
            List<Weight> weights = new List<Weight>();
            string cacheString = $"{from}-{to}-{parameters.cargoType}-{parameters.packageWeight}-{parameters.packageLength}-{parameters.packageWidth}-{parameters.packageHeight}-{parameters.recorded}";
            if (cachedWeights.ContainsKey(cacheString))
            {
                weights = cachedWeights[cacheString];
            }
            else
            {
                cachedWeights[cacheString] = new List<Weight>();
                int price = PriceTimeCalc.calcPrice(parameters.packageWidth, parameters.packageHeight, parameters.packageLength, parameters.packageWeight);
                Weight weightOA = new Weight
                {
                    price = connectionsData.ContainsKey($"{from}-{to}") ? price : 0,
                    time = connectionsData.ContainsKey($"{from}-{to}") ? 8 : 0,
                    carrier = "oa"
                };
                cachedWeights[cacheString].Add(weightOA);
                if (!onlyFlight)
                {

                }
            }
            int bestWeight = type == "price" ? weights[0].price : weights[0].time;
            int bestIndex = 0;
            for (int i = 1; i < weights.Count; i++)
            {
                int w = type == "price" ? weights[i].price : weights[i].time;
                if (w < bestWeight)
                {
                    bestWeight = w;
                    bestIndex = i;
                }
            }
            return weights[bestIndex];
        }
    }
}