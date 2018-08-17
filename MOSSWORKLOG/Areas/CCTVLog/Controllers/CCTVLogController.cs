using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.DATA;
using MOSSWORKLOG.Areas.CCTVLog.Models;

namespace MOSSWORKLOG.Areas.CCTVLog.Controllers
{
    public class CCTVLogController : Controller
    {
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();
        // GET: CCTVLog/CCTVLog
        public ActionResult Index()
        {
            CCTVViewModel vm = new CCTVViewModel();

            _context.CCTVLogs.ToList().ForEach(x => vm.CCTVLogs.Add(new CCTVModel()
            {
                Id = x.Id,
                LogDate = x.LogDate,
                Duration = x.Duration,
                CCTVNo = x.CCTVNo
            }));
        
            return View(vm);
        }
    }
}