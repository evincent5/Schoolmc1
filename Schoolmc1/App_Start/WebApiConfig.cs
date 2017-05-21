using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Schoolmc1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            var json = configuration.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling 
                = PreserveReferencesHandling.Objects;
            configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);

            configuration.EnableCors();
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
