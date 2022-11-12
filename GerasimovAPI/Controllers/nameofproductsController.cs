using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GerasimovAPI;
using GerasimovAPI.Models;

namespace GerasimovAPI.Controllers
{
    public class nameofproductsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/nameofproducts
        [ResponseType(typeof(List<nameofproductModel>))]
        public IHttpActionResult Getnameofproduct()
        {
            return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)));
        }
        [Route("api/nameofproduct/SortedList")]

        [HttpGet]

        public async Task<IHttpActionResult> SortedList(bool f)
        {

            if (f)
            {
                return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)).OrderBy(x => x.price));
            }
            else
            {
                return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)).OrderBy(x => x.price).Reverse());
            }
        }

        // GET: api/nameofproducts/5
        [ResponseType(typeof(nameofproduct))]
        public IHttpActionResult Getnameofproduct(int id)
        {
            nameofproduct nameofproduct = db.nameofproduct.Find(id);
            if (nameofproduct == null)
            {
                return NotFound();
            }

            return Ok(nameofproduct);
        }

        // PUT: api/nameofproducts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putnameofproduct(int id, nameofproduct nameofproduct)
        {

            var dbnameofproduct = db.nameofproduct.FirstOrDefault(x => x.id.Equals(id));

            dbnameofproduct.name = nameofproduct.name;
            dbnameofproduct.price = nameofproduct.price;
            dbnameofproduct.weight = nameofproduct.weight;
            dbnameofproduct.nameProiz = nameofproduct.nameProiz;
            dbnameofproduct.countryProiz = nameofproduct.countryProiz;
            dbnameofproduct.picture = nameofproduct.picture;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!nameofproductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        // Search
        [Route("api/nameofproducts/search")]

        [HttpGet]
        public async Task<IHttpActionResult> nameofproductsSearch(string nameofproductsSearchText, int field)
        {
            if (String.IsNullOrEmpty(nameofproductsSearchText))
            {

                switch (field)
                {

                    case 0:
                        return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)));
                        break;

                    case 1:
                        return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)).OrderBy(x => x.price));
                        break;

                    case 2:

                        return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)).OrderByDescending(x => x.price));
                        break;

                    case 3:
                        return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)).OrderBy(x => x.weight));
                        break;

                    case 4:
                        return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)).OrderByDescending(x => x.weight));
                        break;
                    default:
                        return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)));
                        break;
                }

            }
            else
            {
                switch (field)
                {

                    case 0:
                        return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)).Where(x => x.name.ToLower().Contains(nameofproductsSearchText.ToLower())));
                        break;

                    case 1:
                        return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)).Where(x => x.name.ToLower().Contains(nameofproductsSearchText.ToLower())).OrderBy(x => x.price));
                        break;

                    case 2:

                        return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)).Where(x => x.name.ToLower().Contains(nameofproductsSearchText.ToLower())).OrderByDescending(x => x.price));
                        break;

                    case 3:
                        return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)).Where(x => x.name.ToLower().Contains(nameofproductsSearchText.ToLower())).OrderBy(x => x.weight));
                        break;

                    case 4:
                        return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)).Where(x => x.name.ToLower().Contains(nameofproductsSearchText.ToLower())).OrderByDescending(x => x.weight));
                        break;
                    default:
                        return Ok(db.nameofproduct.ToList().ConvertAll(x => new nameofproductModel(x)).Where(x => x.name.ToLower().Contains(nameofproductsSearchText.ToLower())));
                        break;
                }
            }
        }

        // POST: api/nameofproducts
        [ResponseType(typeof(nameofproduct))]
        public IHttpActionResult Postnameofproduct(nameofproduct nameofproduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.nameofproduct.Add(nameofproduct);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nameofproduct.id }, nameofproduct);
        }

        // DELETE: api/nameofproducts/5
        [ResponseType(typeof(nameofproduct))]
        public IHttpActionResult Deletenameofproduct(int id)
        {
            nameofproduct nameofproduct = db.nameofproduct.Find(id);
            if (nameofproduct == null)
            {
                return NotFound();
            }

            db.nameofproduct.Remove(nameofproduct);
            db.SaveChanges();

            return Ok(nameofproduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool nameofproductExists(int id)
        {
            return db.nameofproduct.Count(e => e.id == id) > 0;
        }




    }
}