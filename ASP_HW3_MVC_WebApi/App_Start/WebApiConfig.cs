using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ASP_HW3_MVC_WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{button}/{name}/{valueBox}",
                defaults: new { controller = "Fridge", 
                                button = RouteParameter.Optional, 
                                name = RouteParameter.Optional,
                                valueBox = RouteParameter.Optional
                }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
