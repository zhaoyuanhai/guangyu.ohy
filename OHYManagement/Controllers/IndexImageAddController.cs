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
    public class IndexImageAddController : BaseController
    {
        // GET: IndexImageAdd
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileWrapper file,string imgnames)
        {
            string imgname = Guid.NewGuid().ToString() + ".jpg";
            string imgpath = Server.MapPath("~/upload/image/" + imgname);
            file.SaveAs(imgpath);
            IndexImage fileimg = new IndexImage();
            fileimg.file = "/upload/image/" + imgname;
            fileimg.Language = Language;
            fileimg.Name = imgnames;
            client.InsertOne(fileimg);
            return RedirectToAction("Index");
        }
    }
}