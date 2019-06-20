using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using PackagePlanner.Models;

namespace PackagePlanner.Controllers
{
    public class DeliveryController : ApiController
    {
        public DeliveryApi Get()
        {
            return new DeliveryApi(true, 20, 16);
        }
    }
}
