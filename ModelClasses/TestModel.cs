using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses
{
    public class TestModel
    {

        public int TestId { get; set; }
        public int? QuizId { get; set; }
        public int? Test_StatusId { get; set; }
        public int? Score { get; set; }
        public System.DateTime? CreatedON { get; set; }
        public int? CreatedBy { get; set; }
        public System.DateTime? UpdatedON { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual QuizModel tblQuiz { get; set; }
        public virtual TestStatusModel tblTestStatu { get; set; }
        public virtual UserModel tblUser { get; set; }
       
        public virtual ICollection<TestAnswerModel> tblTestAnswers { get; set; }
    }
}
