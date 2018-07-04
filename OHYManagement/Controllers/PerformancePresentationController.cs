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
    public class PerformancePresentationController : BaseController
    {
        OhyMongoClient omc = new OhyMongoClient();
        // GET: PerformancePresentation
        public ActionResult Index(OHYManagement.Models.PageModel model)
        {
            long total = 0;
            List<PerformancePresentation> list = client.FindPage<PerformancePresentation>(a => a.Language == Language, model.PageIndex, out total);
            model.Count = total;
            model.Url = "/PerformancePresentation/index";
            ViewBag.model = model;
            return View(list);
        }
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(PerformancePresentation pp)
        {
            omc.InsertOne(pp);
            return View();
        }
        public ActionResult Edit()
        {
            var Id = Request.QueryString["PerformancePresentation_ht"];
            var result = omc.FindOne<PerformancePresentation>(a => a._id == ObjectId.Parse(Id));
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(PerformancePresentation pd)
        {

            pd._id = ObjectId.Parse(Request.Form["_id"]);
            //omc.HomenTextHt.UpdateOne(new ObjectFilterDefinition<HomeText>(new { _id = ht._id })
            //    , new JsonUpdateDefinition<HomeText>("{$set:{Title:\"" + ht.Title + "\"}}"));
            omc.UpdateOneById<PerformancePresentation>(pd);
            return RedirectToAction("Edit", new { PerformancePresentation_ht =pd._id});
        }
        public void Delete(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            omc.PerformancePresentationPP.DeleteOne(new ObjectFilterDefinition<PerformancePresentation>(new { _id = oid }));
        }

    }
}