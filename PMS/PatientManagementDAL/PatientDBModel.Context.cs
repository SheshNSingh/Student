﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatientManagementDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PatientDBEntities : DbContext
    {
        public PatientDBEntities()
            : base("name=PatientDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Lab> Labs { get; set; }
        public virtual DbSet<PatientEnrollment> PatientEnrollments { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
    }
}