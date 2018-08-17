using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace MOSSWORKLOG
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
                defaults: new { id = RouteParameter.Optional }

            );
        }
    }
}
