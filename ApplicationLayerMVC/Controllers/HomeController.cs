using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseLayer.RepositoryPattern;
using DatabaseLayer.Interfaces;

namespace ApplicationLayerMVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        IQuizRepository _quizRepository = null;

        public HomeController(IQuizRepository QuizRepo)
        {
            _quizRepository = QuizRepo;
        }

        // GET: Home
        public ActionResult Index()
        {
            var data = _quizRepository.QuizList();

            return View(data);
        }
    }
}