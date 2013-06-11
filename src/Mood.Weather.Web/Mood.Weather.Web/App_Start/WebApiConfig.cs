using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Mood.Weather.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Status",
                routeTemplate: "api/weather/status",
                defaults: new { controller = "Weather", action = "GetStatus" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Values", id = RouteParameter.Optional }
            );

            /*
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
             */
        }
    }
}
