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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MCQ_Quiz_DBEntities : DbContext
    {
        public MCQ_Quiz_DBEntities()
            : base("name=MCQ_Quiz_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblQuiz> tblQuizs { get; set; }
        public virtual DbSet<tblQuizChoice> tblQuizChoices { get; set; }
        public virtual DbSet<tblQuizQuestion> tblQuizQuestions { get; set; }
        public virtual DbSet<tblTest> tblTests { get; set; }
        public virtual DbSet<tblTestAnswer> tblTestAnswers { get; set; }
        public virtual DbSet<tblTestStatu> tblTestStatus { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblUserGroup> tblUserGroups { get; set; }
        public virtual DbSet<tblRole> tblRoles { get; set; }
    }
}
