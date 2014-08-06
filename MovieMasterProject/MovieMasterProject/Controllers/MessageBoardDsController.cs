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
    public class MessageBoardDsController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        // GET: MessageBoardDs
        public ActionResult Index()
        {
            var messageBoardDs = db.MessageBoardDs.Include(m => m.Director);
            return View(messageBoardDs.ToList());
        }

        // GET: MessageBoardDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoardD messageBoardD = db.MessageBoardDs.Find(id);
            if (messageBoardD == null)
            {
                return HttpNotFound();
            }
            return View(messageBoardD);
        }

        // GET: MessageBoardDs/Create
        public ActionResult Create()
        {
            ViewBag.MessageBoardId = new SelectList(db.Directors, "DirectorId", "DirectorName");
            return View();
        }

        // POST: MessageBoardDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageBoardId,MessageBoardName")] MessageBoardD messageBoardD)
        {
            if (ModelState.IsValid)
            {
                db.MessageBoardDs.Add(messageBoardD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MessageBoardId = new SelectList(db.Directors, "DirectorId", "DirectorName", messageBoardD.MessageBoardId);
            return View(messageBoardD);
        }

        // GET: MessageBoardDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoardD messageBoardD = db.MessageBoardDs.Find(id);
            if (messageBoardD == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageBoardId = new SelectList(db.Directors, "DirectorId", "DirectorName", messageBoardD.MessageBoardId);
            return View(messageBoardD);
        }

        // POST: MessageBoardDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageBoardId,MessageBoardName")] MessageBoardD messageBoardD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageBoardD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageBoardId = new SelectList(db.Directors, "DirectorId", "DirectorName", messageBoardD.MessageBoardId);
            return View(messageBoardD);
        }

        // GET: MessageBoardDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoardD messageBoardD = db.MessageBoardDs.Find(id);
            if (messageBoardD == null)
            {
                return HttpNotFound();
            }
            return View(messageBoardD);
        }

        // POST: MessageBoardDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageBoardD messageBoardD = db.MessageBoardDs.Find(id);
            db.MessageBoardDs.Remove(messageBoardD);
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
