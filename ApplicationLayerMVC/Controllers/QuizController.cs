using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseLayer.RepositoryPattern;
using ModelClasses;
using DatabaseLayer;

namespace ApplicationLayerMVC.Controllers
{
    public class QuizController : Controller
    {
        QuizRepository _quizRepository = null;
        QuizQuestionRepository _quizQuestionRepository = null;
        public QuizController()
        {
            _quizRepository = new QuizRepository();
            _quizQuestionRepository = new QuizQuestionRepository();
        }


        // GET: Quiz
        public ActionResult QuizGrid()
        {
            var data = _quizRepository.QuizList();
            return View(data);
        }


        public ActionResult QuizQuestionList(int? id)
        {
            var data = _quizQuestionRepository.GetQuestions(id);
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuizModel _Quizmodel)
        {
            if (ModelState.IsValid)
            {

                int id = _quizRepository.AddQuiz(_Quizmodel);

                if(id != 0)
                {
                    ViewBag.Message = "Quiz Created Successfully..!";
                }
                else
                {
                    ViewBag.Message = "Error Creating Quiz..!";
                }


                return RedirectToAction("UserProfile", "Account");
            }


            return View();            
        }

        public ActionResult AddQuestion(int id)
        {
            try
            {
                ViewBag.QuizID = id;
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddQuestion(QuizQuestionModel quizQuestionModel)
        {
            try
            {
                int id = _quizQuestionRepository.AddQuestion(quizQuestionModel);

                if(id !=0 || id != -1)
                {
                    ViewBag.message = "Success..!";
                }
                else
                {
                    ViewBag.message = "Error Creating Question";
                }


                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}