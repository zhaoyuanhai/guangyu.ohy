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
    public class ProductAddController : BaseController
    {
        /// <summary>
        /// 产品中心
        /// </summary>
        public ActionResult Index()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileWrapper fileimg, HttpPostedFileWrapper filepdf,string imgnames)
        {
            Product product = new Product();
            string imgname = Guid.NewGuid().ToString() + ".jpg";
            string pdfname = Guid.NewGuid().ToString() + ".pdf";
            product._id =ObjectId.GenerateNewId();
            fileimg.SaveAs(Server.MapPath("~/upload/image/" + imgname));
            string pdfpath = Server.MapPath("~/upload/pdf/" + pdfname);
            filepdf.SaveAs(pdfpath);
            var  count=OHYCommon.FileCommon.ConvertPDF2Image(pdfpath, Server.MapPath($"~/temp/{product._id}/"), "pdf", -1, int.MaxValue, System.Drawing.Imaging.ImageFormat.Jpeg);
            //filepdf.SaveAs(pdfpath);
            product.PdfCount = count;
            product.Name = imgnames;
            product.Cover = "/upload/image/" + imgname;
            product.PdfPath = "/upload/pdf/" + pdfname;
            product.Language = Language;
            client.InsertOne(product);
            return RedirectToAction("Index");
        }
    }
}