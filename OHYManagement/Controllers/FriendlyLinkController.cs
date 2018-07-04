using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OHYModel;
using MongoDB.Bson;

namespace OHYManagement.Controllers
{
    [Filter.LonginFilter]
    public class FriendlyLinkController : BaseController
    {
        // GET: FriendlyLink
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileWrapper file)
        {
            string imgname = Guid.NewGuid().ToString() + ".jpg";
            string imgpath = Server.MapPath("~/upload/image/" + imgname);
            file.SaveAs(imgpath);
            FriendlyLink fileimg = new FriendlyLink();
            fileimg.Path = "/upload/image/" + imgname;
            fileimg.Language = Language;
            fileimg.Url = Request.Form[1].ToString();
            client.InsertOne(fileimg);
            return RedirectToAction("Index");
        }
        public ActionResult FriendlyLinkList()
        {
            List<FriendlyLink> list = client.Find<FriendlyLink>(t => t.Language == Language);
            return View(list);
        }

        public ActionResult FriendlyLinkUpdate(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            FriendlyLink info = client.FindOne<FriendlyLink>(new { _id = oid });
            if (info == null)
            {
                info = new FriendlyLink();
            }
            return View(info);
        }
        [HttpPost]
        public ActionResult FriendlyLinkUpdate(HttpPostedFileWrapper file, string _id)
        {
            ObjectId oid = ObjectId.Parse(_id);
            string imgname = Guid.NewGuid().ToString() + ".jpg";
            string imgpath = Server.MapPath("~/upload/image/" + imgname);
            file.SaveAs(imgpath);
            FriendlyLink fileimg = client.FindOne<FriendlyLink>(new { _id = oid });
            fileimg.Path = "/upload/friendly/" + imgname;
            fileimg.Language = Language;
            fileimg.Url = Request.Form[1].ToString();
            client.UpdateOneById(fileimg);

            return RedirectToAction("FriendlyLinkUpdate", new { id = _id });
        }

        public void Delete(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            FriendlyLink info = client.FindOne<FriendlyLink>(new { _id = oid });
            client.DeleteOneById<FriendlyLink>(info);
        }
    }
}