using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PassionProjectSummer2024.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PassionProjectSummer2024.Controllers
{
    /// <summary>
    /// This controller handles the CRUD operations for articles.
    /// </summary>
    public class ArticlesDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Retrieves a list of all articles.
        /// </summary>
        [HttpGet]
        public IEnumerable<Article> ListArticles()
        {
            return db.Articles.ToList();
        }

        /// <summary>
        /// Retrieves a single article by ID.
        /// </summary>
        [HttpGet]
        public IHttpActionResult FindArticle(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        /// <summary>
        /// Adds a new article.
        /// </summary>
        [HttpPost]
        public IHttpActionResult AddArticle([FromBody] Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Articles.Add(article);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = article.ArticleId }, article);
        }

        /// <summary>
        /// Updates an existing article.
        /// </summary>
        [HttpPut]
        public IHttpActionResult UpdateArticle(int id, [FromBody] Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != article.ArticleId)
            {
                return BadRequest();
            }

            db.Entry(article).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
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
        /// Deletes an article by ID.
        /// </summary>
        [HttpDelete]
        public IHttpActionResult DeleteArticle(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            db.Articles.Remove(article);
            db.SaveChanges();

            return Ok(article);
        }

        /// <summary>
        /// Lists articles by a specific user.
        /// </summary>
        [HttpGet]
        public IEnumerable<Article> ListArticlesForUser(int userId)
        {
            return db.Articles.Where(a => a.UserId == userId).ToList();
        }

        /// <summary>
        /// Lists articles by a specific category.
        /// </summary>
        [HttpGet]
        public IEnumerable<Article> ListArticlesForCategory(int categoryId)
        {
            return db.Articles.Where(a => a.CategoryId == categoryId).ToList();
        }

        private bool ArticleExists(int id)
        {
            return db.Articles.Count(e => e.ArticleId == id) > 0;
        }
    }
}
