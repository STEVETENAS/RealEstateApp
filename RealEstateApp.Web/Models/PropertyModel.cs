using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateApp.Web.Models
{
    public class PropertyModel
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public int OwnerId { get; set; }
        public OwnerModel Owner { get; set; }
        public IEnumerable<SelectListItem> Owners { get; set; }

    }
}