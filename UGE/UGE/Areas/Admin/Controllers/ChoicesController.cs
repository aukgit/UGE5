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
    public class ChoicesController : Controller
    {
        private readonly UGEContext db = new UGEContext();

        public async Task<ActionResult> Index()
        {
            var choices = db.Choices.Include(c => c.Question);
            return View(await choices.ToListAsync());
        }

        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = await db.Choices.FindAsync(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            return View(choice);
        }

        
        public ActionResult Create()
        {
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Hint");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Choice choice)
        {
            if (ModelState.IsValid)
            {
                db.Choices.Add(choice);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Hint", choice.QuestionID);
            return View(choice);
        }

        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = await db.Choices.FindAsync(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Hint", choice.QuestionID);
            return View(choice);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Choice choice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(choice).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Hint", choice.QuestionID);
            return View(choice);
        }

        
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = await db.Choices.FindAsync(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            return View(choice);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Choice choice = await db.Choices.FindAsync(id);
            db.Choices.Remove(choice);
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
