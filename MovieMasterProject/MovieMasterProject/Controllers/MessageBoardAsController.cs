using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieMasterProject;

namespace MovieMasterProject.Controllers
{
    public class MessageBoardAsController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        // GET: MessageBoardAs
        public ActionResult Index()
        {
            var messageBoardAs = db.MessageBoardAs.Include(m => m.Actor);
            return View(messageBoardAs.ToList());
        }

        // GET: MessageBoardAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoardA messageBoardA = db.MessageBoardAs.Find(id);
            if (messageBoardA == null)
            {
                return HttpNotFound();
            }
            return View(messageBoardA);
        }

        // GET: MessageBoardAs/Create
        public ActionResult Create()
        {
            ViewBag.MessageBoardId = new SelectList(db.Actors, "ActorId", "FirstName");
            return View();
        }

        // POST: MessageBoardAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageBoardId,MessageBoardName")] MessageBoardA messageBoardA)
        {
            if (ModelState.IsValid)
            {
                db.MessageBoardAs.Add(messageBoardA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MessageBoardId = new SelectList(db.Actors, "ActorId", "FirstName", messageBoardA.MessageBoardId);
            return View(messageBoardA);
        }

        // GET: MessageBoardAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoardA messageBoardA = db.MessageBoardAs.Find(id);
            if (messageBoardA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageBoardId = new SelectList(db.Actors, "ActorId", "FirstName", messageBoardA.MessageBoardId);
            return View(messageBoardA);
        }

        // POST: MessageBoardAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageBoardId,MessageBoardName")] MessageBoardA messageBoardA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageBoardA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageBoardId = new SelectList(db.Actors, "ActorId", "FirstName", messageBoardA.MessageBoardId);
            return View(messageBoardA);
        }

        // GET: MessageBoardAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoardA messageBoardA = db.MessageBoardAs.Find(id);
            if (messageBoardA == null)
            {
                return HttpNotFound();
            }
            return View(messageBoardA);
        }

        // POST: MessageBoardAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageBoardA messageBoardA = db.MessageBoardAs.Find(id);
            db.MessageBoardAs.Remove(messageBoardA);
            db.SaveChanges();
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
