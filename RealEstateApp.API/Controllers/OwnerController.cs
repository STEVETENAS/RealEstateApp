using RealEstateApp.API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RealEstateApp.API.Controllers
{
    public class OwnerController : BaseController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok( await db.Owners.ToArrayAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> Details(int id)
        {
            return Ok( await db.Owners.FindAsync(id));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Owner item)
        {
            item.CreatedDate = DateTime.Now;
            db.Owners.Add(item);
            await db.SaveChangesAsync();

            return Ok(item);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] Owner item)
        {
            var oldItem = await db.Owners.AsNoTracking().FirstOrDefaultAsync(x => x.Id == item.Id);
            if(oldItem != null)
            {
                item.CreatedDate = oldItem.CreatedDate;
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return Ok(item);
        }


        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var item = await db.Owners.FindAsync(id);
            if (item != null)
            {
                db.Owners.Remove(item);
                await db.SaveChangesAsync();
            }
            return Ok(item);
        }
    }
}
