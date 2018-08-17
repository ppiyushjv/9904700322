using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.ChangeManagement
{
    public class ChangeManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ChangeManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ChangeManagement_default",
                "ChangeManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}