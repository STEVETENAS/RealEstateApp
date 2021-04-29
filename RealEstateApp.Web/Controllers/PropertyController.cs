using Newtonsoft.Json;
using RealEstateApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RealEstateApp.Web.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property
        public async Task<ActionResult> Index()
        {
            IEnumerable<PropertyModel> model = new List<PropertyModel>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(
                    "http://localhost/RealEstateAPI/api/Property"
                    );

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<IEnumerable<PropertyModel>>(json);
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            PropertyModel model = new PropertyModel();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync
                (
                     "http://localhost/RealEstateAPI/API/Owner"
                );

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var owners = JsonConvert.DeserializeObject<IEnumerable<OwnerModel>>(json);
                    model.Owners = owners.Select
                        (
                            x =>
                            new SelectListItem
                            {
                                Text = x.Name,
                                Value = x.Id.ToString()
                            }
                        );
                }
            }
            return View("Edit",model);
        }

        public async Task<ActionResult> Edit(int Id)
        {
            PropertyModel model = new PropertyModel();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync
                    (
                        "http://localhost/RealEstateAPI/API/Property?Id=" + Id
                    );

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<PropertyModel>(json);
                }

                response = await client.GetAsync 
                    (
                        "http://localhost/RealEstateAPI/API/Owner"
                    );

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var owners = JsonConvert.DeserializeObject<IEnumerable<OwnerModel>>(json);
                    model.Owners = owners.Select
                    (
                        x =>
                        new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.Id.ToString(),
                            Selected = x.Id == model.Owner.Id
                        }
                    );
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(PropertyModel model)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(
                        "http://localhost/RealEstateAPI/API/Owner"
                        );
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var owners = JsonConvert.DeserializeObject<IEnumerable<OwnerModel>>(json);
                        model.Owners = owners.Select
                        (
                            x =>
                            new SelectListItem
                            {
                                Text = x.Name,
                                Value = x.Id.ToString()
                            }
                        );
                    }
                }

                if (ModelState.IsValid)
                {
                    var json = JsonConvert.SerializeObject(model);
                    StringContent content = new StringContent
                    (
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                    using(HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response;
                        if (model.Id == 0)
                            response = await client.PostAsync
                                (
                                    "http://localhost/RealEstateAPI/API/Property",
                                    content
                                );
                        else
                            response = await client.PutAsync
                                (
                                    "http://localhost/RealEstateAPI/API/Property",
                                    content
                                );
                    }
                    return RedirectToAction("Index");
                }
             }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        public async Task<ActionResult> Delete(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                var responce = await client.DeleteAsync
                    (
                        "http://localhost/RealEstateAPI/API/Property?Id=" + Id
                    );
            }
            return RedirectToAction("Index");
        }
    }
}


/* 
    Create() 
    {
        ProductModel model = ProductModel();
        using(HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync
            (
                "http://localhost/RealEstateAPI/API/Owner"
            );
            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var owner = JsonConvert.DeserializeObject<IEnumerable<Propertymodel>>(json);
                model.Owners = owners.Select
                (
                    x =>
                    new SelectListitem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }
                };
            }
            return View("Edit",model);
    }


        public async Task<ActionResult> Edit(int Id)
        {
            PropertyModel model = new PropertyModel();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync
                    (
                        "http://localhost/RealEstateAPI/API/Product?Id=" + Id
                    );

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<PropertyModel>(json);
                }

                response = await client.GetAsync
                (
                    "http://localhost/RealEstateAPI/API/Owner"
                );
                
                if(response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var owner = JsonConvert.DeserializeObject<IEnumerable<OwnerModel>>(json);
                    model.Owners = owner.Select
                    (
                        x =>
                        new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.Id.ToString(),
                            Selected = x.Id == model.Owner.Id
                        }
                    );
                }
            }
            return View(model);
        }


        public async Task<ActionResult> Edit(OwnerModel model)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync
                    (
                      "http://localhost/RealEstateAPI/API/Product"
                    );
                    if(response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var owner = jsonConvert.DeserializeObject<Ienumerable<OwnerModel>>(json);
                        model.Owners = owner.Select
                        (
                            x =>
                            new SelectListItem
                            {
                                Text = x.Name,
                                Value = x.Id.ToString()
                            }
                        );
                    }

                 }   
                
                if (ModelState.isValid)
                {
                    var json =  JsonConvert.SerializeObject(model);
                    StringContent content = new StringContent
                    (
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                    using(HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response;
                        if(model.Id == 0)
                            response = await client.PostAsync
                            (
                                "http://localhost/RealEstateAPI/API/Product",
                                 content
                            );       
                        else
                            response = await client.PutAsync
                            (
                                "http://localhost/RealEstateAPI/API/Product",
                                 content
                            );
                    }
                    return RedirectToAction("Index");
                }
            }
            catch(Exeception ex)
            {
                ModelState.AddModelError("",ex.Message);
            }
            return View(model);
        }

*/