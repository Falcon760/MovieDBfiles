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
    public class DirectorController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();


        public ActionResult Search(string SearchBox)
        {
            var dirs = from t in db.Directors select t;
            if (!String.IsNullOrEmpty(SearchBox))
            {

                dirs = from t in db.Directors
                         where t.DirectorName.Contains(SearchBox)
                         //|| t.FirstName.Contains(SearchBox)
                         select t;

            }
            return View("Index", dirs.ToList());
        }

        // GET: /Director/
        public ActionResult Index()
        {
            var directors = db.Directors.Include(d => d.MessageBoardD);
            return View(directors.ToList());
        }

        // GET: /Director/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.DirectorId = new SelectList(db.MessageBoardDs, "MessageBoardId", "MessageBoardName");
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DirectorId,DirectorName,DateOfBirth,Bio")] Director director)
        {
            if (ModelState.IsValid)
            {
                db.Directors.Add(director);
                db.SaveChanges();
                var msgboard = new MessageBoardD { MessageBoardId = director.DirectorId, MessageBoardName = (director.DirectorName + " Comments") };
                db.MessageBoardDs.Add(msgboard);
                db.SaveChanges();
                return RedirectToAction("Index","Movie");


                //db.Directors.Add(director);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            ViewBag.DirectorId = new SelectList(db.MessageBoardDs, "MessageBoardId", "MessageBoardName", director.DirectorId);
            return View(director);
        }

        // GET: /Director/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectorId = new SelectList(db.MessageBoardDs, "MessageBoardId", "MessageBoardName", director.DirectorId);
            return View(director);
        }

        // POST: /Director/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DirectorId,DirectorName,DateOfBirth,Bio")] Director director)
        {
            if (ModelState.IsValid)
            {
                db.Entry(director).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectorId = new SelectList(db.MessageBoardDs, "MessageBoardId", "MessageBoardName", director.DirectorId);
            return View(director);
        }

        // GET: /Director/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Director director = db.Directors.Find(id);
            db.Directors.Remove(director);
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
