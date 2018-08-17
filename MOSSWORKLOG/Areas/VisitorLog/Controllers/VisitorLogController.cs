using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.VisitorLog.Controllers
{
    public class VisitorLogController : Controller
    {
        // GET: VisitorLog/VisitorLog
        public ActionResult Index()
        {
            return View();
        }
    }
}