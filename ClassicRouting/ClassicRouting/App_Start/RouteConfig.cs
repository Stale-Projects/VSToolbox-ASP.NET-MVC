using ClassicRouting.CustomRouteConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ClassicRouting
{
    public class RouteConfig
    {
        /// <summary>
        /// In this function, register custom routes to use the examples
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Route to access the Serial action with an optional parameter
            //Remember that optional parameters cannot have constraints
            routes.MapRoute(name: "Serial",
                url: "serial/{Capitalization}",
                defaults: new { controller = "Home", action = "Serial", Capitalization = UrlParameter.Optional });

            routes.MapRoute(name: "FeetToMeters",
                url: "feettometers/{feetValue}",
                defaults: new { controller = "Home", action = "FeetToMeters" },
                constraints: new {feetValue = @"\d+" });

            
            //Route for the Weather Action. Restrict the values allowed by use of the 
            //CustomRouteContraints/ValueConstraint class
            //We can see how to restrict the values for more than one parameter
            routes.MapRoute(
                name: "Weather",
                url: "weather/{TempUnits}/{PresUnits}",
                defaults: new
                {
                    controller = "Home",
                    action = "Weather"
                    
                },
                constraints: new
                {
                    TempUnits = new ValueConstraint("celsius|fahrenheit"),
                    PresUnits = new ValueConstraint("mmHg|HPa")
                }
                );

            //The default route has been modified to avoid a user from accessing the 
            ///Configuration Controller via the default route. This permission has to be 
            ///granted explicitly to Admin users only

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new
                {controller = new ExcludeController("Configuration")}
            );
        }
    }
}
