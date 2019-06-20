using System.Collections.Generic;

namespace PackagePlanner.Models
{
    public struct DeliveryData
    {
        public bool success;
        public double price;
        public double time;
        public List<string> route;
    }
}