﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractise.Models;
using MVCPractise.DAL;
using System.Text;
using MVCPractise.ViewModel;
using System.Threading;
namespace MVCPractise.Controllers
{
    public class CustomerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objcontext = controllerContext.HttpContext;
            string CustomerCode = objcontext.Request.Form["customer.CustomerName"];
            string CustomerName = objcontext.Request.Form["customer.CustomerCode"];
            
            Customer obj = new Customer { CustomerCode = CustomerCode, CustomerName = CustomerName };
            return obj;

        } 
    }
   
    [Authorize]
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
            //view model
            CustomerViewModel obj = new CustomerViewModel();
            // fresh customer
            obj.customer = new Customer();
            Dal dal = new Dal();
            //list of customer
            
            
            return View("EnterCustomer",obj);
        }
        public ActionResult Submit()
        {


            //CustomerViewModel vm = new CustomerViewModel();
            Customer obj = new Customer();
            obj.CustomerName = Request.Form["Customer.CustomerName"];
            obj.CustomerCode = Request.Form["Customer.CustomerCode"];
            if (ModelState.IsValid)
            {
                // insert the customer object to database
                // EF DAL
                Dal Dal = new Dal();
                Dal.Customers.Add(obj); // in mmemory
                Dal.SaveChanges(); // physical commit
               
            }
            else
            {
                
            }
            Dal dal = new Dal();
            List<Customer> customerscoll = dal.Customers.ToList<Customer>();
           
            return Json(customerscoll,JsonRequestBehavior.AllowGet);

            //if (ModelState.IsValid)
            //{
            //    /* if valid  enter in db using entityframework model*/
            //    CustomerDal Dal = new CustomerDal();
            //    Dal.Customers.Add(obj);
            //    try
            //    {

            //        Dal.SaveChanges();
            //    }
            //    catch(System.Data.Entity.Validation.DbEntityValidationException e)
            //    {
            //        StringBuilder k = new StringBuilder();
            //        foreach (var eve in e.EntityValidationErrors)
            //        {

            //            k.Append("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:");
            //            k.Append(eve.Entry.Entity.GetType().Name);
            //            k.Append( eve.Entry.State);
            //            foreach (var ve in eve.ValidationErrors)
            //            {
            //                k.Append("- Property: \"{0}\", Error: \"{1}\"");

            //                k.Append(ve.PropertyName);
            //                k.Append (ve.ErrorMessage);
            //            }
            //        }
            //    }

            //    //return View("Load", obj);
            //}

            //else
            //{
            //    return View("EnterCustomer", obj);
            //}
            //return null;

        }
        public ActionResult SearchCustomer()
        {
            //CustomerViewModel obj = new CustomerViewModel();
            Dal dal = new Dal();
            string str = Request.Form["txtCustomerName"].ToString();
            List<Customer> customerscoll
                = (from x in dal.Customers
                   where x.CustomerName == str
                   select x).ToList<Customer>();
            //obj.customers = customerscoll;
            //return View("SearchCustomer", obj);
            //CustomerDal dal = new CustomerDal();
            //List<Customer> customerscoll = dal.Customers.ToList<Customer>();

            return Json(customerscoll, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EnterSearch()
        {
            //CustomerViewModel obj = new CustomerViewModel();
            //obj.customers = new List<Customer>();
            return View("SearchCustomer");
        }
        public ActionResult GetCustomers()
        {
            Dal dal = new Dal();
            //list of customer
            List<Customer> customersColl = dal.Customers.ToList<Customer>();
            Thread.Sleep(10000);
            return Json(customersColl, JsonRequestBehavior.AllowGet);
        }
    }
}