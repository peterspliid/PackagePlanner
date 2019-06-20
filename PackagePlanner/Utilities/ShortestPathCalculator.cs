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
            //connections = Database.Instance.GetConnections();
            //flightConnections = connections.Where(cn => cn.ConnectionType == "oa").ToList();
            cities = Database.Instance.GetCity();
            //oaConnectionsData = new Dictionary<string, Models.ConnectionData>();

            //foreach(Models.Connection con in connections)
            //{
            //    if (con.ConnectionType == "oa")
            //    {
            //        Models.ConnectionData conData = new Models.ConnectionData
            //        {
            //            Weight = 1,
            //            Type = "oa"
            //        };
            //        oaConnectionsData[($"{con.Place1}-{con.Place2}")] = conData;
            //        oaConnectionsData[($"{con.Place2}-{con.Place1}")] = conData;
            //    }
            //}


        }
        public static List<string> ShortestPathFlight(Utilities.WeightCalculator weightCalculator, string from, string to)
        {
            List<string> path = Dijkstra.DijkstraAlgorithm(weightCalculator, cities, from, to);
            return path;
        }
    }
}