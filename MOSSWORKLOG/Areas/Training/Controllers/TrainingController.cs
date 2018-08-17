using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.Areas.Training.Models;
using MOSSWORKLOG.DATA;

namespace MOSSWORKLOG.Areas.Training.Controllers
{
    public class TrainingController : Controller
    {
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();
        // GET: Training/Training
        public ActionResult Index()
        {
            TrainingViewModel vm = new TrainingViewModel();
            _context.tblTrainings.ToList().ForEach(x => vm.Trainings.Add(new TrainingModel()
            {
                Id =x.Id,
                TrainingDate = x.TrainingDate,
                IsEdit = false,
                TrainingAttend = x.TrainingAttend,
                TrainingAttendId = x.TrainingAttendId,
                TrainingBy = x.TrainingBy,
                TrainingById = x.TrainingById,
                TrainingDescription = x.TrainingDescription,
                TrainingDuration = x.TrainingDuration,
                TrainingSubject = x.TrainingSubject
            }));

            return View(vm);
        }
    }
}