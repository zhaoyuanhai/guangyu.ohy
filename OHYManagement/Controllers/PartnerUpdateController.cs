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
    public class PartnerUpdateController : BaseController
    {
        /// <summary>
        /// 合作伙伴
        /// </summary>
        public ActionResult Index(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            CooperativePartner partner = client.FindOne<CooperativePartner>(new { _id = oid });
            if (partner == null)
            {
                partner = new CooperativePartner();
            }
            return View(partner);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileWrapper file, string _id,string imgnames)
        {
            ObjectId oid = ObjectId.Parse(_id);
            string imgname = Guid.NewGuid().ToString() + ".jpg";
            string imgpath = Server.MapPath("~/upload/image/" +imgname);
            file.SaveAs(imgpath);
            CooperativePartner partner = client.FindOne<CooperativePartner>(new { _id = oid });
            partner.ImgPath = "/upload/image/" + imgname;
            partner.Language = Language;
            partner.Name = imgnames;
            client.UpdateOneById(partner);
            return RedirectToAction("Index",new {id= _id } );
        }
        public void Delete(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            CooperativePartner partner = client.FindOne<CooperativePartner>(new { _id = oid });
            client.DeleteOneById<CooperativePartner>(partner);
        }
    }
}