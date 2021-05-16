using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses
{
    public class UserGroupModel
    {
        public int UserGrpId { get; set; }
        public string User { get; set; }
        public string Quiz { get; set; }
        public string Role { get; set; }

        public Nullable<int> UserId { get; set; }
        public Nullable<int> QuizId { get; set; }
        public Nullable<int> RoleId { get; set; }


        public System.DateTime? CreatedON { get; set; }
        public System.DateTime? UpdatedON { get; set; }

        public virtual QuizModel tblQuiz { get; set; }
        public virtual UserModel tblUser { get; set; }
    }
}
