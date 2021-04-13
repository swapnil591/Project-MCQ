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
        UserRepository _userRepository = null;
        QuizRepository _quizRepository = null;
        public AccountController()
        {
            _userRepository = new UserRepository();
            _quizRepository = new QuizRepository();
        }


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
                var res = _userRepository.login(user);
                if (res != null)
                {

                    if (res.UserId != 0)
                    {
                        TempData["UserId"] = res.UserId;
                        TempData["UserName"] = res.FirstName + " " + res.LastName;

                        TempData.Keep();
                        TempData.Peek("UserId");

                        return RedirectToAction("UserProfile", "Account");
                    }

                }
            }

            ViewBag.Result = "User Not Exists";
            return View();

        }

        public ActionResult Logout()
        {
            TempData["UserId"] = null;
            return RedirectToAction("Index", "Home");
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
                int id = _userRepository.Register(user);

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


        public ActionResult UserProfile()
        {
            int UserId = 0;
            if (TempData["UserId"] != null)
            {
                UserId = (int)TempData["UserId"];


                var data = _userRepository.GetOneUser(UserId);
                ViewBag.Userdata = data;

                var quizData = _quizRepository.QuizListOfOneUser(UserId);

                ViewBag.QuizData = quizData;

                ViewBag.NoOfQuiz = quizData.Count;



                ViewBag.NoOfQue = 2;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }


            //  return RedirectToAction("Index","Home");
        }

    }
}