using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using miVacationSurfer;

namespace miVacationSurfer.Controllers
{
    public class ActivityReviewController : Controller
    {
        private miVacationSurferEntities db = new miVacationSurferEntities();

        // GET: ActivityReview
        public ActionResult Index(string currentFilter, string sortOrder, string searchString, int? page)
        {
            
            ViewBag.RatingSortParm = String.IsNullOrEmpty(sortOrder) ? "rating_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.ActivitySortParm = String.IsNullOrEmpty(sortOrder) ? "activity_desc" : "";
          
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var activityReviews = db.ActivityReviews.Include(a => a.Activity);

            if (!String.IsNullOrEmpty(searchString))
            {

                DateTime temp;
                if (DateTime.TryParse(searchString, out temp))
                {

                }

                int tempRating;
                if (Int32.TryParse(searchString, out tempRating)) { }

                activityReviews = activityReviews.Where(s => ((s.ActivityRating >= 1 || s.ActivityRating <= 5) && (s.ActivityRating == tempRating))
                    || (temp != null && (s.ActivityDate >= temp && s.ActivityDate <= temp))
                    || s.ActivityPro.Contains(searchString)
                    || s.ActivityCon.Contains(searchString)
                    || s.ActivityReviewDetails.Contains(searchString)
                    || s.Activity.ActivityName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "rating_desc":
                    activityReviews = activityReviews.OrderByDescending(s => s.ActivityRating);
                    break;

                case "Date":
                    activityReviews = activityReviews.OrderBy(s => s.ActivityDate);
                    break;

                case "activity_desc":
                    activityReviews = activityReviews.OrderBy(s => s.Activity.ActivityName);
                    break;

                default:
                    activityReviews = activityReviews.OrderBy(s => s.ActivityRating);
                    break;
            }
                        int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(activityReviews.ToPagedList(pageNumber, pageSize));
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
           
            SelectList seasons = new SelectList(db.Seasons, "Id", "SeasonName");
            ViewData["seasons"] = seasons;
            
            return View();
        }

    

        [HttpPost]
        public JsonResult GetActivitys(int seasonId)
        {
          
            var seasonActivitys =
                from r in db.Seasons
                join r2 in db.SeasonActivities
                on r.Id equals r2.SeasonId
                where (r.Id == seasonId) && (r2.SeasonId == seasonId)
                select new SelectListItem { Text = r2.Activity.ActivityName, Value = r2.ActivityId.ToString()};

            return Json(seasonActivitys);
        }

       

        // POST: ActivityReview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ActivityRating,ActivityDate,ActivityPro,ActivityCon,ActivityReviewDetails,ActivityId")] ActivityReview activityReview, int activityId)
        {
            if (ModelState.IsValid)
            {
                db.ActivityReviews.Add(activityReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", activityReview.ActivityId);
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
        [Authorize(Users = "team10@team10.com")]
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
