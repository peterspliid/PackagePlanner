﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackagePlanner.Models
{
    public class ConnectionData
    {
        public int Weight { get; set; }
        public HashSet<string> Type { get; set; }
    }
}