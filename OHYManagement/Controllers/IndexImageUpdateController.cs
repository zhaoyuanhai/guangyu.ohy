using MongoDB.Bson;
using OHYModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OHYManagement.Controllers
{
    [Filter.LonginFilter]

    /// <summary>
    /// 首页图片
    /// </summary>
    public class IndexImageUpdateController : BaseController
    {
        // GET: IndexImageUpdate
        public ActionResult Index(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            IndexImage info = client.FindOne<IndexImage>(new { _id = oid });
            if (info == null)
            {
                info = new IndexImage();
            }
            return View(info);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileWrapper file, string _id,string imgnames)
        {
            string imgname = Guid.NewGuid().ToString() + ".jpg";
            ObjectId oid = ObjectId.Parse(_id);
            string imgpath = Server.MapPath("~/upload/image/" + imgname);
            file.SaveAs(imgpath);
            IndexImage fileimg = client.FindOne<IndexImage>(new { _id = oid });
            fileimg.file = "/upload/image/" +imgname;
            fileimg.Language = Language;
            fileimg.Name = imgnames;
            client.UpdateOneById(fileimg);
            return RedirectToAction("Index", new { id = _id });
        }
        public void Delete(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            IndexImage info = client.FindOne<IndexImage>(new { _id = oid });
            client.DeleteOneById<IndexImage>(info);
        }
    }
}