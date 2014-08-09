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
    public class LocationController : Controller
    {
        private miVacationSurferEntities db = new miVacationSurferEntities();

        // GET: Location
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SizeSortParm = String.IsNullOrEmpty(sortOrder) ? "size_desc" : "";
            ViewBag.RegionSortParm = String.IsNullOrEmpty(sortOrder) ? "region_desc" : "";

            var locations = from s in db.Locations
                          select s;
            switch (sortOrder)
            {
                case "name_desc":
                    locations = locations.OrderByDescending(s => s.LocationName);
                    break;

                case "size_desc":
                    locations = locations.OrderByDescending(s => s.Size);
                    break;

                case "region_desc":
                    locations = locations.OrderByDescending(s => s.Region.RegionName);
                    break;

                default:
                    locations = locations.OrderBy(s => s.LocationName);
                    break;
            }
            
            return View(locations.ToList());
        }

        // GET: Location/Details/5
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Location/Create
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "RegionName");
            return View();
        }

        // POST: Location/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "team10@team10.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LocationName,LocationDesc,Size,RegionId")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(db.Regions, "Id", "RegionName", location.RegionId);
            return View(location);
        }

        // GET: Location/Edit/5
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "RegionName", location.RegionId);
            return View(location);
        }

        // POST: Location/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "team10@team10.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LocationName,LocationDesc,Size,RegionId")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "RegionName", location.RegionId);
            return View(location);
        }

        // GET: Location/Delete/5
        [Authorize(Users = "team10@team10.com")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Location/Delete/5
        [Authorize(Users = "team10@team10.com")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
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
