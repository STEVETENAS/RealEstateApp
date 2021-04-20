using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RealEstateApp.API.Controllers
{
    public class TestController : ApiController
    {
        public string Get()
        {
            return Request.RequestUri.GetLeftPart(UriPartial.Authority);
        }
    }
}
