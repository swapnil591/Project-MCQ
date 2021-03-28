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
                bool res = UserRepository.login(user);

                if (res)
                {
                    ViewBag.Result = "Welcome -"+ user.FirstName + " "+ user.LastName;
                    return RedirectToAction("Index", "Home");
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

                if(id != 0)
                {
                    ViewBag.Result = "User Registered successfully";
                    return RedirectToAction("Index","Home");
                }
            }
            ViewBag.Result = "Something Went Wrong";
            return View();
        }
    }
}