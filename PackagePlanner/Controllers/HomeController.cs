using PackagePlanner.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PackagePlanner.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            ViewBag.Title = "Package Planner!";
            ViewBag.Cities = Database.Instance.GetCity();

            var weigthClasses = Database.Instance.GetWeightCatagories();
            ViewBag.WeightCategories = weigthClasses;
            ViewBag.CargoTypes = Database.Instance.GetCargoTypes();
            ViewBag.Customers = Database.Instance.GetCustomers();

            //ViewBag.Debug = AlgorithmDijkstraAirOnly.GetDeliveryData().price;

            return View();
        }
    }
}