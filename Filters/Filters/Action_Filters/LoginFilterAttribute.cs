using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Action_Filters
{
    public class LoginFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //TODO: Add code to log the request
            //Finally, call the OnActionExecuting of the Base Class
            base.OnActionExecuting(filterContext);
        }
    }
}