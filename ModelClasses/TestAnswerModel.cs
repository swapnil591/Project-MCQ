using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses
{
    public class TestAnswerModel
    {
        public int TestAnswerId { get; set; }
        public int? TestId { get; set; }
        public int? QuizChoiceId { get; set; }
        public bool? IsCorrectChoice { get; set; }
        public System.DateTime? CreatedON { get; set; }
        public System.DateTime? UpdatedON { get; set; }

        public virtual QuizChoiceModel tblQuizChoice { get; set; }
        public virtual TestModel tblTest { get; set; }
    }
}
