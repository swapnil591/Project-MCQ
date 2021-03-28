using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses
{
    public class QuizModel
    {
        public int QuizId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public System.DateTime CreatedON { get; set; }
        public int CreatedBy { get; set; }
        public string UpdatedON { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
