using Filters.Action_Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            throw new StackOverflowException();
            return View();
        }

        //Deny access to anonymous users
        [Authorize]
        //This next line makes this method execute the code in the custom filter before running the code of the method itself. It is not needed if the filter is registered globally
        [LoginFilter]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}