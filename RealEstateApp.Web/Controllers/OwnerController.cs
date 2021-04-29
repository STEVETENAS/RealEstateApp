using Newtonsoft.Json;
using RealEstateApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RealEstateApp.Web.Controllers
{
    public class OwnerController : Controller
    {
        // GET: Owner
        public async Task<ActionResult> Index()
        {
            IEnumerable<OwnerModel> model = new List<OwnerModel>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync
                    (
                        "http://localhost/RealEstateAPI/api/Owner"
                    );

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<IEnumerable<OwnerModel>>(json);
                }
            }
            return View(model);
        }

        public ActionResult Create()
        {
            OwnerModel model = new OwnerModel();
            return View("Edit",model);
        }

        public async Task<ActionResult> Edit(int Id)
        {
            OwnerModel model = new OwnerModel();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync
                    (
                        "http://localhost/RealEstateAPI/API/Owner?Id=" + Id
                    );

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<OwnerModel>(json);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(OwnerModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var json = JsonConvert.SerializeObject(model);
                    StringContent content = new StringContent
                        (
                            json,
                            Encoding.UTF8,
                            "application/json"
                        );

                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response;
                        if (model.Id == 0)
                            response = await client.PostAsync
                                (
                                    "http://localhost/RealEstateAPI/API/Owner",
                                    content
                                );
                        else
                            response = await client.PutAsync
                                (
                                    "http://localhost/RealEstateAPI/API/Owner",
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
                        "http://localhost/RealEstateAPI/API/Owner?Id=" + Id
                    );
            }
            return RedirectToAction("Index");
        }

    }
}