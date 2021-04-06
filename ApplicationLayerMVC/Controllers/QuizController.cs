using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseLayer.RepositoryPattern;

namespace ApplicationLayerMVC.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult QuizGrid()
        {
            var data = QuizRepository.QuizList();
            return View(data);
        }


        public ActionResult QuizQuestionList(int? id)
        {
            var data = QuizQuestionRepository.GetQuestions(id);
            return View(data);
        }
    }
}