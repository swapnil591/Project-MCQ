//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUserGroup
    {
        public int UserGrpId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> QuizId { get; set; }
        public string Permission { get; set; }
        public Nullable<System.DateTime> CreatedON { get; set; }
        public Nullable<System.DateTime> UpdatedON { get; set; }
    
        public virtual tblQuiz tblQuiz { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}
