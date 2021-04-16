using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Newtonsoft.Json;

namespace RealEstateApp.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var jsonMediaTypeFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonMediaTypeFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.All;
            jsonMediaTypeFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        }
    }
}