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
    public class ActorsController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        public ActionResult Search(string SearchBox)
        {
            var actors = from t in db.Actors select t;
            if (!String.IsNullOrEmpty(SearchBox))
            {

                    actors = from t in db.Actors
                             where t.LastName.Contains(SearchBox)
                             || t.FirstName.Contains(SearchBox)
                             select t;
                
            }
            return View("Index", actors.ToList());
        }

        // GET: Actors
        public ActionResult Index()
        {
            var actors = db.Actors.Include(a => a.MessageBoardA);
            return View(actors.ToList());
        }

        // GET: Actors/Details/5
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

       [Authorize]
        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName");
            return View();
        }

       
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActorId,FirstName,LastName,DateOfBirth,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {

                db.Actors.Add(actor);
                db.SaveChanges();
                var msgboard = new MessageBoardA { MessageBoardId = actor.ActorId, MessageBoardName = (actor.FirstName + " " + actor.LastName + " Comments") };
                db.MessageBoardAs.Add(msgboard);
                db.SaveChanges();
                return RedirectToAction("Index");



                //db.Actors.Add(actor);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            ViewBag.ActorId = new SelectList(db.MessageBoardAs, "MessageBoardId", "MessageBoardName", actor.ActorId);
            return View(actor);
        }

        // GET: Actors/Edit/5
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

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActorId,FirstName,LastName,DateOfBirth,Bio")] Actor actor)
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

        // GET: Actors/Delete/5
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
        [Authorize]
        // POST: Actors/Delete/5
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
