using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using miVacationSurfer;
using PagedList;
namespace miVacationSurfer.Controllers
{
    public class LocationReviewController : Controller
    {
        private miVacationSurferEntities db = new miVacationSurferEntities();

        // GET: LocationReview
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.RegionSortParm = String.IsNullOrEmpty(sortOrder) ? "region_desc" : "";
            ViewBag.RatingSortParm = String.IsNullOrEmpty(sortOrder) ? "rating_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.LocationSortParm = String.IsNullOrEmpty(sortOrder) ? "location_desc" : "";

            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var locationReviews = from s in db.LocationReviews
                                  select s;


            if (!String.IsNullOrEmpty(searchString))
            {

                DateTime temp;
                if (DateTime.TryParse(searchString, out temp))
                {

                }

                int tempRating;
                if (Int32.TryParse(searchString, out tempRating)) { }

                locationReviews = locationReviews.Where(s => s.Location.Region.RegionName.ToUpper().Contains(searchString.ToUpper())
                    || s.Location.LocationName.Contains(searchString)
                    || (temp != null && (s.LocationDate >= temp && s.LocationDate <= temp))
                    || ((s.LocationRating >= 1 || s.LocationRating <= 5) && (s.LocationRating == tempRating))
                    || s.LocationPro.Contains(searchString)
                    || s.LocationCon.Contains(searchString)
                    || s.LocationReviewDetails.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "region_desc":
                    locationReviews = locationReviews.OrderByDescending(s => s.Location.Region.RegionName);
                    break;

                case "rating_desc":
                    locationReviews = locationReviews.OrderByDescending(s => s.LocationRating);
                    break;

                case "Date":
                    locationReviews = locationReviews.OrderBy(s => s.LocationDate);
                    break;

                case "date_desc":
                    locationReviews = locationReviews.OrderByDescending(s => s.LocationDate);
                    break;

                case "location_desc":
                    locationReviews = locationReviews.OrderByDescending(s => s.Location.LocationName);
                    break;

                default:
                    locationReviews = locationReviews.OrderBy(s => s.LocationRating);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(locationReviews.ToPagedList(pageNumber, pageSize));
        }
        

        // GET: LocationReview/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationReview locationReview = db.LocationReviews.Find(id);
            if (locationReview == null)
            {
                return HttpNotFound();
            }
            return View(locationReview);
        }

        // GET: LocationReview/Create
        public ActionResult Create()
        {
            SelectList regions = new SelectList(db.Regions, "Id", "RegionName");
            ViewData["regions"] = regions;
            //ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName");
            return View();
        }

        [HttpPost]
        public JsonResult GetLocations(string regionId)
        {
            var regionLocationId = -1;
            int.TryParse(regionId, out regionLocationId);

            List<SelectListItem> regionLocations = new List<SelectListItem>();
            var locationsList =
                from r in db.Locations
                where r.RegionId == regionLocationId
                select r;


            foreach (var item in locationsList)
            {
                regionLocations.Add(new SelectListItem { Text = item.LocationName, Value = item.Id.ToString() });
            }

            return Json(regionLocations);
        }


        // POST: LocationReview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LocationRating,LocationDate,LocationPro,LocationCon,LocationReviewDetails,LocationId")] LocationReview locationReview)
        {
            if (ModelState.IsValid)
            {
                db.LocationReviews.Add(locationReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName", locationReview.LocationId);
            return View(locationReview);
        }

        // GET: LocationReview/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationReview locationReview = db.LocationReviews.Find(id);
            if (locationReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName", locationReview.LocationId);
            //SelectList regions = new SelectList(db.Regions, "Id", "RegionName");
            //ViewData["regions"] = regions;
            return View(locationReview);
        }



        // POST: LocationReview/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LocationRating,LocationDate,LocationPro,LocationCon,LocationReviewDetails,LocationId")] LocationReview locationReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName", locationReview.LocationId);
            return View(locationReview);
        }

        // GET: LocationReview/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationReview locationReview = db.LocationReviews.Find(id);
            if (locationReview == null)
            {
                return HttpNotFound();
            }
            return View(locationReview);
        }

        // POST: LocationReview/Delete/5
        [Authorize(Users = "team10@team10.com")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationReview locationReview = db.LocationReviews.Find(id);
            db.LocationReviews.Remove(locationReview);
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
