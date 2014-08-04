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
    public class SeasonActivityController : Controller
    {
        private miVacationSurferEntities db = new miVacationSurferEntities();

        // GET: SeasonActivity
        public ActionResult Index()
        {
            var seasonActivities = db.SeasonActivities.Include(s => s.Activity).Include(s => s.Season);
            return View(seasonActivities.ToList());
        }

        // GET: SeasonActivity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeasonActivity seasonActivity = db.SeasonActivities.Find(id);
            if (seasonActivity == null)
            {
                return HttpNotFound();
            }
            return View(seasonActivity);
        }

        // GET: SeasonActivity/Create
        public ActionResult Create()
        {
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName");
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "SeasonName");
            return View();
        }

        // POST: SeasonActivity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ActivityId,SeasonId")] SeasonActivity seasonActivity)
        {
            if (ModelState.IsValid)
            {
                db.SeasonActivities.Add(seasonActivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", seasonActivity.ActivityId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "SeasonName", seasonActivity.SeasonId);
            return View(seasonActivity);
        }

        // GET: SeasonActivity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeasonActivity seasonActivity = db.SeasonActivities.Find(id);
            if (seasonActivity == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", seasonActivity.ActivityId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "SeasonName", seasonActivity.SeasonId);
            return View(seasonActivity);
        }

        // POST: SeasonActivity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ActivityId,SeasonId")] SeasonActivity seasonActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seasonActivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", seasonActivity.ActivityId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "SeasonName", seasonActivity.SeasonId);
            return View(seasonActivity);
        }

        // GET: SeasonActivity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeasonActivity seasonActivity = db.SeasonActivities.Find(id);
            if (seasonActivity == null)
            {
                return HttpNotFound();
            }
            return View(seasonActivity);
        }

        // POST: SeasonActivity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeasonActivity seasonActivity = db.SeasonActivities.Find(id);
            db.SeasonActivities.Remove(seasonActivity);
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
