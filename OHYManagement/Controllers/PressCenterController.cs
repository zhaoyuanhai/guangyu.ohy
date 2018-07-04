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
    public class PressCenterController : BaseController
    {
        OhyMongoClient omc = new OhyMongoClient();
        // GET: PressCenter

        public ActionResult Index(OHYManagement.Models.PageModel model)
        {
            long total = 0;
            List<PressCenter> list = client.FindPage<PressCenter>(a => a.Language == Language, model.PageIndex, out total);
            model.Count = total;
            model.Url = "/PressCenter/index";
            ViewBag.model = model;
            return View(list);
        }        
        public ActionResult Add()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(PressCenter pc)
        {
            omc.InsertOne(pc);
            return View();
        }
        public ActionResult Edit()
        {
            var Id = Request.QueryString["PressCenter_id"];
            var result = omc.FindOne<PressCenter>(a => a._id == ObjectId.Parse(Id));
            ViewBag.EditorHtml = result.Content;
            return View(result);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(PressCenter pc)
        {

            pc._id = ObjectId.Parse(Request.Form["_id"]);
            //omc.HomenTextHt.UpdateOne(new ObjectFilterDefinition<HomeText>(new { _id = ht._id })
            //    , new JsonUpdateDefinition<HomeText>("{$set:{Title:\"" + ht.Title + "\"}}"));
            omc.UpdateOneById<PressCenter>(pc);
            return RedirectToAction("Edit",new { PressCenter_id= pc._id });
        }
        public void Delete(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            omc.PressCenterPc.DeleteOne(new ObjectFilterDefinition<PressCenter>(new { _id = oid }));
        }
        //public ActionResult Delete()
        //{
        //    var Id = Request.QueryString["_id"];
        //    var homrtext = omc.FindOne<PressCenter>(a => a._id == ObjectId.Parse(Id));
        //    return View(homrtext);
        //}
        //[HttpPost]
        //public ActionResult Delete(PressCenter pd)
        //{
        //    pd._id = ObjectId.Parse(Request.Form["Id"]);
        //    omc.PressCenterPc.DeleteOne(new ObjectFilterDefinition<PressCenter>(new { _id = pd._id }));
        //    return RedirectToAction("Index");
        //}
    }
}
