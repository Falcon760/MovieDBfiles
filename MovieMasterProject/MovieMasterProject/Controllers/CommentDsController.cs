using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieMasterProject;
using Microsoft.AspNet.Identity;

namespace MovieMasterProject.Controllers
{
    public class CommentDsController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        // GET: CommentDs
        public ActionResult Index()
        {
            var commentDs = db.CommentDs.Include(c => c.MessageBoardD);
            return View(commentDs.ToList());
        }

        // GET: CommentDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentD commentD = db.CommentDs.Find(id);
            if (commentD == null)
            {
                return HttpNotFound();
            }
            return View(commentD);
        }

        // GET: CommentDs/Create
        public ActionResult Create()
        {
            CommentD commentD = new CommentD();
            



            ViewBag.MessageBoardId = new SelectList(db.MessageBoardDs, "MessageBoardId", "MessageBoardName");
            return View();
        }

        // POST: CommentDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,UserName,CommentContents,MessageBoardId")] CommentD commentD)
        {
            if (ModelState.IsValid)
            {
                commentD.UserName = User.Identity.GetUserName();
                db.CommentDs.Add(commentD);
                db.SaveChanges();
                return RedirectToAction("Index","Movie");
            }

            ViewBag.MessageBoardId = new SelectList(db.MessageBoardDs, "MessageBoardId", "MessageBoardName", commentD.MessageBoardId);
            return View(commentD);
        }

        // GET: CommentDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentD commentD = db.CommentDs.Find(id);
            if (commentD == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageBoardId = new SelectList(db.MessageBoardDs, "MessageBoardId", "MessageBoardName", commentD.MessageBoardId);
            return View(commentD);
        }

        // POST: CommentDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,UserName,CommentContents,MessageBoardId")] CommentD commentD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Movie");
            }
            ViewBag.MessageBoardId = new SelectList(db.MessageBoardDs, "MessageBoardId", "MessageBoardName", commentD.MessageBoardId);
            return View(commentD);
        }

        // GET: CommentDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentD commentD = db.CommentDs.Find(id);
            if (commentD == null)
            {
                return HttpNotFound();
            }
            return View(commentD);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentD commentD = db.CommentDs.Find(id);
            db.CommentDs.Remove(commentD);
            db.SaveChanges();
            return RedirectToAction("Index","Movie");
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
