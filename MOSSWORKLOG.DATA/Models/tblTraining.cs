using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class tblTraining
    {

        [Key]
        public int Id { get; set; }

        public DateTime TrainingDate { get; set; }

        public int TrainingById { get; set; }
        [ForeignKey("TrainingById")]
        public virtual tblUser TrainingBy { get; set; }
        
        public int TrainingAttendId { get; set; }
        [ForeignKey("TrainingAttendId")]
        public virtual tblUser TrainingAttend { get; set; }

        public string TrainingSubject { get; set; }

        public string TrainingDescription { get; set; }

        public int TrainingDuration { get; set; }

    }
}
