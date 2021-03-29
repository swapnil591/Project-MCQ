using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelClasses
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiIddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public string BirthDate { get; set; }
        [EmailAddress]
        [Required]
        public string Email_ID { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<QuizModel> tblQuizs { get; set; }
        public virtual ICollection<QuizChoiceModel> tblQuizChoices { get; set; }
        public virtual ICollection<QuizQuestionModel> tblQuizQuestions { get; set; }
        public virtual ICollection<TestModel> tblTests { get; set; }
        public virtual ICollection<TestStatusModel> tblTestStatus { get; set; }
        public virtual ICollection<UserGroupModel> tblUserGroups { get; set; }
    }
}
