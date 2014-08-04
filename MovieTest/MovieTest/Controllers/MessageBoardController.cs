using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieTest;

namespace MovieTest.Controllers
{
    public class MessageBoardController : Controller
    {
        private MovieLoversDBEntities1 db = new MovieLoversDBEntities1();

        // GET: /MessageBoard/
        public ActionResult Index()
        {
            var messageboards = db.MessageBoards.Include(m => m.Movie);
            return View(messageboards.ToList());
        }

        // GET: /MessageBoard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoard messageboard = db.MessageBoards.Find(id);
            if (messageboard == null)
            {
                return HttpNotFound();
            }
            return View(messageboard);
        }

        // GET: /MessageBoard/Create
        public ActionResult Create()
        {
            ViewBag.MessageBoardId = new SelectList(db.Movies, "MovieId", "Title");
            return View();
        }

        // POST: /MessageBoard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MessageBoardId,MessageBoardName")] MessageBoard messageboard)
        {
            if (ModelState.IsValid)
            {
                db.MessageBoards.Add(messageboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MessageBoardId = new SelectList(db.Movies, "MovieId", "Title", messageboard.MessageBoardId);
            return View(messageboard);
        }

        // GET: /MessageBoard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoard messageboard = db.MessageBoards.Find(id);
            if (messageboard == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageBoardId = new SelectList(db.Movies, "MovieId", "Title", messageboard.MessageBoardId);
            return View(messageboard);
        }

        // POST: /MessageBoard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MessageBoardId,MessageBoardName")] MessageBoard messageboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageBoardId = new SelectList(db.Movies, "MovieId", "Title", messageboard.MessageBoardId);
            return View(messageboard);
        }

        // GET: /MessageBoard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoard messageboard = db.MessageBoards.Find(id);
            if (messageboard == null)
            {
                return HttpNotFound();
            }
            return View(messageboard);
        }

        // POST: /MessageBoard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageBoard messageboard = db.MessageBoards.Find(id);
            db.MessageBoards.Remove(messageboard);
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
