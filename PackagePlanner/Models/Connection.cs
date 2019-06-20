using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackagePlanner.Models
{
    public class Connection
    {
        public int Id { get; set; }
        public string Place1 { get; set; }
        public string Place2 { get; set; }
        public string ConnectionType { get; set; }
    }                              
}