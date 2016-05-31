using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassicRouting.Controllers
{
    public class HomeController : Controller
    {
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

        /// <summary>
        /// This Action is used to exemplify the use of an optional parameter
        /// The Capitalization parameter is optional (as seen in the route mapped
        /// in App_Start.RouteConfig.RegisterRoutes()
        /// 
        /// </summary>
        /// <param name="Capitalization"></param>
        /// <returns></returns>
        public ActionResult Serial(string Capitalization="Lowercase")
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
        /// This action is used to exemplify the use of regular expressions
        /// as constraints for parameters value. In this case, the parameter can only 
        /// be an integer
        /// </summary>
        /// <param name="feetValue"></param>
        /// <returns></returns>
        public ActionResult FeetToMeters(int feetValue)
        {
            var metersValue= 0.0;
            metersValue = feetValue * 0.3048;
            return Content(metersValue.ToString());
        }

    }
}