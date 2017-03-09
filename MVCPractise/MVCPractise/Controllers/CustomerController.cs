using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractise.Models;
using MVCPractise.DAL;
using System.Text;
namespace MVCPractise.Controllers
{
    public class CustomerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objcontext = controllerContext.HttpContext;
            string CustomerCode = objcontext.Request.Form["CustomerName"];
            string CustomerName = objcontext.Request.Form["CustomerCode"];
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
            return View("EnterCustomer",new Customer());
        }
        public ActionResult Submit([ModelBinder (typeof(CustomerBinder) )] Customer obj)
        {
           
            if (ModelState.IsValid)
            {
                /* if valid  enter in db using entityframework model*/
                CustomerDal Dal = new CustomerDal();
                Dal.Customers.Add(obj);
                try
                {
                    
                    Dal.SaveChanges();
                }
                catch(System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    StringBuilder k = new StringBuilder();
                    foreach (var eve in e.EntityValidationErrors)
                    {

                        k.Append("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:");
                        k.Append(eve.Entry.Entity.GetType().Name);
                        k.Append( eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            k.Append("- Property: \"{0}\", Error: \"{1}\"");

                            k.Append(ve.PropertyName);
                            k.Append (ve.ErrorMessage);
                        }
                    }
                }
               
                return View("Load", obj);
            }
            else
            {
                return View("EnterCustomer",obj);
            }
            
        }
    }
}