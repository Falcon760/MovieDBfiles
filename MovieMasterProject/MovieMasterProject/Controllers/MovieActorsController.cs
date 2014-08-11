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
    public class MovieActorsController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        // GET: MovieActors
        public ActionResult Index()
        {
            var movieActors = db.MovieActors.Include(m => m.Actor).Include(m => m.Movie);
            return View(movieActors.ToList());
        }

        // GET: MovieActors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieActor movieActor = db.MovieActors.Find(id);
            if (movieActor == null)
            {
                return HttpNotFound();
            }
            return View(movieActor);
        }

        // GET: MovieActors/Create
        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList((from s in db.Actors select new { 
    ID=s.ActorId,
    FullName = s.FirstName+ " " + s.LastName}), 
    "ID", 
    "FullName", 
    null);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title");
            return View();
        }

       [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,ActorId,Id,Count")] MovieActor movieActor)
        {

           
            
            if (ModelState.IsValid)
            {

                db.MovieActors.Add(movieActor);
                db.SaveChanges();
                return RedirectToAction("Index","Movie");
            }

            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName", movieActor.ActorId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", movieActor.MovieId);
            return View(movieActor);
        }

        // GET: MovieActors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieActor movieActor = db.MovieActors.Find(id);
            if (movieActor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName", movieActor.ActorId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", movieActor.MovieId);
            return View(movieActor);
        }

      [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,ActorId,Id,Count")] MovieActor movieActor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieActor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName", movieActor.ActorId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", movieActor.MovieId);
            return View(movieActor);
        }

        // GET: MovieActors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieActor movieActor = db.MovieActors.Find(id);
            if (movieActor == null)
            {
                return HttpNotFound();
            }
            return View(movieActor);
        }

       [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieActor movieActor = db.MovieActors.Find(id);
            db.MovieActors.Remove(movieActor);
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
