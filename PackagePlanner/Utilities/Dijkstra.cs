using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackagePlanner.Utilities
{
    public class Dijkstra
    {

        public static List<string> DijkstraAlgorithm(WeightCalculator weightCalculator, List<string> cities, string sourceNode, string destinationNode)
        {
            var n = cities.Count();

            var distance = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                distance[cities[i]] = int.MaxValue;
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
                    if (!used[i] && minDistance > distance[cities[i]])
                    {
                        minDistance = distance[cities[i]];
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
                    Weight weight = weightCalculator.calc();
                    //if (graph[minNode, i] > 0)
                    if (weight.time > 0)
                    {
                        var shortestToMinNode = distance[cities[minNode]];
                        var distanceToNextNode = weight.time;

                        var totalDistance = shortestToMinNode + distanceToNextNode;

                        if (totalDistance < distance[cities[i]])
                        {
                            distance[cities[i]] = totalDistance;
                            previous[cities[i]] = cities[minNode];
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
            while (currentNode != null)
            {
                path.AddFirst(currentNode);
                currentNode = previous[currentNode];
            }

            return path.ToList();
        }

    }
}