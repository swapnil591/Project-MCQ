using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseLayer.RepositoryPattern;

namespace ApplicationLayerMVC.Controllers
{
    public class HomeController : Controller
    {
        QuizRepository _quizRepository = null;

        public HomeController()
        {
            _quizRepository = new QuizRepository();
        }

        // GET: Home
        public ActionResult Index()
        {

            var data = _quizRepository.QuizList();

            return View(data);
        }
    }
}