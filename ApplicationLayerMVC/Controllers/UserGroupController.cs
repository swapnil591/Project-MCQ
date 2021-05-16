using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseLayer.RepositoryPattern;
using ModelClasses;
using DatabaseLayer.Interfaces;

namespace ApplicationLayerMVC.Controllers
{
    public class UserGroupController : Controller
    {
        IUserGroupRepository _UGRepo = null;
        IUserRepository  _UserRepo = null;
        IQuizRepository _QuizRepo = null;

        public UserGroupController(IUserGroupRepository UserGrpRepo, IUserRepository UserRepo, IQuizRepository QuizRepo)
        {
            _UGRepo = UserGrpRepo;
            _UserRepo = UserRepo;
            _QuizRepo = QuizRepo;
        }


        // GET: UserGroup
        public ActionResult Index()
        {
            var data = _UGRepo.GetListOfUserGrp();

            return View(data);
        }

        public ActionResult CreateUserGroup()
        {
            ViewBag.Roles = _UGRepo.GetAllRoles();
            ViewBag.Users = _UserRepo.GetAllUser();
            ViewBag.Quiz = _QuizRepo.QuizList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateUserGroup(UserGroupModel UGM)
        {
            int id = _UGRepo.CreateUserGroup(UGM);

            if (id != 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMsg = "Error Adding User Group..!";
                return View();
            }            
        }


        public ActionResult EditUserGroup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditUserGroup(UserGroupModel UGM)
        {
            bool result = _UGRepo.EditUserGroup(UGM);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMsg = "Error Editing User Group..!";

                return View();
            }
        }
    }
}