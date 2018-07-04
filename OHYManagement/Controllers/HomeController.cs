using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OHYManagement.Controllers
{
    [Filter.LonginFilter]
    public class HomeController : Controller
    {
        public ActionResult Index(string UserName)
        {
          
            ObjectId id = ObjectId.GenerateNewId();
            var mingzi = this.TempData["Username"] as string;
            ViewBag.UserName = UserName;
       
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}