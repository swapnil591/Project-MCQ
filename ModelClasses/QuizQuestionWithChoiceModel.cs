using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses
{
  public  class QuizQuestionWithChoiceModel
    {
        public int QuizQuestionId { get; set; }
        public int QuizId_fk { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }


        public int Quiz_Choice_Id { get; set; }
        public bool? IsAnswer { get; set; }
        public string OptionTitle { get; set; }
    }
}
