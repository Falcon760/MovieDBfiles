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
    public class MovieRatingController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        // GET: /MovieRating/
        public ActionResult Index()
        {
            var ratings = db.Ratings.Include(r => r.Movie);
            return View(ratings.ToList());
        }

        // GET: /MovieRating/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        [Authorize]
        public ActionResult Create()
        {
            Rating rating = new Rating();
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title");
            rating.UserName = User.Identity.GetUserName();
            return View(rating);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RatingId,UserName,MovieId,Value")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Ratings.Add(rating);
                db.SaveChanges();
                return RedirectToAction("Index","Movie");
            }

            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", rating.MovieId);
            return View("Index","Movie",rating);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", rating.MovieId);
            return View(rating);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RatingId,UserName,MovieId,Value")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Movie");
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", rating.MovieId);
            return View(rating);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

       [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rating rating = db.Ratings.Find(id);
            db.Ratings.Remove(rating);
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
