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
    public class HomeTextController : BaseController
    {
        OhyMongoClient omc = new OhyMongoClient();
        // GET: HomeText
        public ActionResult Index(OHYManagement.Models.PageModel model)
        {
            long total = 0;
            List<HomeText> list = omc.FindPage<HomeText>(t=>1==1,model.PageIndex,out total);
            model.Count = total;
            model.Url = "/HomeText/index";
            ViewBag.model = model;
            return View(list);
        }
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(HomeText ht)
        {
            omc.HomenTextHt.InsertOne(ht);
            return RedirectToAction("Index");
        }
        public ActionResult Edit()
        {
            var Id = Request.QueryString["HomeText_ht"];
            var homrtext = omc.FindOne<HomeText>(a => a._id == ObjectId.Parse(Id));
            return View(homrtext);
        }
        [HttpPost]
        public ActionResult Edit(HomeText ht)
        {
            ht._id = ObjectId.Parse(Request.Form["_id"]);
            //omc.HomenTextHt.UpdateOne(new ObjectFilterDefinition<HomeText>(new { _id = ht._id })
            //    , new JsonUpdateDefinition<HomeText>("{$set:{Title:\"" + ht.Title + "\"}}"));
            omc.UpdateOneById<HomeText>(ht);
            //return RedirectToAction("Index");
            return RedirectToAction("Edit", new { HomeText_ht = ht._id });
        }
        public void Delete(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            omc.HomenTextHt.DeleteOne(new ObjectFilterDefinition<HomeText>(new { _id = oid }));

        }
    }
}