//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MOSSWORKLOG.DATA
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTask
    {
        public int TaskId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> ClientId { get; set; }
        public string TaskFrequency { get; set; }
        public string TaskTick { get; set; }
        public Nullable<System.DateTime> TaskStartDate { get; set; }
        public Nullable<System.DateTime> TaskEndDate { get; set; }
        public string Email { get; set; }
    }
}