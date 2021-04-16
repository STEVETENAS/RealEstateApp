using System;
using System.Web.Http;

namespace RealEstateApp.API.Controllers
{
    public class BaseController : ApiController
    {
        protected readonly Entities.Entities db;

        public BaseController()
        {
            db = new Entities.Entities();
        }
    }
}
