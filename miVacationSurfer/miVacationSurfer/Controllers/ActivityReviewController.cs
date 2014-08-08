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
        public ActionResult Index(string filterIt, string searchString, int? page)
        {
            if(searchString !=null)
            {
                page = 1;
            }
            else
            {
                searchString = filterIt;
            }
            ViewBag.CurrentFilter = searchString;
            var activityReviews = db.ActivityReviews.Include(a => a.Activity);

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
            SelectList activityTypes = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName");
            ViewData["activityTypes"] = activityTypes;

            //SelectList seasons = new SelectList(db.Seasons, "Id", "SeasonName");
            //ViewData["seasons"] = seasons;
            
            return View();
        }

        [HttpPost]
        public JsonResult GetSeasons( int activitytypeId)
        {
            List<SelectListItem> activityTypeSeasons = new List<SelectListItem>();
            var activityTypeList =
                 from a in db.ActivityTypeSeasons
                 where a.ActivityTypeId == activitytypeId
                 select a;

            foreach (var item in activityTypeList)
            {
                activityTypeSeasons.Add(new SelectListItem { Text = item.Season.SeasonName, Value = item.Season.Id.ToString() });
            }


            return Json(activityTypeSeasons);
        }

        [HttpPost]
        public JsonResult GetActivitys(int seasonId)
        {
            //var seasonActivityId = -1;
            //int.TryParse(seasonId, out seasonActivityId);
            List<SelectListItem> seasonActivitys = new List<SelectListItem>();
            var seasonList =
                 from r in db.SeasonActivities
                 where r.SeasonId == seasonId
                 select r;

            foreach (var item in seasonList)
            {
                seasonActivitys.Add(new SelectListItem { Text = item.Activity.ActivityName, Value = item.Activity.Id.ToString() });
            }

          
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
