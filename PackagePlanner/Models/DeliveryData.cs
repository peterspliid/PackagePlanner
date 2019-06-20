using System.Collections.Generic;

namespace PackagePlanner.Models
{
    public struct DeliveryData
    {
        public bool success;
        public int price;
        public int time;
        public List<string> route;
    }
}