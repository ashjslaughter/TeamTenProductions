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
    public class ActivityTypeController : Controller
    {
        private miVacationSurferEntities db = new miVacationSurferEntities();

        // GET: ActivityType
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Index(string sortOrder)
        {
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            var activityTypes = from s in db.ActivityTypes
                        select s;
            switch(sortOrder)
            {
                case "type_desc":
                    activityTypes = activityTypes.OrderByDescending(s => s.ActivityTypeName);
                    break;
                default:
                    activityTypes = activityTypes.OrderBy(s => s.ActivityTypeName);
                    break;
            }

            return View(activityTypes.ToList());
        }

        // GET: ActivityType/Details/5
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityType activityType = db.ActivityTypes.Find(id);
            if (activityType == null)
            {
                return HttpNotFound();
            }
            return View(activityType);
        }

        // GET: ActivityType/Create
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActivityType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "team10@team10.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ActivityTypeName,ActivityTypeDesc")] ActivityType activityType)
        {
            if (ModelState.IsValid)
            {
                db.ActivityTypes.Add(activityType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activityType);
        }

        // GET: ActivityType/Edit/5
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityType activityType = db.ActivityTypes.Find(id);
            if (activityType == null)
            {
                return HttpNotFound();
            }
            return View(activityType);
        }

        // POST: ActivityType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "team10@team10.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ActivityTypeName,ActivityTypeDesc")] ActivityType activityType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activityType);
        }

        // GET: ActivityType/Delete/5
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityType activityType = db.ActivityTypes.Find(id);
            if (activityType == null)
            {
                return HttpNotFound();
            }
            return View(activityType);
        }

        // POST: ActivityType/Delete/5
        [Authorize(Users = "team10@team10.com")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityType activityType = db.ActivityTypes.Find(id);
            db.ActivityTypes.Remove(activityType);
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
