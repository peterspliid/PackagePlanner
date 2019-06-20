using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Management;

namespace PackagePlanner.Models
{
    public class DeliveryApi
    {
        public bool success;
        public int price;
        public int time;

        public DeliveryApi(bool Success, int Price, int Time)
        {
            success = Success;
            price = Price;
            time = Time;
        }
    }
}