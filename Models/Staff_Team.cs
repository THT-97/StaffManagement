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
    
    public partial class Staff_Team
    {
        public string Staff_ID { get; set; }
        public string Team_ID { get; set; }
        public Nullable<System.DateTime> Joindate { get; set; }
        public Nullable<System.DateTime> Leavedate { get; set; }
    
        public virtual Staff Staff { get; set; }
        public virtual Team Team { get; set; }
    }
}
