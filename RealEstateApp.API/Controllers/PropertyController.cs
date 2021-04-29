using RealEstateApp.API.Entities;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace RealEstateApp.API.Controllers
{
    public class PropertyController : BaseController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                return Ok(await db.Properties.ToArrayAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> Details(int Id)
        {
            try
            {
             return Ok(await db.Properties.FindAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Property item)
        {
            try
            {
                item.CreatedDate = DateTime.Now;
                db.Properties.Add(item);
                await db.SaveChangesAsync();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] Property item)
        {
            try
            {
                var oldItem = await db.Properties.AsNoTracking().FirstOrDefaultAsync(x => x.Id == item.Id);
                if (oldItem != null)
                {
                    item.CreatedDate = oldItem.CreatedDate;
                    db.Entry(item).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                return Ok(item);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }


        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int Id)
        {try
            {
                var item = await db.Properties.FindAsync(Id);
                if (item != null)
                {
                    db.Properties.Remove(item);
                    await db.SaveChangesAsync();
                }
                return Ok(item);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

    }
}
