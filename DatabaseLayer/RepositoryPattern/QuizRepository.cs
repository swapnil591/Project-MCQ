using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelClasses;

namespace DatabaseLayer.RepositoryPattern
{
    public class QuizRepository
    {
        public List<QuizModel> QuizList()
        {
            using (var context = new MCQ_Quiz_DBEntities())
            {
                return context.tblQuizs.Select(x => new QuizModel
                {
                    QuizId = x.QuizId,
                    Title = x.Title,
                    Summary = x.Summary,
                    Type = x.Type,
                    Subject = x.Subject,
                    CreatedON = x.CreatedON,
                    CreatedBy = x.CreatedBy,
                    UpdatedON = x.UpdatedON,
                    UpdatedBy = x.UpdatedBy,
                    IsActive = x.IsActive
                }).ToList();
            }
        }


        public List<QuizModel> QuizListOfOneUser(int id)
        {
            using (var context = new MCQ_Quiz_DBEntities())
            {
                return context.tblQuizs.Where(x => x.CreatedBy == id).Select(x => new QuizModel
                {
                    QuizId = x.QuizId,
                    Title = x.Title,
                    Summary = x.Summary,
                    Type = x.Type,
                    Subject = x.Subject,
                    CreatedON = x.CreatedON,
                    CreatedBy = x.CreatedBy,
                    UpdatedON = x.UpdatedON,
                    UpdatedBy = x.UpdatedBy,
                    IsActive = x.IsActive
                }).ToList();
            }
        }

        public int AddQuiz(QuizModel quizModel)
        {
            try
            {

                using (var context = new MCQ_Quiz_DBEntities())
                {
                    tblQuiz _tblQuiz = new tblQuiz();

                    _tblQuiz.QuizId = quizModel.QuizId;
                    _tblQuiz.Title = quizModel.Title;
                    _tblQuiz.Summary = quizModel.Summary;
                    _tblQuiz.Type = quizModel.Type;
                    _tblQuiz.Subject = quizModel.Subject;
                    _tblQuiz.CreatedON = quizModel.CreatedON;
                    _tblQuiz.CreatedBy = quizModel.CreatedBy;
                    _tblQuiz.IsActive = quizModel.IsActive;

                    context.tblQuizs.Add(_tblQuiz);
                    context.SaveChanges();

                    return _tblQuiz.QuizId;
                }

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

    }
}



