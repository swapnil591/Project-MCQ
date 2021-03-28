using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses
{
    public class TestStatusModel
    {
        public int Test_StatusId { get; set; }
        public string Test_Status_Name { get; set; }
        public System.DateTime? CreatedON { get; set; }
        public int? CreatedBy { get; set; }
        public System.DateTime? UpdatedON { get; set; }
        public int? UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestModel> tblTests { get; set; }
        public virtual UserModel tblUser { get; set; }
       // public virtual tblUser tblUser1 { get; set; }
    }
}
