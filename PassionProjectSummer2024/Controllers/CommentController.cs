using System.Linq;
using System.Web.Mvc;
using PassionProjectSummer2024.Models;

namespace PassionProjectSummer2024.Controllers
{
    /// <summary>
    /// This controller handles the web views for comments.
    /// </summary>
    public class commentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: comments
        public ActionResult Index()
        {
            var comments = db.comments.Include(c => c.Article).Include(c => c.User).ToList();
            return View(comments);
        }

        // GET: comments/Details/5
        public ActionResult Details(int id)
        {
            var comment = db.comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: comments/Create
        public ActionResult Create()
        {
            ViewBag.Articles = new SelectList(db.Articles, "ArticleId", "Title");
            ViewBag.Users = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Content,ArticleId,UserId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Articles = new SelectList(db.Articles, "ArticleId", "Title", comment.ArticleId);
            ViewBag.Users = new SelectList(db.Users, "UserId", "UserName", comment.UserId);
            return View(comment);
        }

        // GET: comments/Edit/5
        public ActionResult Edit(int id)
        {
            var comment = db.comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }

            ViewBag.Articles = new SelectList(db.Articles, "ArticleId", "Title", comment.ArticleId);
            ViewBag.Users = new SelectList(db.Users, "UserId", "UserName", comment.UserId);
            return View(comment);
        }

        // POST: comments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Content,ArticleId,UserId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Articles = new SelectList(db.Articles, "ArticleId", "Title", comment.ArticleId);
            ViewBag.Users = new SelectList(db.Users, "UserId", "UserName", comment.UserId);
            return View(comment);
        }

        // GET: comments/Delete/5
        public ActionResult Delete(int id)
        {
            var comment = db.comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var comment = db.comments.Find(id);
            db.comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: comments/Article/5
        public ActionResult ByArticle(int articleId)
        {
            var comments = db.comments.Where(c => c.ArticleId == articleId).ToList();
            return View(comments);
        }

        // GET: comments/User/5
        public ActionResult ByUser(int userId)
        {
            var comments = db.comments.Where(c => c.UserId == userId).ToList();
            return View(comments);
        }
    }
}
