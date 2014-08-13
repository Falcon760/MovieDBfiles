using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieMasterProject;
using MovieMasterProject;
using Microsoft.AspNet.Identity;



namespace MovieMasterProject.Controllers
{
    public class ReviewController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        // GET: /Review/
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.MessageBoard);
            return View(reviews.ToList());
        }

        // GET: /Review/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: /Review/Create
        [Authorize]
        public ActionResult Create()
        {
            Review review = new Review();
            review.UserName = User.Identity.GetUserName();

            ViewBag.MessageBoardId = new SelectList(db.MessageBoards, "MessageBoardId", "MessageBoardName");
            return View(review);
        }

       [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ReviewId,UserName,ReviewTitle,Rating,MessageBoardId,ReviewContents")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index","Movie");
            }

            ViewBag.MessageBoardId = new SelectList(db.MessageBoards, "MessageBoardId", "MessageBoardName", review.MessageBoardId);
            return View(review);
        }

        // GET: /Review/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageBoardId = new SelectList(db.MessageBoards, "MessageBoardId", "MessageBoardName", review.MessageBoardId);
            return View(review);
        }

        // POST: /Review/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ReviewId,UserName,ReviewTitle,Rating,MessageBoardId,ReviewContents")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageBoardId = new SelectList(db.MessageBoards, "MessageBoardId", "MessageBoardName", review.MessageBoardId);
            return View(review);
        }

        // GET: /Review/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

       [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
