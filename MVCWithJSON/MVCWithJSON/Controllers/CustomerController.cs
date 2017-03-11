using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithJSON.Models;
namespace MVCWithJSON.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getCustomer()
        {
            Customer obj = new Customer();
            obj.CustomerCode = "1001";
            obj.CustomerName = "Shailesh";
            return Json(obj,JsonRequestBehavior.AllowGet);
        }
        public ActionResult DisplayCustomer()
        {
            getCustomer();
            return View("ConsumeCustomer");
        }
    }
}