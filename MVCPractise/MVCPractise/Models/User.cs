﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCPractise.Models
{
    public class User
    {
        [Key]
         public string UserName { get; set; }
         public string PassWord { get; set; }
    }
}