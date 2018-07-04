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
    /// 合作伙伴
    /// </summary>
    public class PartnerAddController : BaseController
    {
        // GET: Partner
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileWrapper file, CooperativePartner partner,string imgnames)
        {
            if (file != null)
            {
                string imgname = Guid.NewGuid().ToString() + ".jpg";
                string imgpath = Server.MapPath("~/upload/image/" + imgname);
                file.SaveAs(imgpath);
                partner.ImgPath = "/upload/image/" + imgname;
                partner.Name = imgnames;
                client.InsertOne(partner);
            }
            return RedirectToAction("Index");
        }
    }
}