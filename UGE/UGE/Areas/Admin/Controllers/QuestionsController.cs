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
    public class QuestionsController : Controller
    {
        private readonly UGEContext db = new UGEContext();

        public async Task<ActionResult> Index()
        {
            var questions = db.Questions.Include(q => q.Choice).Include(q => q.MCQ);
            return View(await questions.ToListAsync());
        }

        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        
        public ActionResult Create()
        {
            ViewBag.AnswerChoiceID = new SelectList(db.Choices, "ChoiceID", "ChoiceDisplay");
            ViewBag.MCQID = new SelectList(db.MCQs, "MCQID", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AnswerChoiceID = new SelectList(db.Choices, "ChoiceID", "ChoiceDisplay", question.AnswerChoiceID);
            ViewBag.MCQID = new SelectList(db.MCQs, "MCQID", "Title", question.MCQID);
            return View(question);
        }

        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnswerChoiceID = new SelectList(db.Choices, "ChoiceID", "ChoiceDisplay", question.AnswerChoiceID);
            ViewBag.MCQID = new SelectList(db.MCQs, "MCQID", "Title", question.MCQID);
            return View(question);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AnswerChoiceID = new SelectList(db.Choices, "ChoiceID", "ChoiceDisplay", question.AnswerChoiceID);
            ViewBag.MCQID = new SelectList(db.MCQs, "MCQID", "Title", question.MCQID);
            return View(question);
        }

        
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Question question = await db.Questions.FindAsync(id);
            db.Questions.Remove(question);
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
