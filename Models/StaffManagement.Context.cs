﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StaffManagement.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StaffManagementEntitiesModel : DbContext
    {
        public StaffManagementEntitiesModel()
            : base("name=StaffManagementEntitiesModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Dep_Manager> Dep_Manager { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Project_Manager> Project_Manager { get; set; }
        public DbSet<Project_Team> Project_Team { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Staff_Team> Staff_Team { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}