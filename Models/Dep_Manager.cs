//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StaffManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dep_Manager
    {
        public string Dep_ID { get; set; }
        public string Manager_ID { get; set; }
        public Nullable<System.DateTime> Joindate { get; set; }
        public Nullable<System.DateTime> Leavedate { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
