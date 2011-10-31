using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinosaursWithLasers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Test()
        {
            ViewBag.Message = "This is my test message!";
            return View("Index");
        }
        
        public ActionResult Index()
        {
            ViewBag.Message = "What could be more awesome than Dinosaurs with Lasers?";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Dinosaurs()
        {
            return View();
        }
    }
}
