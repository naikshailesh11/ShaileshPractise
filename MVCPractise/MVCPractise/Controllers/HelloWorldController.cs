using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractise.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            TempData["MyTimeTemp"] = DateTime.Now.Date;
            ViewBag.MyTime = DateTime.Now.Date;
            //return View();
            return RedirectToAction("GoToHome", "HelloWorld");
        }
        public ActionResult GoToHome()
        {
            //ViewBag.MyTime = DateTime.Now.Date;
            ViewBag.CurrentTime = DateTime.Now.TimeOfDay;
            return View("MyHomePage");
        }
    }
}