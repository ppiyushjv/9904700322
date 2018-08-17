using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.Models;
using MOSSWORKLOG.DATA;

namespace MOSSWORKLOG.Areas.Training.Models
{
    public class TrainingModel
    {
        public bool IsEdit { get; set; }
        public int Id { get; set; }

        public DateTime TrainingDate { get; set; }

        public int TrainingById { get; set; }
        public tblUser TrainingBy { get; set; }

        public int TrainingAttendId { get; set; }
        public tblUser TrainingAttend { get; set; }

        public string TrainingSubject { get; set; }

        public string TrainingDescription { get; set; }

        public int TrainingDuration { get; set; }
    }


    public class TrainingViewModel
    {
        public IList<TrainingModel> Trainings { get; set; }

        public TrainingViewModel()
        {
            this.Trainings = new List<TrainingModel>();
        }
    }
}