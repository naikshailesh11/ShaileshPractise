using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractise.DAL;
using MVCPractise.Models;
using System.Web.Security;
namespace MVCPractise.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult authenticate()
        {
            return View("Login");
        }
        public ActionResult Validate()
        {
            string UserName = Request.Form["UserName"];
            string PassWord = Request.Form["PassWord"];
            Dal Dal = new Dal();
            List<User> Users  = (from u in Dal.Users
                                where (u.UserName==UserName) && (u.PassWord==PassWord)
                                select u
                                ).ToList<User>()
                                ;

            if(Users.Count==1)
            {
                FormsAuthentication.SetAuthCookie("Cookie", true);
                return View("GotoHome");
            }
            else
            {
                return View("Login");
            }
        }
        
    }
}