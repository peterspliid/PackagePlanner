using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PackagePlanner.Models
{
    public class Connection
    {
        public string Place1 { get; set; }
        public string Place2 { get; set; }
        public string ConnectionType { get; set; }

        public Connection(DataRow row)
        {
            Place1 = (string)row[0];
            Place2 = (string)row[1];
            ConnectionType = (string)row[2];
        }
    }                              
}