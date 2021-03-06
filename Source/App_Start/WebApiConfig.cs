using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShopBridge
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "SB_ProductApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller="Products", id = RouteParameter.Optional }
            );
        }
    }
}
