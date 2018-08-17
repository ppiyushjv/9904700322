using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.DATA;


namespace MOSSWORKLOG.Areas.NetworkLog.Controllers
{
    public class NetworkLogController : Controller
    {
        // GET: NetworkLog/NetworkLog
        public ActionResult Index()
        {
            return View();
        }
    }
}