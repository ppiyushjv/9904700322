using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.WorkLog
{
    public class WorkLogAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WorkLog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WorkLog_default",
                "WorkLog/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}