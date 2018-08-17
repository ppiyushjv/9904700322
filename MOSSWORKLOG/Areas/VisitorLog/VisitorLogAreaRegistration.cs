using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.VisitorLog
{
    public class VisitorLogAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "VisitorLog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "VisitorLog_default",
                "VisitorLog/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}