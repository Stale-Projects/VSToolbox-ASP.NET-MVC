using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttributeRouting.Controllers
{
    //The first attribute shows how to add a route prefix at the class level
    //The second attribute shows how to map action to URIs that include
    //the name of the action itself. This means that for all the standard 
    //routes I don't need to add anything to the method
    //For example, [server]/Home/Aboute works without attribute in the About method
    //The case of Home/Index is special as it has to map special cases
    
    [RoutePrefix("Home")]
    [Route("{action}")]
    public class HomeController : Controller
    {
        [Route("~/")] //GET /
        [Route("~/Home")] //GET /Home
        [Route("~/Home/Index")] //GET /Home/Index
        public ActionResult Index()
        {
            return View();
        }

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

        /// <summary>
        /// This Action is used to exemplify the use of an optional parameter
        /// The Capitalization parameter is optional 
        /// We use Attribute routing to map the URL to the route
        /// Note that we had to override the route prefix declared at the class level
        /// This is done with the tilde (~) symbol
        /// </summary>
        /// <param name="Capitalization">The question mark indicates this is an optional parameter. 
        /// We could have also add a default value in the route, in this way: 
        /// "~/serial/{Capitalization=Lowercase?}"
        /// But it is better to have a complete function in case it is called 
        /// from somewhere else</param>
        /// <returns>A made-up serial number</returns>
        [Route("~/serial/{Capitalization=Lowercase?}")]
        public ActionResult Serial(string Capitalization = "Lowercase")
        {
            string SerialNo = "MVCASPNETATMV1";
            if (Capitalization == "Lowercase")
            {
                return Content(SerialNo.ToLower());
            }
            else
            {
                return Content(SerialNo);
            }

        }


        /// <summary>
        /// This Action is used to demo the usage of a Custom Constraint where the list of valid values for a parameter is provided. In this case, the allowed values for TempUnits are "celsius" and "fahrenheit", while the values allowed for PresUnits are "mmHg" and "hPa"
        /// The ActionResult simply returns a message stating the units chosen
        /// </summary>
        /// <param name="UnidadesTemp"></param>
        /// <param name="UnidadesPres"></param>
        /// <returns></returns>

        public ActionResult Weather(string TempUnits,
            string PresUnits)
        {
            string _message;
            _message = "The unit chosen for temp is: " + TempUnits +
                ", and for atm pressure: " + PresUnits;
            return Content(_message);

        }


    }
}