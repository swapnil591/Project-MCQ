using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelClasses;
using DatabaseLayer;
using DatabaseLayer.RepositoryPattern;
using System.Web.Security;
using DatabaseLayer.Interfaces;

namespace ApplicationLayerMVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        IUserRepository _userRepository = null;
        IQuizRepository _quizRepository = null;
        public AccountController(IUserRepository UserRepo, IQuizRepository QuizRepo)
        {
            _userRepository = UserRepo;
            _quizRepository = QuizRepo;
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
                        FormsAuthentication.SetAuthCookie(user.FirstName + " " + user.LastName, false);

                        Session["UserId"] = res.UserId;
                        TempData["UserId"] = res.UserId;

                        Session["UserName"] = res.FirstName + " " + res.LastName;
                        TempData["UserName"] = res.FirstName + " " + res.LastName;

                        TempData.Peek("UserName");
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
            Session["UserName"] = "";
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
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
            if (Session["UserId"] != null)
            {
                UserId = (int)Session["UserId"];

                var data = _userRepository.GetOneUser(UserId);
                ViewBag.Userdata = data;

                var quizData = _quizRepository.QuizListOfOneUser(UserId);

                ViewBag.QuizData = quizData;

                ViewBag.NoOfQuiz = quizData.Count;

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