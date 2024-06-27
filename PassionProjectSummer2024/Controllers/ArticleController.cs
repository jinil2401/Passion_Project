using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PassionProjectSummer2024.Models;

namespace PassionProjectSummer2024.Controllers
{
    /// <summary>
    /// MVC controller for managing articles.
    /// Provides web views and actions for CRUD operations on articles.
    /// </summary>
    public class ArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Displays a list of all articles.
        /// </summary>
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Category).Include(a => a.User).ToList();
            return View(articles);
        }

        /// <summary>
        /// Displays details of a specific article by ID.
        /// </summary>
        /// <param name="id">The ID of the article to display details for.</param>
        public ActionResult Details(int id)
        {
            var article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        /// <summary>
        /// Shows the form to create a new article.
        /// </summary>
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "CategoryName");
            ViewBag.Users = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        /// <summary>
        /// Handles the submission of the new article form.
        /// </summary>
        /// <param name="article">The article object to create.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "CategoryName", article.CategoryId);
            ViewBag.Users = new SelectList(db.Users, "UserId", "UserName", article.UserId);
            return View(article);
        }

        /// <summary>
        /// Shows the form to edit an existing article.
        /// </summary>
        /// <param name="id">The ID of the article to edit.</param>
        public ActionResult Edit(int id)
        {
            var article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "CategoryName", article.CategoryId);
            ViewBag.Users = new SelectList(db.Users, "UserId", "UserName", article.UserId);
            return View(article);
        }

        /// <summary>
        /// Handles the submission of the article edit form.
        /// </summary>
        /// <param name="article">The article object to update.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "CategoryName", article.CategoryId);
            ViewBag.Users = new SelectList(db.Users, "UserId", "UserName", article.UserId);
            return View(article);
        }

        /// <summary>
        /// Shows the form to confirm deletion of an article.
        /// </summary>
        /// <param name="id">The ID of the article to delete.</param>
        public ActionResult Delete(int id)
        {
            var article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        /// <summary>
        /// Handles the deletion of an article after confirmation.
        /// </summary>
        /// <param name="id">The ID of the article to delete.</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays a list of articles by a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user whose articles are to be listed.</param>
        public ActionResult ByUser(int userId)
        {
            var articles = db.Articles.Where(a => a.UserId == userId).ToList();
            return View(articles);
        }

        /// <summary>
        /// Displays a list of articles in a specific category.
        /// </summary>
        /// <param name="categoryId">The ID of the category whose articles are to be listed.</param>
        public ActionResult ByCategory(int categoryId)
        {
            var articles = db.Articles.Where(a => a.CategoryId == categoryId).ToList();
            return View(articles);
        }
    }
}
