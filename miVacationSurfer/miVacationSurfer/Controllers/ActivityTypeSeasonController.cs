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
    public class ActivityTypeSeasonController : Controller
    {
        private miVacationSurferEntities db = new miVacationSurferEntities();

        // GET: ActivityTypeSeason
        public ActionResult Index()
        {
            var activityTypeSeasons = db.ActivityTypeSeasons.Include(a => a.ActivityType).Include(a => a.Season);
            return View(activityTypeSeasons.ToList());
        }

        // GET: ActivityTypeSeason/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityTypeSeason activityTypeSeason = db.ActivityTypeSeasons.Find(id);
            if (activityTypeSeason == null)
            {
                return HttpNotFound();
            }
            return View(activityTypeSeason);
        }

        // GET: ActivityTypeSeason/Create
        public ActionResult Create()
        {
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName");
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "SeasonName");
            return View();
        }

        // POST: ActivityTypeSeason/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SeasonId,ActivityTypeId")] ActivityTypeSeason activityTypeSeason)
        {
            if (ModelState.IsValid)
            {
                db.ActivityTypeSeasons.Add(activityTypeSeason);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", activityTypeSeason.ActivityTypeId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "SeasonName", activityTypeSeason.SeasonId);
            return View(activityTypeSeason);
        }

        // GET: ActivityTypeSeason/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityTypeSeason activityTypeSeason = db.ActivityTypeSeasons.Find(id);
            if (activityTypeSeason == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", activityTypeSeason.ActivityTypeId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "SeasonName", activityTypeSeason.SeasonId);
            return View(activityTypeSeason);
        }

        // POST: ActivityTypeSeason/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SeasonId,ActivityTypeId")] ActivityTypeSeason activityTypeSeason)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityTypeSeason).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", activityTypeSeason.ActivityTypeId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "SeasonName", activityTypeSeason.SeasonId);
            return View(activityTypeSeason);
        }

        // GET: ActivityTypeSeason/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityTypeSeason activityTypeSeason = db.ActivityTypeSeasons.Find(id);
            if (activityTypeSeason == null)
            {
                return HttpNotFound();
            }
            return View(activityTypeSeason);
        }

        // POST: ActivityTypeSeason/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityTypeSeason activityTypeSeason = db.ActivityTypeSeasons.Find(id);
            db.ActivityTypeSeasons.Remove(activityTypeSeason);
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
