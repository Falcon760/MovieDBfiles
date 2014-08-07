﻿using System;
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
    public class MovieController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        public ActionResult Search(string SearchBox)
        {
            var movies = (from r in db.Movies
                           where
                               r.Title.Contains(SearchBox)
                           select r).ToList();
            return View("Index", movies);
        }



        // GET: /Movie/
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Director).Include(m => m.Genre).Include(m => m.MessageBoard);
            return View(movies.ToList());
        }

        // GET: /Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }


            return View(movie);
        }

        // GET: /Movie/Create
        public ActionResult Create()
        {
            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "DirectorName");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreType");
            ViewBag.MovieId = new SelectList(db.MessageBoards, "MessageBoardId", "MessageBoardName");
            return View();
        }

        // POST: /Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MovieId,Title,DirectorId,GenreId,Rating,ReleaseDate,Summary")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                var msgboard = new MessageBoard { MessageBoardId = movie.MovieId, MessageBoardName = (movie.Title + " Comments") };
                db.MessageBoards.Add(msgboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "DirectorName", movie.DirectorId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreType", movie.GenreId);
            ViewBag.MovieId = new SelectList(db.MessageBoards, "MessageBoardId", "MessageBoardName", movie.MovieId);
            return View(movie);
        }

        // GET: /Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "DirectorName", movie.DirectorId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreType", movie.GenreId);
            ViewBag.MovieId = new SelectList(db.MessageBoards, "MessageBoardId", "MessageBoardName", movie.MovieId);
            return View(movie);
        }

        // POST: /Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MovieId,Title,DirectorId,GenreId,Rating,ReleaseDate,Summary")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "DirectorName", movie.DirectorId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreType", movie.GenreId);
            ViewBag.MovieId = new SelectList(db.MessageBoards, "MessageBoardId", "MessageBoardName", movie.MovieId);
            return View(movie);
        }

        // GET: /Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);

            //Unnecessary?  V
            MessageBoard messageboard = db.MessageBoards.Find(id);
            
            
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: /Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Movie movie = db.Movies.Include(i => i.MessageBoard).Where(i => i.Id == id).Single();


            Movie movie = db.Movies.Find(id);
            MessageBoard messageboard = db.MessageBoards.Find(id);
            var query = from p in db.Comments
                        where p.MessageBoardId == id
                        select p;

            foreach (var row in query)
            {
                db.Comments.Remove(row);
            }

            db.MessageBoards.Remove(messageboard);
            db.Movies.Remove(movie);
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
