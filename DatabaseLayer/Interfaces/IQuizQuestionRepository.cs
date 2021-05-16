using ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Interfaces
{
    public interface IQuizQuestionRepository
    {
        List<QuizQuestionWithChoiceModel> GetQuestions(int id);

        int AddQuestion(QuizQuestionModel _quizQueModel);
    }
}
