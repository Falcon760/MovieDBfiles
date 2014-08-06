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
    public class CommentDController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        // GET: /CommentD/
        public ActionResult Index()
        {
            var commentds = db.CommentDs.Include(c => c.MessageBoardD);
            return View(commentds.ToList());
        }

        // GET: /CommentD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentD commentd = db.CommentDs.Find(id);
            if (commentd == null)
            {
                return HttpNotFound();
            }
            return View(commentd);
        }

        // GET: /CommentD/Create
        public ActionResult Create()
        {
            ViewBag.MessageBoardId = new SelectList(db.MessageBoardDs, "MessageBoardId", "MessageBoardName");
            return View();
        }

        // POST: /CommentD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CommentId,UserName,CommentContents,MessageBoardId")] CommentD commentd)
        {
            if (ModelState.IsValid)
            {
                db.CommentDs.Add(commentd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MessageBoardId = new SelectList(db.MessageBoardDs, "MessageBoardId", "MessageBoardName", commentd.MessageBoardId);
            return View(commentd);
        }

        // GET: /CommentD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentD commentd = db.CommentDs.Find(id);
            if (commentd == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageBoardId = new SelectList(db.MessageBoardDs, "MessageBoardId", "MessageBoardName", commentd.MessageBoardId);
            return View(commentd);
        }

        // POST: /CommentD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CommentId,UserName,CommentContents,MessageBoardId")] CommentD commentd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageBoardId = new SelectList(db.MessageBoardDs, "MessageBoardId", "MessageBoardName", commentd.MessageBoardId);
            return View(commentd);
        }

        // GET: /CommentD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentD commentd = db.CommentDs.Find(id);
            if (commentd == null)
            {
                return HttpNotFound();
            }
            return View(commentd);
        }

        // POST: /CommentD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentD commentd = db.CommentDs.Find(id);
            db.CommentDs.Remove(commentd);
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
