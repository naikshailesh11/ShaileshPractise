using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerServer.Models;
namespace CustomerServer.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        List<Customer> cust=new List<Customer>();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public List<Customer> Post(Customer obj)
        {
         
            cust.Add(obj);
            return cust;
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
