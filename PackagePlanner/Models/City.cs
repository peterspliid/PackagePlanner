using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PackagePlanner.Models
{
    public class City
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public City(DataRow row)
        {
            Id = (string)row[0];
            Name = (string)row[1];
        }
    }
}