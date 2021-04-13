using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelClasses
{
    public class QuizModel
    {
        public int QuizId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public System.DateTime? CreatedON { get; set; }
        
        public int CreatedBy { get; set; }
        public string UpdatedON { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
