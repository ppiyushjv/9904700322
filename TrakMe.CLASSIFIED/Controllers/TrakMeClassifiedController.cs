using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrakMe.CLASSIFIED.Models;
using TrakME.Common;

namespace TrakMe.CLASSIFIED.Controllers
{
    public class TrakMeClassifiedController : Controller
    {
        public static bool IsCheckToken = false;
        // GET: TrakMe
        public JsonResult Token(TokenParameter param)
        {
            var ticks = DateTime.UtcNow.Ticks; ;
            var token = SecurityManager.GenerateToken(param.email, param.password, ticks);
            return Json(new { Success = true, Token = token }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Data(string name, string param = "")
        {
            #region [ HELP ]
            if (param.Contains("HELP"))
            {
                return Json(new { Success = true, Data = SampleData(name) }, JsonRequestBehavior.AllowGet);
            }
            #endregion

            #region [ Token ]
            if (IsCheckToken)
            {
                var token = Request.Headers.GetValues("token");
                if (token == null || !SecurityManager.IsTokenValid(token[0].ToString()))
                    return Json(new { Success = false, Response = "Unauthorise API call" }, JsonRequestBehavior.AllowGet);
            }
            #endregion

            try
            {
                switch (name)
                {
                    default:
                        return Json(new { Success = false, Code = "000", Message = "Not yet implemented" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Code = "XXX", Message = "Error in API Call", Error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        internal Object SampleData(string function)
        {
            switch (function)
            {
                default:
                    return "Not yet implemented";
            }
        }
    }
}