using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerServer.Models
{
    public class Customer
    {
        public  string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerAmount { get; set; }
        public string SalesDateTime { get; set; }
    }
}