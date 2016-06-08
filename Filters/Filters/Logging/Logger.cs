using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Filters.Logging
{
    public class Logger
    {
        public void LogRequestBefore(string userAddress, string request)
        {
            Debug.WriteLine("Received request from: {0}, at the following URI: {1}", userAddress, request);
        }
    }
}