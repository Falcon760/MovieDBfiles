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
    public class CommentAController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        // GET: /CommentA/
        public ActionResult Index()
        {
            var commentas = db.CommentAs.Include(c => c.MessageBoardA);
            return View(commentas.ToList());
        }

        // GET: /CommentA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentA commenta = db.CommentAs.Find(id);
            if (commenta == null)
            {
                return HttpNotFound();
            }
            return View(commenta);
        }

        // GET: /CommentA/Create
        public ActionResult Create()
        {
            ViewBag.MessageBoardId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName");
            return View();
        }

        // POST: /CommentA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CommentId,UserName,CommentContents,MessageBoardId")] CommentA commenta)
        {
            if (ModelState.IsValid)
            {
                db.CommentAs.Add(commenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MessageBoardId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName", commenta.MessageBoardId);
            return View(commenta);
        }

        // GET: /CommentA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentA commenta = db.CommentAs.Find(id);
            if (commenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageBoardId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName", commenta.MessageBoardId);
            return View(commenta);
        }

        // POST: /CommentA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CommentId,UserName,CommentContents,MessageBoardId")] CommentA commenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageBoardId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName", commenta.MessageBoardId);
            return View(commenta);
        }

        // GET: /CommentA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentA commenta = db.CommentAs.Find(id);
            if (commenta == null)
            {
                return HttpNotFound();
            }
            return View(commenta);
        }

        // POST: /CommentA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentA commenta = db.CommentAs.Find(id);
            db.CommentAs.Remove(commenta);
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
