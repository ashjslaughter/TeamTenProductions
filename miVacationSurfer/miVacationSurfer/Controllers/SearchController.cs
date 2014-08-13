using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace miVacationSurfer.Controllers
{
    public class SearchController : Controller
    {
        private miVacationSurferEntities db = new miVacationSurferEntities();

        // GET: Search
        public ActionResult SearchActivity(string term)
        {
            var search = from x in db.LocationReviews
                         select x;
            if (!String.IsNullOrEmpty(term))
            {

                DateTime temp;
                if (DateTime.TryParse(term, out temp))
                {

                }

                int tempRating;
                if (Int32.TryParse(term, out tempRating)) { }
                //a search results model, like model to the view, but you would use the model
                search = search.Where(x => x.Location.Region.RegionName.ToUpper().Contains(term.ToUpper())
                        || x.Location.LocationName.Contains(term)
                        || (temp != null && (x.LocationDate >= temp && x.LocationDate <= temp))
                        || ((x.LocationRating >= 1 || x.LocationRating <= 5) && (x.LocationRating == tempRating))
                        || x.LocationPro.Contains(term)
                        || x.LocationCon.Contains(term)
                        || x.LocationReviewDetails.Contains(term));
            }
            //Where (ActivityName like '%' + term + '%') OR (ActivityDescription Like '%' + term + '%')

            //Find a link on how to search the entire website
            return View(search);
        }
        public ActionResult SearchLocations()
        {
            //Similar information used above is coded here
            return View();
        }
        

    }
}