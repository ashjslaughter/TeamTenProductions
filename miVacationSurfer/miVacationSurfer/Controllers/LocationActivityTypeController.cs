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
    public class LocationActivityTypeController : Controller
    {
        private miVacationSurferEntities db = new miVacationSurferEntities();

        // GET: LocationActivityType
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Index()
        {
            var locationActivityTypes = db.LocationActivityTypes.Include(l => l.ActivityType).Include(l => l.Location);
            return View(locationActivityTypes.ToList());
        }

        // GET: LocationActivityType/Details/5
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationActivityType locationActivityType = db.LocationActivityTypes.Find(id);
            if (locationActivityType == null)
            {
                return HttpNotFound();
            }
            return View(locationActivityType);
        }

        // GET: LocationActivityType/Create
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Create()
        {
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName");
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName");
            return View();
        }

        // POST: LocationActivityType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "team10@team10.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ActivityTypeId,LocationId")] LocationActivityType locationActivityType)
        {
            if (ModelState.IsValid)
            {
                db.LocationActivityTypes.Add(locationActivityType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", locationActivityType.ActivityTypeId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName", locationActivityType.LocationId);
            return View(locationActivityType);
        }

        // GET: LocationActivityType/Edit/5
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationActivityType locationActivityType = db.LocationActivityTypes.Find(id);
            if (locationActivityType == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", locationActivityType.ActivityTypeId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName", locationActivityType.LocationId);
            return View(locationActivityType);
        }

        // POST: LocationActivityType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "team10@team10.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ActivityTypeId,LocationId")] LocationActivityType locationActivityType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationActivityType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", locationActivityType.ActivityTypeId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName", locationActivityType.LocationId);
            return View(locationActivityType);
        }

        // GET: LocationActivityType/Delete/5
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationActivityType locationActivityType = db.LocationActivityTypes.Find(id);
            if (locationActivityType == null)
            {
                return HttpNotFound();
            }
            return View(locationActivityType);
        }

        // POST: LocationActivityType/Delete/5
        [Authorize(Users = "team10@team10.com")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationActivityType locationActivityType = db.LocationActivityTypes.Find(id);
            db.LocationActivityTypes.Remove(locationActivityType);
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
