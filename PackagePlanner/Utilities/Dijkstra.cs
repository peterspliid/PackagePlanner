using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackagePlanner.Utilities
{
    public class Dijkstra
    {

        public static List<string> DijkstraAlgorithm(WeightCalculator weightCalculator, List<Models.City> cities, string sourceNode, string destinationNode)
        {
            var n = cities.Count();

            var distance = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                distance[cities[i].Id] = int.MaxValue;
            }

            distance[sourceNode] = 0;

            var used = new bool[n];
            var previous = new Dictionary<string, string>();

            while (true)
            {
                var minDistance = int.MaxValue;
                var minNode = 0;
                for (int i = 0; i < n; i++)
                {
                    if (!used[i] && minDistance > distance[cities[i].Id])
                    {
                        minDistance = distance[cities[i].Id];
                        minNode = i;
                    }
                }

                if (minDistance == int.MaxValue)
                {
                    break;
                }

                used[minNode] = true;

                for (int i = 0; i < n; i++)
                {
                    Weight weight = weightCalculator.calc(cities[minNode].Id, cities[i].Id);
                    if (cities[minNode].Id == cities[i].Id)
                    {
                        Console.WriteLine("");
                    }
                    //if (graph[minNode, i] > 0)
                    if (weight.time > 0)
                    {
                        var shortestToMinNode = distance[cities[minNode].Id];
                        var distanceToNextNode = weight.time;

                        var totalDistance = shortestToMinNode + distanceToNextNode;

                        if (totalDistance < distance[cities[i].Id])
                        {
                            distance[cities[i].Id] = totalDistance;
                            previous[cities[i].Id] = cities[minNode].Id;
                        }
                    }
                }
            }

            if (distance[destinationNode] == int.MaxValue)
            {
                return null;
            }

            var path = new LinkedList<string>();
            string currentNode = destinationNode;
            while (currentNode != null && currentNode != sourceNode)
            {
                path.AddFirst(currentNode);
                currentNode = previous[currentNode];
            }

            return path.ToList();
        }

    }
}