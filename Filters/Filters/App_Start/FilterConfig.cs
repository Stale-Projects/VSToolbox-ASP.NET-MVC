using Filters.Action_Filters;
using System.Web;
using System.Web.Mvc;

namespace Filters
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //This one is by default
            filters.Add(new HandleErrorAttribute());
            //Register my custom Filter to be used globally
            filters.Add(new LoginFilterAttribute());
        }
    }
}
