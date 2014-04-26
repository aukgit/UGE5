using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UGE.Models.DataStructure;

namespace UGE.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly UGEContext db = new UGEContext();

        public async Task<ActionResult> Index()
        {
            var articles = db.Articles.Include(a => a.Article2).Include(a => a.Article3).Include(a => a.Chapter);
            return View(await articles.ToListAsync());
        }

        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await db.Articles.FindAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        
        public ActionResult Create()
        {
            ViewBag.PreviousArticleID = new SelectList(db.Articles, "ArticleID", "ArticleName");
            ViewBag.NextArticleID = new SelectList(db.Articles, "ArticleID", "ArticleName");
            ViewBag.ChapterID = new SelectList(db.Chapters, "ChapterID", "TopicName");
            ViewBag.DisplayIn = new SelectList(db.Chapters, "ChapterID", "TopicName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DisplayIn = new SelectList(db.Chapters, "ChapterID", "TopicName");
            ViewBag.PreviousArticleID = new SelectList(db.Articles, "ArticleID", "ArticleName", article.PreviousArticleID);
            ViewBag.NextArticleID = new SelectList(db.Articles, "ArticleID", "ArticleName", article.NextArticleID);
            ViewBag.ChapterID = new SelectList(db.Chapters, "ChapterID", "TopicName", article.ChapterID);
            return View(article);
        }

        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await db.Articles.FindAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.PreviousArticleID = new SelectList(db.Articles, "ArticleID", "ArticleName", article.PreviousArticleID);
            ViewBag.NextArticleID = new SelectList(db.Articles, "ArticleID", "ArticleName", article.NextArticleID);
            ViewBag.ChapterID = new SelectList(db.Chapters, "ChapterID", "TopicName", article.ChapterID);
            return View(article);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DisplayIn = new SelectList(db.Chapters, "ChapterID", "TopicName");

            ViewBag.PreviousArticleID = new SelectList(db.Articles, "ArticleID", "ArticleName", article.PreviousArticleID);
            ViewBag.NextArticleID = new SelectList(db.Articles, "ArticleID", "ArticleName", article.NextArticleID);
            ViewBag.ChapterID = new SelectList(db.Chapters, "ChapterID", "TopicName", article.ChapterID);
            return View(article);
        }

        
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await db.Articles.FindAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Article article = await db.Articles.FindAsync(id);
            db.Articles.Remove(article);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
