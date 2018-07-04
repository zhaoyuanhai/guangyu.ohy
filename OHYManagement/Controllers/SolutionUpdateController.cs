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
    /// 解决方案
    /// </summary>
    public class SolutionUpdateController : BaseController
    {
        /// <summary>
        /// 解决方案
        /// </summary>
        public ActionResult Index(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            Solution sol = client.FindOne<Solution>(new { _id = oid });
            if (sol == null)
            {
                sol = new Solution();
            }
            return View(sol);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileWrapper file, HttpPostedFileWrapper pdffile, string _id,string imgnames)
        {
            ObjectId oid = ObjectId.Parse(_id);
            string imgname = Guid.NewGuid().ToString() + ".jpg";
            string imgpath = Server.MapPath("~/upload/image/" + imgname);
            file.SaveAs(imgpath);

            string pdfname = Guid.NewGuid().ToString() + ".pdf";
            string pdfpath = Server.MapPath("~/upload/pdf/" + pdfname);
            pdffile.SaveAs(pdfpath);

            Solution sol = client.FindOne<Solution>(new { _id = oid });
            sol.ImgPath = "/upload/image/" + imgname;
            sol.pdfPath = "/upload/pdf/" + pdfname;
            sol.Name = imgnames;
            sol.Language = Language;
            client.UpdateOneById(sol);
            return RedirectToAction("Index", new { id = _id });
        }
        public void Delete(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            Solution info = client.FindOne<Solution>(new { _id = oid });
            client.DeleteOneById<Solution>(info);
        }
    }
}