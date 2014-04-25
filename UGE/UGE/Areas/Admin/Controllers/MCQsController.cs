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
    public class MCQsController : Controller
    {
        private readonly UGEContext db = new UGEContext();

        public async Task<ActionResult> Index()
        {
            var mCQs = db.MCQs.Include(m => m.Article);
            return View(await mCQs.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MCQ mCQ = await db.MCQs.FindAsync(id);
            if (mCQ == null)
            {
                return HttpNotFound();
            }
            return View(mCQ);
        }

        
        public ActionResult Create()
        {
            ViewBag.ArticleID = new SelectList(db.Articles, "ArticleID", "ArticleName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MCQ mCQ)
        {
            if (ModelState.IsValid)
            {
                db.MCQs.Add(mCQ);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleID = new SelectList(db.Articles, "ArticleID", "ArticleName", mCQ.ArticleID);
            return View(mCQ);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MCQ mCQ = await db.MCQs.FindAsync(id);
            if (mCQ == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "ArticleID", "ArticleName", mCQ.ArticleID);
            return View(mCQ);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MCQ mCQ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mCQ).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "ArticleID", "ArticleName", mCQ.ArticleID);
            return View(mCQ);
        }

        
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MCQ mCQ = await db.MCQs.FindAsync(id);
            if (mCQ == null)
            {
                return HttpNotFound();
            }
            return View(mCQ);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MCQ mCQ = await db.MCQs.FindAsync(id);
            db.MCQs.Remove(mCQ);
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
