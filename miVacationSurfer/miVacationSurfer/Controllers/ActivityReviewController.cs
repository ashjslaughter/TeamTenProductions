using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using miVacationSurfer;

namespace miVacationSurfer.Controllers
{
    public class ActivityReviewController : Controller
    {
        private miVacationSurferEntities db = new miVacationSurferEntities();

        // GET: ActivityReview
        public ActionResult Index()
        {
            var activityReviews = db.ActivityReviews.Include(a => a.Activity);
            return View(activityReviews.ToList());
        }

        // GET: ActivityReview/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityReview activityReview = db.ActivityReviews.Find(id);
            if (activityReview == null)
            {
                return HttpNotFound();
            }
            return View(activityReview);
        }

        // GET: ActivityReview/Create
        public ActionResult Create()
        {
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName");
            return View();
        }

        // POST: ActivityReview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ActivityRating,ActivityDate,ActivityPro,ActivityCon,ActivityReviewDetails,ActivityId")] ActivityReview activityReview)
        {
            if (ModelState.IsValid)
            {
                db.ActivityReviews.Add(activityReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", activityReview.ActivityId);
            return View(activityReview);
        }

        // GET: ActivityReview/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityReview activityReview = db.ActivityReviews.Find(id);
            if (activityReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", activityReview.ActivityId);
            return View(activityReview);
        }

        // POST: ActivityReview/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ActivityRating,ActivityDate,ActivityPro,ActivityCon,ActivityReviewDetails,ActivityId")] ActivityReview activityReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", activityReview.ActivityId);
            return View(activityReview);
        }

        // GET: ActivityReview/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityReview activityReview = db.ActivityReviews.Find(id);
            if (activityReview == null)
            {
                return HttpNotFound();
            }
            return View(activityReview);
        }

        // POST: ActivityReview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityReview activityReview = db.ActivityReviews.Find(id);
            db.ActivityReviews.Remove(activityReview);
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
