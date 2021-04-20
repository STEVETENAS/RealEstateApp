using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateApp.Web.Models
{
    public class OwnerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Tel { get; set; }
    }
}