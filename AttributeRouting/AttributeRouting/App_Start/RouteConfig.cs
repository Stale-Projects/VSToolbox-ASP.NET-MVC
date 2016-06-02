using AttributeRouting.CustomRouteConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace AttributeRouting
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //This line activates Attribute routing
            //It is only needed if I don't have Custom Constraints as below
            //routes.MapMvcAttributeRoutes();
            
            //The following 3 lines register the ValueConstraint class used to define
            //the set of acceptable values for a parameter
            //To register additional custom Constraints, repeat the middle line for each one
            var constraintsResolver = new DefaultInlineConstraintResolver();
            //Take care with names: the string below must match the name of the custom constraint class without the word Constraint, and is case-sensitive!
            constraintsResolver.ConstraintMap.Add("Value", typeof(ValueConstraint));
            routes.MapMvcAttributeRoutes(constraintsResolver);


            //I can remove the default, as I can set all the defaults 
            // with Attributes

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
