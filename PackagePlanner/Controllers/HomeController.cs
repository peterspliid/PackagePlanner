using PackagePlanner.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PackagePlanner.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            Models.ApiRequestParams par = new Models.ApiRequestParams();
            par.SetApiRequestParamsToDefault();
            ShortestPathCalculator.ShortestPathFlight(par);
            ViewBag.Title = "Package Planner!";
            ViewBag.Cities = Database.Instance.GetCities();

            var weigthClasses = Database.Instance.GetWeightCatagories();
            ViewBag.WeightCategories = weigthClasses;
            ViewBag.CargoTypes = Database.Instance.GetCargoTypes();
            ViewBag.Customers = Database.Instance.GetCustomers();

            // ViewBag.Debug = AlgorithmDijkstraAirOnly.GetTotalPrice();

            return View();
        }
    }
}