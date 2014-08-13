using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace miVacationSurfer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Who we are.";

            return View();
        }

        public ActionResult ChooseReview()
        {


            return View();
        }

        public ActionResult ChooseVacation()
        {


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        [Authorize(Users="team10@team10.com")]
        public ActionResult AdminIndex()
        {
            return View();
        }
    }
}