using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.CCTVLog
{
    public class CCTVLogAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CCTVLog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CCTVLog_default",
                "CCTVLog/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}