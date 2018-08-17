using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.NetworkLog
{
    public class NetworkLogAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NetworkLog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NetworkLog_default",
                "NetworkLog/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}