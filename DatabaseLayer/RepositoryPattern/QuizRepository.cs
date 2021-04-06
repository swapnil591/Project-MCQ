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
        public static List<QuizModel> QuizList()
        {
            using (var context = new MCQ_Quiz_DBEntities())
            {
                return context.tblQuizs.Select( x=>new QuizModel {
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
    }
}
