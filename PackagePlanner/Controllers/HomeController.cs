using PackagePlanner.Utilities;
using System.Web.Mvc;

namespace PackagePlanner.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Package Planner!";
            ViewBag.Cities = Database.Instance.GetCities();

            //ViewBag.WeightCategories = GetWeightCatagories();

            return View();
        }
    }
}