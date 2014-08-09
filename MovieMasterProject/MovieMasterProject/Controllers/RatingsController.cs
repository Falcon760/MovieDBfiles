using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieMasterProject;
using MovieMasterProject.Models;

namespace MovieMasterProject.Controllers
{
    public class RatingsController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        // GET: /Rating/
        public ActionResult Index()
        {
            RatingsModel model = new RatingsModel();
            IEnumerable<RatingType> ratingsTypes = Enum.GetValues(typeof(RatingType))
                                                       .Cast<RatingType>();
            model.RatingsList = from rating in ratingsTypes
                                select new SelectListItem
                                {
                                    Text = rating.ToString(),
                                    Value = ((int)rating).ToString()
                                };
            ViewBag.Movies = from x in db.Movies
                             select x;
            ViewBag.Ratings = model.RatingsList;

            return View(model);





            //return View(db.Ratings.ToList());
        }

        // GET: /Rating/Details/5
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

        // GET: /Rating/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Rating/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingsModel rating, Movie movie)
        {

            //movie.Rating = rating;
            return View();
          

        

    }
                //db.Ratings.Add(rating);
                //db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(rating);
        //}

        // GET: /Rating/Edit/5
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
            return View(rating);
        }

        // POST: /Rating/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RatingId,RatingValue")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rating);
        }

        // GET: /Rating/Delete/5
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

        // POST: /Rating/Delete/5
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
