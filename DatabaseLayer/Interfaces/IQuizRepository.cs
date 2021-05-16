using ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Interfaces
{
   public interface IQuizRepository
    {
        List<QuizModel> QuizList();

        List<QuizModel> QuizListOfOneUser(int id);

        int AddQuiz(QuizModel quizModel);
    }
}
