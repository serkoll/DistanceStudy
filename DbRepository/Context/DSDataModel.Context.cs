﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbRepository.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DistanceStudyEF : DbContext
    {
        public DistanceStudyEF()
            : base("name=DistanceStudyEF")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AlgorithmStatu> AlgorithmStatus { get; set; }
        public virtual DbSet<SubThema> SubThemas { get; set; }
        public virtual DbSet<Task_Parametrs> Task_Parametrs { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Thema> Themas { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Task_Algorithm> Task_Algorithm { get; set; }
        public virtual DbSet<User_Info> User_Info { get; set; }
        public virtual DbSet<User_Status> User_Status { get; set; }
        public virtual DbSet<User_TaskAlgorithm> User_TaskAlgorithm { get; set; }
    }
}
