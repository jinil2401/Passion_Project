using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PassionProjectSummer2024.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PassionProjectSummer2024.Controllers
{
    /// <summary>
    /// This controller handles the CRUD operations for categories.
    /// </summary>
    public class CategorysDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Retrieves a list of all categories.
        /// </summary>
        [HttpGet]
        public IEnumerable<Category> ListCategorys()
        {
            return db.Categorys.ToList();
        }

        /// <summary>
        /// Retrieves a single category by ID.
        /// </summary>
        [HttpGet]
        public IHttpActionResult FindCategory(int id)
        {
            Category category = db.Categorys.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        [HttpPost]
        public IHttpActionResult AddCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categorys.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryId }, category);
        }

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Deletes a category by ID.
        /// </summary>
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categorys.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categorys.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        private bool CategoryExists(int id)
        {
            return db.Categorys.Count(e => e.CategoryId == id) > 0;
        }
    }
}
