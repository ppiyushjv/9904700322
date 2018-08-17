using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace TrakME
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            string ApiVersion = "v1";

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/" + ApiVersion + "/{controller}/{action}/{id}",
                defaults: new { id = System.Web.Http.RouteParameter.Optional }
            );
        }
    }
}
