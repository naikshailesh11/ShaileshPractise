using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCPractise.Models;
namespace MVCPractise.ViewModel
{
    public class CustomerViewModel
    {
        public Customer customer { get; set; }
        public List<Customer> customers { get; set; }
    }
}