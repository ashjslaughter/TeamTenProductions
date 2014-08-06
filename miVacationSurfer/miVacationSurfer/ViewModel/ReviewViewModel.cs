using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace miVacationSurfer.ViewModel
{
    public class ReviewViewModel
    {
        public virtual List<Region> Regions { get; set; }
        public virtual List<Location> Locations { get; set; }
        public virtual List<ActivityType> ActivityTypes { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }
        public virtual ICollection<Activity> Activitys { get; set; }

        //public ReviewViewModel()
        //{
        //    Regions = new SelectList();
        //    Locations = new SelectList(Lo);
        //    ActivityTypes = new ActivityType();
        //    Seasons = new Season();
        //    Activitys = new Activity();
        //}
    }
}