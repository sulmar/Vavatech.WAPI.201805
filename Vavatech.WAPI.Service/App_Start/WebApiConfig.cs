using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vavatech.WAPI.Service.Formatters;
using Vavatech.WAPI.Service.Handlers;

namespace Vavatech.WAPI.Service
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // config.Routes.MapHttpRoute(
            //    name: "DefaultApiV2",
            //    routeTemplate: "api/v2/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);



            config.Formatters.Add(new CsvMediaTypeFormatter());
            config.Formatters.Add(new QrCodeMediaTypeFormatter());


            config.MessageHandlers.Add(new TraceMessageHandler());
            config.MessageHandlers.Add(new FormatMessageHandler());
           // config.MessageHandlers.Add(new SecretKeyHandler());
        }
    }
}
