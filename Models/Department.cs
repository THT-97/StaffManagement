//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Department
    {
        public Department()
        {
            this.Dep_Manager = new HashSet<Dep_Manager>();
            this.Teams = new HashSet<Team>();
        }
    
        public string Dep_ID { get; set; }
        public string Dep_Name { get; set; }
    
        public virtual ICollection<Dep_Manager> Dep_Manager { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
