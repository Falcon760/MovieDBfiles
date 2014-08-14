using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieMasterProject;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace MovieMasterProject.Controllers
{
    public class MovieController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        public ActionResult Search(string SearchBox)
        
        {
            
            var movies = from t in db.Movies select t;

            int rCount = 0;
            var ratings = db.Ratings;
            foreach (var mov in movies)
            {
                mov.Rating = 0;
                foreach (var rating in ratings)
                {
                    if (rating.MovieId == mov.MovieId)
                    {
                        mov.Rating += rating.Value;
                        rCount += 1;
                    }

                }
                if (rCount != 0)
                {
                    mov.Rating = mov.Rating / rCount;
                }
                rCount = 0;
            }
            DateTime searchDate;
            if(!String.IsNullOrEmpty(SearchBox))
            {
                bool isDateSearch = DateTime.TryParse(SearchBox, out searchDate);
                if (isDateSearch)
                {
                    movies = movies.Where(s => s.ReleaseDate == searchDate);
                }
                else
                {

                    movies = from t in db.Movies
                              where t.Title.Contains(SearchBox)
                              || t.Genre.GenreType.Contains(SearchBox)
                              select t;
                }
            }

            return View("Index", movies.ToList().ToPagedList(1,9));
        }


        // GET: /Movie/
        public ActionResult Index(string sortOrder,int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var movies = db.Movies.Include(m => m.Director).Include(m => m.Genre).Include(m => m.MessageBoard);
            switch (sortOrder)
            {
                case "title_desc":
                    movies = movies.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    movies = movies.OrderBy(s => s.ReleaseDate);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(s => s.ReleaseDate);
                    break;
                default:
                    movies = movies.OrderBy(s => s.Title);
                    break;
            }

            int rCount = 0;
            var ratings = db.Ratings;
            foreach (var mov in movies)
            {
                mov.Rating = 0;
                foreach (var rating in ratings)
                {
                    if (rating.MovieId == mov.MovieId){
                        mov.Rating += rating.Value;
                        rCount += 1;
                    }

                }
                if (rCount != 0)
                {
                    mov.Rating = mov.Rating / rCount;
                }
                rCount = 0;
            }
            
            return View(movies.ToList().ToPagedList(page ?? 1,6));


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
        [Authorize]
        public ActionResult Create()
        {
     

            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "DirectorName");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreType");
            ViewBag.MovieId = new SelectList(db.MessageBoards, "MessageBoardId", "MessageBoardName");
            return View();
        }

        //to get picture 
        // has to be a jpeg
        public ActionResult GetImage(int id)
        {
            byte[] imageData = db.Movies.Find(id).Picture;
            return File(imageData, "image/jpeg");
        }







        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MovieId,Title,DirectorId,GenreId,Rating,ReleaseDate,Summary")] Movie movie,HttpPostedFileBase ImageFile)
        {



            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string pic = System.IO.Path.GetFileName(ImageFile.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/img"),pic);
                    ImageFile.SaveAs(path); //file saved to server here dude
                    movie.ImagePath = pic; //picture name will be associated with each movie

                    using (MemoryStream ms = new MemoryStream())
                    {
                        ImageFile.InputStream.CopyTo(ms);
                        movie.Picture = ms.GetBuffer();

                    }

                }

                //saved in two places


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
        [Authorize]
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
        //[Authorize(Users="UserName", Roles="")]
       [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Movie movie = db.Movies.Include(i => i.MessageBoard).Where(i => i.Id == id).Single();


            Movie movie = db.Movies.Find(id);
            MessageBoard messageboard = db.MessageBoards.Find(id);
            Rating rating = db.Ratings.Find(id);
          
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
