using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses
{
    public class QuizQuestionModel
    {
        public int QuizQuestionId { get; set; }
        public int QuizId_fk { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public bool? IsActive { get; set; }
        public System.DateTime? CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }

        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public string Answer { get; set; }
        

        public QuizChoiceModel QuizChoiceModal_obj { get; set; }
    }
}
