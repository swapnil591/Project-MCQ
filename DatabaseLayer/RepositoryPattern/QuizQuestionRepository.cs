using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.RepositoryPattern;
using ModelClasses;
using DatabaseLayer.Interfaces;

namespace DatabaseLayer.RepositoryPattern
{
    public class QuizQuestionRepository : IQuizQuestionRepository
    {
        public List<QuizQuestionWithChoiceModel> GetQuestions(int id)
        {
            using (var context = new MCQ_Quiz_DBEntities())
            {
                var QuestionList = context.tblQuizQuestions.Where(x => x.QuizId_fk == id).ToList();
                var ChoiceList = new List<DatabaseLayer.tblQuizChoice>();



                foreach (var question in QuestionList)
                {
                     ChoiceList = context.tblQuizChoices.Where(x => x.QuestionId == question.QuizQuestionId).ToList();
                }


                var db1 = (from a in context.tblQuizChoices
                           join b in context.tblQuizQuestions on a.QuestionId equals b.QuizQuestionId
                           join c in context.tblQuizs on b.QuizId_fk equals c.QuizId
                           where c.QuizId == id
                           select new QuizQuestionWithChoiceModel
                           {
                               QuizQuestionId = (int)a.QuestionId,
                               QuizId_fk = c.QuizId,
                               Question = b.Question,
                               Quiz_Choice_Id = a.Quiz_Choice_Id,
                               OptionTitle = a.OptionTitle

                           }).ToList();

                return db1;

            }
        }


        public int AddQuestion(QuizQuestionModel _quizQueModel)
        {
            try
            {
                using(var context = new MCQ_Quiz_DBEntities())
                {
                    /// first add question
                    tblQuizQuestion question = new tblQuizQuestion();
                    question.QuizId_fk = _quizQueModel.QuizId_fk;
                    question.Question = _quizQueModel.Question;
                    question.Type = _quizQueModel.Type;
                    question.CreatedOn = _quizQueModel.CreatedOn;
                    question.IsActive = _quizQueModel.IsActive;
                    question.CreatedBy = _quizQueModel.CreatedBy;

                    context.tblQuizQuestions.Add(question);
                    context.SaveChanges();


                    /// second add options
                    
                    //1
                    tblQuizChoice choice1 = new tblQuizChoice();
                    choice1.QuestionId = question.QuizQuestionId;
                    choice1.OptionTitle = _quizQueModel.option1;                    
                    choice1.CreatedON = _quizQueModel.CreatedOn;
                    choice1.CreatedBy = _quizQueModel.CreatedBy;
                    choice1.IsAnswer = false;
                    if (_quizQueModel.option1 == _quizQueModel.Answer)
                    {
                        choice1.IsAnswer = true;
                    }
                    context.tblQuizChoices.Add(choice1);
                    context.SaveChanges();

                    //2
                    tblQuizChoice choice2 = new tblQuizChoice();
                    choice2.QuestionId = question.QuizQuestionId;
                    choice2.OptionTitle = _quizQueModel.option2;
                    choice2.CreatedON = _quizQueModel.CreatedOn;
                    choice2.CreatedBy = _quizQueModel.CreatedBy;
                    choice2.IsAnswer = false;
                    if (_quizQueModel.option2 == _quizQueModel.Answer)
                    {
                        choice2.IsAnswer = true;
                    }

                    context.tblQuizChoices.Add(choice2);
                    context.SaveChanges();

                    //3
                    tblQuizChoice choice3 = new tblQuizChoice();
                    choice3.QuestionId = question.QuizQuestionId;
                    choice3.OptionTitle = _quizQueModel.option3;
                    choice3.CreatedON = _quizQueModel.CreatedOn;
                    choice3.CreatedBy = _quizQueModel.CreatedBy;
                    choice3.IsAnswer = false;
                    if (_quizQueModel.option3 == _quizQueModel.Answer)
                    {
                        choice3.IsAnswer = true;
                    }

                    context.tblQuizChoices.Add(choice3);
                    context.SaveChanges();

                    //4
                    tblQuizChoice choice4 = new tblQuizChoice();
                    choice4.QuestionId = question.QuizQuestionId;
                    choice4.OptionTitle = _quizQueModel.option4;
                    choice4.CreatedON = _quizQueModel.CreatedOn;
                    choice4.CreatedBy = _quizQueModel.CreatedBy;
                    choice4.IsAnswer = false;
                    if (_quizQueModel.option4 == _quizQueModel.Answer)
                    {
                        choice4.IsAnswer = true;
                    }
                    context.tblQuizChoices.Add(choice4);
                    context.SaveChanges();
                    return choice4.Quiz_Choice_Id;
                }
            }
            catch (Exception)
            {
                return -1; 
            }
        }

      
    }
}
