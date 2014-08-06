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
    public class ActorController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        // GET: /Actor/
        public ActionResult Index()
        {
            var actors = db.Actors.Include(a => a.MessageBoardA);
            return View(actors.ToList());
        }

        // GET: /Actor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // GET: /Actor/Create
        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName");
            return View();
        }

        // POST: /Actor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ActorId,FirstName,LastName,DateOfBirth,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                var msgboard = new MessageBoardA { MessageBoardId = actor.ActorId, MessageBoardName = (actor.FirstName + " " + actor.LastName + " Comments") };
                db.MessageBoardAs.Add(msgboard);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ActorId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName", actor.ActorId);
            return View(actor);
        }

        // GET: /Actor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName", actor.ActorId);
            return View(actor);
        }

        // POST: /Actor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ActorId,FirstName,LastName,DateOfBirth,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName", actor.ActorId);
            return View(actor);
        }

        // GET: /Actor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: /Actor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = db.Actors.Find(id);
            db.Actors.Remove(actor);
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
