using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace ClassicRouting.CustomRouteConstraints
{
    /// <summary>
    /// This class is used to exclude a Controller from the default route
    /// Used to avoid a sensitive part of the Application from being accessed 
    /// by unauthorized users. For example a Configuration Controller should be 
    /// explicitly authorized for Admin users and not for anyone else
    /// We prevent it to be accessed through tthe default route
    /// The name of the controller we want to excluded is provided in the Constructor
    /// </summary>
    public class ExcludeController : IRouteConstraint
    {
        private string _controllerName = string.Empty;
        public ExcludeController(string ControllerName)
        {
            _controllerName = ControllerName;
        }
        public bool Match(HttpContextBase httpContext,
        Route route, string parameterName,
        RouteValueDictionary values,
        RouteDirection routeDirection)
        {
            return !string.Equals(values["controller"].ToString(), _controllerName, StringComparison.OrdinalIgnoreCase);

        }
    }
    
}