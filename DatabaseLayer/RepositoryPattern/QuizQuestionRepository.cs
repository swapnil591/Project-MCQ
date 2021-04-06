using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.RepositoryPattern;
using ModelClasses;


namespace DatabaseLayer.RepositoryPattern
{
    public class QuizQuestionRepository
    {
        public static List<QuizQuestionWithChoiceModel> GetQuestions(int? id)
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
    }
}
