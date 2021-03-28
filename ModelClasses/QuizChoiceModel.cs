using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses
{
    public class QuizChoiceModel
    {
        public int Quiz_Choice_Id { get; set; }
        public int? QuestionId { get; set; }
        public bool? IsAnswer { get; set; }
        public string OptionTitle { get; set; }
        public System.DateTime CreatedON { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime UpdatedON { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
