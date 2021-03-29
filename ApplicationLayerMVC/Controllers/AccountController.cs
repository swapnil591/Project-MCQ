using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelClasses;
using DatabaseLayer;
using DatabaseLayer.RepositoryPattern;

namespace ApplicationLayerMVC.Controllers
{
    public class AccountController : Controller
    {


        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            // if (ModelState.IsValid)
            {
                string res = UserRepository.login(user);

                string data = "Welcome " + res;

                if (res != "")
                {                    
                    return RedirectToAction("Index", "Home", new {  data });
                }
            }

            ViewBag.Result = "User Not Exists";
            return View();

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                int id = UserRepository.Register(user);

                if (id == -1)
                {
                    var data = "User Already Registered with this email id";
                    // ViewBag.Result = "User Already Registered with this email id";
                    return RedirectToAction("Index", "Home", new { data });
                }

                else if (id != 0)
                {
                    var data = "User Registered successfully... Welcome " + user.FirstName + " " + user.LastName;
                    // ViewBag.Result = "User Registered successfully";
                    return RedirectToAction("Index", "Home", new { data });
                }

            }
            ViewBag.Result = "Something Went Wrong";
            return View();
        }
    }
}