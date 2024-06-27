using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PassionProjectSummer2024.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PassionProjectSummer2024.Controllers
{
    /// <summary>
    /// This controller handles the CRUD operations for comments.
    /// </summary>
    public class CommentsDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Retrieves a list of all comments.
        /// </summary>
        [HttpGet]
        public IEnumerable<Comment> ListComments()
        {
            return db.Comments.ToList();
        }

        /// <summary>
        /// Retrieves a single comment by ID.
        /// </summary>
        [HttpGet]
        public IHttpActionResult FindComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        /// <summary>
        /// Adds a new comment.
        /// </summary>
        [HttpPost]
        public IHttpActionResult AddComment([FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comments.Add(comment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comment.CommentId }, comment);
        }

        /// <summary>
        /// Updates an existing comment.
        /// </summary>
        [HttpPut]
        public IHttpActionResult UpdateComment(int id, [FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.CommentId)
            {
                return BadRequest();
            }

            db.Entry(comment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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
        /// Deletes a comment by ID.
        /// </summary>
        [HttpDelete]
        public IHttpActionResult DeleteComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            db.Comments.Remove(comment);
            db.SaveChanges();

            return Ok(comment);
        }

        /// <summary>
        /// Lists comments for a specific article.
        /// </summary>
        [HttpGet]
        public IEnumerable<Comment> ListCommentsForArticle(int articleId)
        {
            return db.Comments.Where(c => c.ArticleId == articleId).ToList();
        }

        /// <summary>
        /// Lists comments by a specific user.
        /// </summary>
        [HttpGet]
        public IEnumerable<Comment> ListCommentsForUser(int userId)
        {
            return db.Comments.Where(c => c.UserId == userId).ToList();
        }

        private bool CommentExists(int id)
        {
            return db.Comments.Count(e => e.CommentId == id) > 0;
        }
    }
}
