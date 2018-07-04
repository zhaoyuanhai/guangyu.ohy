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
    public class SolutionAddController : BaseController
    {
        // GET: Solution
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileWrapper file,HttpPostedFileWrapper pdffile,string imgnames)
        {
            string imgname = Guid.NewGuid().ToString() + ".jpg";
            string imgpath = Server.MapPath("~/upload/image/" + imgname);
            file.SaveAs(imgpath);

            string pdfname = Guid.NewGuid().ToString() + ".pdf";
            string pdfpath = Server.MapPath("~/upload/pdf/" + pdfname);
            pdffile.SaveAs(pdfpath);

            Solution sol = new Solution();
            sol.ImgPath = "/upload/image/" + imgname;
            sol.pdfPath = "/upload/pdf/" + pdfname;
            sol.Language = Language;
            sol.Name = imgnames;
            client.InsertOne(sol);

            return RedirectToAction("Index");
        }
    }
}