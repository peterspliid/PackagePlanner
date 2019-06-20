using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using PackagePlanner.Models;

namespace PackagePlanner.Controllers
{
    public class SelectController : ApiController
    {
        public string GET(string CustomerID, string type, double price, double discount)
        {

            return "done logging in database";
        }
    }
}