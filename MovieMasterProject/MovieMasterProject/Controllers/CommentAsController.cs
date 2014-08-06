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
    public class CommentAsController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        // GET: CommentAs
        public ActionResult Index()
        {
            var commentAs = db.CommentAs.Include(c => c.MessageBoardA);
            return View(commentAs.ToList());
        }

        // GET: CommentAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentA commentA = db.CommentAs.Find(id);
            if (commentA == null)
            {
                return HttpNotFound();
            }
            return View(commentA);
        }

        // GET: CommentAs/Create
        public ActionResult Create()
        {
            ViewBag.MessageBoardId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName");
            return View();
        }

        // POST: CommentAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,UserName,CommentContents,MessageBoardId")] CommentA commentA)
        {
            if (ModelState.IsValid)
            {
                db.CommentAs.Add(commentA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MessageBoardId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName", commentA.MessageBoardId);
            return View(commentA);
        }

        // GET: CommentAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentA commentA = db.CommentAs.Find(id);
            if (commentA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageBoardId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName", commentA.MessageBoardId);
            return View(commentA);
        }

        // POST: CommentAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,UserName,CommentContents,MessageBoardId")] CommentA commentA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageBoardId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName", commentA.MessageBoardId);
            return View(commentA);
        }

        // GET: CommentAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentA commentA = db.CommentAs.Find(id);
            if (commentA == null)
            {
                return HttpNotFound();
            }
            return View(commentA);
        }

        // POST: CommentAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentA commentA = db.CommentAs.Find(id);
            db.CommentAs.Remove(commentA);
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
