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
        public ActionResult Results(string term)
        {
            var search = from x in db.LocationReviews
                         select x;
            if (!String.IsNullOrEmpty(term))
            {

                    //a search results model, like model to the view, but you would use the model
                    search = search.Where(x => x.Location.Region.RegionName.ToUpper().Contains(term.ToUpper())
                            || x.Location.LocationName.ToUpper().Contains(term.ToUpper()));
                

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