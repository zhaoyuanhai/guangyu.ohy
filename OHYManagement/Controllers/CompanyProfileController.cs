using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OHYDAL;
using OHYModel;
using MongoDB.Bson;
using MongoDB.Driver;
namespace OHYManagement.Controllers
{
    [Filter.LonginFilter]
    public class CompanyProfileController : BaseController
    {
        // GET: CompanyProfile
        OhyMongoClient omc = new OhyMongoClient();
        public ActionResult Index()
        {
            CompanyProfile list = omc.FindOne<CompanyProfile>(a => a.Language == Language);
            if (list == null)
            {
                list = new CompanyProfile();
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Index(CompanyProfile cp)
        {
            cp._id = ObjectId.Parse(Request.Form["_id"]);
            omc.UpdateOneById<CompanyProfile>(cp);
            return RedirectToAction("Index");
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Add(CompanyProfile cp)
        {
            omc.CompanyProfileCp.InsertOne(cp);
            return RedirectToAction("Index");
        }
    }
}