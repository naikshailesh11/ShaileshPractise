﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractise.Models;
namespace MVCPractise.Controllers
{
    public class CustomerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objcontext =controllerContext.HttpContext;
            string CustomerCode = objcontext.Request.Form["txtCustomerCode"];
            string CustomerName = objcontext.Request.Form["txtCustomerName"];
            Customer obj = new Customer { CustomerCode = CustomerCode, CustomerName = CustomerName };
            return obj;

        }
    }

    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Load()
        {
            Customer obj = new Customer { CustomerCode="101",CustomerName="Shailesh Naik"};
            return View("Load",obj);
        }

        public ActionResult Enter()
        {
            return View("EnterCustomer");
        }
        public ActionResult Submit([ModelBinder (typeof(CustomerBinder) )] Customer obj)
        {
            //Customer obj = new Customer();
            //obj.CustomerCode = Request.Form["CustomerCode"];
            //obj.CustomerName = Request.Form["CustomerName"];
            return View("Load",obj);
        }
    }
}