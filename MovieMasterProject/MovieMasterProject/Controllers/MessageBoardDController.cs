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
    public class MessageBoardDController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        // GET: /MessageBoardD/
        public ActionResult Index()
        {
            var messageboardds = db.MessageBoardDs.Include(m => m.Director);
            return View(messageboardds.ToList());
        }

        // GET: /MessageBoardD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoardD messageboardd = db.MessageBoardDs.Find(id);
            if (messageboardd == null)
            {
                return HttpNotFound();
            }
            return View(messageboardd);
        }

        // GET: /MessageBoardD/Create
        public ActionResult Create()
        {
            ViewBag.MessageBoardId = new SelectList(db.Directors, "DirectorId", "DirectorName");
            return View();
        }

        // POST: /MessageBoardD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MessageBoardId,MessageBoardName")] MessageBoardD messageboardd)
        {
            if (ModelState.IsValid)
            {
                db.MessageBoardDs.Add(messageboardd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MessageBoardId = new SelectList(db.Directors, "DirectorId", "DirectorName", messageboardd.MessageBoardId);
            return View(messageboardd);
        }

        // GET: /MessageBoardD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoardD messageboardd = db.MessageBoardDs.Find(id);
            if (messageboardd == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageBoardId = new SelectList(db.Directors, "DirectorId", "DirectorName", messageboardd.MessageBoardId);
            return View(messageboardd);
        }

        // POST: /MessageBoardD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MessageBoardId,MessageBoardName")] MessageBoardD messageboardd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageboardd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageBoardId = new SelectList(db.Directors, "DirectorId", "DirectorName", messageboardd.MessageBoardId);
            return View(messageboardd);
        }

        // GET: /MessageBoardD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoardD messageboardd = db.MessageBoardDs.Find(id);
            if (messageboardd == null)
            {
                return HttpNotFound();
            }
            return View(messageboardd);
        }

        // POST: /MessageBoardD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageBoardD messageboardd = db.MessageBoardDs.Find(id);
            db.MessageBoardDs.Remove(messageboardd);
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
