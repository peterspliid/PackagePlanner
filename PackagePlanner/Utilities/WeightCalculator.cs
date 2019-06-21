using PackagePlanner.Models;
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
        private Dictionary<string, Models.ConnectionData> connectionsData;
        private static Dictionary<string, List<Weight>> cachedWeights = new Dictionary<string, List<Weight>>();
        public WeightCalculator(Models.ApiRequestParams p)
        {
            parameters = p;
            connections = Database.Instance.GetConnections();
            connectionsData = new Dictionary<string, Models.ConnectionData>();
            foreach (Models.Connection con in connections)
            {
                if (!connectionsData.ContainsKey($"{con.Place1}-{con.Place2}"))
                {
                    Models.ConnectionData conData = new Models.ConnectionData
                    {
                        Weight = 1,
                        Type = new HashSet<string>() 
                    };
                    conData.Type.Add(con.ConnectionType);
                    connectionsData[($"{con.Place1}-{con.Place2}")] = conData;
                    connectionsData[($"{con.Place2}-{con.Place1}")] = conData;
                } else
                {
                    connectionsData[($"{con.Place1}-{con.Place2}")].Type.Add(con.ConnectionType);
                    connectionsData[($"{con.Place2}-{con.Place1}")].Type.Add(con.ConnectionType);
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
                bool hasConnection = connectionsData.ContainsKey($"{from}-{to}") && connectionsData[$"{from}-{to}"].Type.Contains("oa") && !ShortestPathCalculator.CantFly(parameters);
                Weight weightOA = new Weight
                {
                    price = hasConnection ? price : 0,
                    time = hasConnection ? 8 : 0,
                    carrier = "oa"
                };
                cachedWeights[cacheString].Add(weightOA);
                if (!onlyFlight)
                {
                    if (connectionsData.ContainsKey($"{from}-{to}") && connectionsData[$"{from}-{to}"].Type.Contains("tsl"))
                    {
                        DeliveryData delivery = APIHandling.GetApiDeliveryDataFromTelstarAPI(parameters.UpdateAndFormatDictionary());
                        cachedWeights[cacheString].Add(new Weight()
                        {
                            time = (int)delivery.time,
                            price = (int)delivery.price,
                            carrier = "tsl"
                        });
                    } if (connectionsData.ContainsKey($"{from}-{to}") && connectionsData[$"{from}-{to}"].Type.Contains("eit"))
                    {
                        DeliveryData delivery = APIHandling.GetApiDeliveryDataFromEITcompanyAPI(parameters.UpdateAndFormatDictionary());
                        cachedWeights[cacheString].Add(new Weight()
                        {
                            time = (int)delivery.time,
                            price = (int)delivery.price,
                            carrier = "eit"
                        });
                    }
                }
            }
            weights = cachedWeights[cacheString];
            int bestWeight = type == "price" ? weights[0].price : weights[0].time;
            int bestIndex = 0;
            for (int i = 1; i < weights.Count; i++)
            {
                int w = type == "price" ? weights[i].price : weights[i].time;
                if (w < bestWeight || bestWeight == 0)
                {
                    bestWeight = w;
                    bestIndex = i;
                }
            }
            return weights[bestIndex];
        }
    }
}