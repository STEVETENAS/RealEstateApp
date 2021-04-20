using RealEstateApp.API.Entities;
using System;
using System.Web.Http;

namespace RealEstateApp.API.Controllers
{
    public class BaseController : ApiController
    {
        protected readonly RealEstateDBEntities db;

        public BaseController()
        {
            db = new RealEstateDBEntities();
        }
    }
}
