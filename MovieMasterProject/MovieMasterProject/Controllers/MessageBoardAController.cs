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
    public class MessageBoardAController : Controller
    {
        private MovieLoversDBEntities db = new MovieLoversDBEntities();

        // GET: /MessageBoardA/
        public ActionResult Index()
        {
            var messageboardas = db.MessageBoardAs.Include(m => m.Actor);
            return View(messageboardas.ToList());
        }

        // GET: /MessageBoardA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoardA messageboarda = db.MessageBoardAs.Find(id);
            if (messageboarda == null)
            {
                return HttpNotFound();
            }
            return View(messageboarda);
        }

        // GET: /MessageBoardA/Create
        public ActionResult Create()
        {
            ViewBag.MessageBoardId = new SelectList(db.Actors, "ActorId", "FirstName");
            return View();
        }

        // POST: /MessageBoardA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MessageBoardId,MessageBoardName")] MessageBoardA messageboarda)
        {
            if (ModelState.IsValid)
            {
                db.MessageBoardAs.Add(messageboarda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MessageBoardId = new SelectList(db.Actors, "ActorId", "FirstName", messageboarda.MessageBoardId);
            return View(messageboarda);
        }

        // GET: /MessageBoardA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoardA messageboarda = db.MessageBoardAs.Find(id);
            if (messageboarda == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageBoardId = new SelectList(db.Actors, "ActorId", "FirstName", messageboarda.MessageBoardId);
            return View(messageboarda);
        }

        // POST: /MessageBoardA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MessageBoardId,MessageBoardName")] MessageBoardA messageboarda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageboarda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageBoardId = new SelectList(db.Actors, "ActorId", "FirstName", messageboarda.MessageBoardId);
            return View(messageboarda);
        }

        // GET: /MessageBoardA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoardA messageboarda = db.MessageBoardAs.Find(id);
            if (messageboarda == null)
            {
                return HttpNotFound();
            }
            return View(messageboarda);
        }

        // POST: /MessageBoardA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageBoardA messageboarda = db.MessageBoardAs.Find(id);
            db.MessageBoardAs.Remove(messageboarda);
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
