using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Mood.Weather.Web.App_Start;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;


namespace Mood.Weather.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings()
                        {
                            Formatting = Newtonsoft.Json.Formatting.Indented,
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                            Converters = new List<JsonConverter>() { new IsoDateTimeConverter() },                
                        };


            GlobalConfiguration.Configuration.Formatters.XmlFormatter.UseXmlSerializer = true;

            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            AutoMapperBootStrapper.Configure();

        }
    }
}