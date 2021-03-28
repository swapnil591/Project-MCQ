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
        public int? UserId { get; set; }
        public int? QuizId { get; set; }
        public string Permission { get; set; }
        public System.DateTime? CreatedON { get; set; }
        public System.DateTime? UpdatedON { get; set; }

        public virtual QuizModel tblQuiz { get; set; }
        public virtual UserModel tblUser { get; set; }
    }
}
