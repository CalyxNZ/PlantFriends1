using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlantFriends1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Find How-to Guides, Info on our Sources, and Read about our Story";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Reach out to the Creators of PlantFriends!";

            return View();
        }
    }
}