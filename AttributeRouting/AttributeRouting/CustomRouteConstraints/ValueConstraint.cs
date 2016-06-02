using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace AttributeRouting.CustomRouteConstraints
{
    //This class allows us to define a set of valid values for a parameter in a URL
    public class ValueConstraint : IRouteConstraint
    {
        private readonly string[] _validOptions;
        /// <summary>
        /// Constructor: Provide a list of valid values for the parameter separated by a | character
        /// </summary>
        /// <param name="options">A string consisting of a list of valid values separated by a 
        /// pipe symbol</param>
        public ValueConstraint(string options)
        {
            _validOptions = options.Split('|');
        }


        /// <summary>
        /// Standard Match method. Returns true if the value provided for the parameter 
        /// matches an item from the list of valid values. Returns false otherwise. 
        /// The parameters are defined by the IRouteConstraint interface
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="route"></param>
        /// <param name="parameterName"></param>
        /// <param name="values"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection direction)
        {

            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                return _validOptions.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase);
            }
            else
            {
                return false;
            }
        }
    }

}