using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCPractise.Models
{
    public class Customer
    {
        [Required]
        [RegularExpression("^[A-Z]{3,3}[0-9]{4,4}$")]
        public string CustomerCode { get; set; }

        [Required]
        [StringLength(10)]
        public string CustomerName { get; set; }
    }
}