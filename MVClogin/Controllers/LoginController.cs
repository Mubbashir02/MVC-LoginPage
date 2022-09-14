using MVClogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVClogin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public object Autherize(MVClogin.Models.User usermodel1)
        {
            using (LoginDataBaseEntities db = new LoginDataBaseEntities())
            {
                
                var userDetails = db.Users.Where(x => x.UserName == usermodel1.UserName && x.Password == usermodel1.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    usermodel1.LoginErrorMessage ="wrong username or password";
                    return View("Index",usermodel1);
                }
                else
                {
                    Session["UserName"] = userDetails.UserName;
                    return RedirectToAction("Index", "Home");
                }

                
            }
               
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Login");
                }
    }
}