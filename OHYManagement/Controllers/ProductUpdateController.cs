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
    public class ProductUpdateController : BaseController
    {
        /// <summary>
        /// 产品中心
        /// </summary>
        public ActionResult Index(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            Product product = client.FindOne<Product>(new { _id = oid });
            if (product == null)
            {
                product = new Product();
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileWrapper fileimg, HttpPostedFileWrapper filepdf, string _id,string imgnames)
        {
            ObjectId oid = ObjectId.Parse(_id);
            string imgname = Guid.NewGuid().ToString() + ".jpg";
            string pdfname = Guid.NewGuid().ToString() + ".pdf";
            fileimg.SaveAs(Server.MapPath("~/upload/image/" + imgname));
            string pdfpath = Server.MapPath("~/upload/pdf/" + pdfname);
            filepdf.SaveAs(pdfpath);
            var count = OHYCommon.FileCommon.ConvertPDF2Image(pdfpath, Server.MapPath($"~/temp/{_id}/"), "pdf", -1, int.MaxValue, System.Drawing.Imaging.ImageFormat.Jpeg);
            //filepdf.SaveAs(Server.MapPath("~/upload/pdf/" + filepdf.FileName));
            Product product = client.FindOne<Product>(new { _id = oid });
            product.Cover = "/upload/image/" + imgname;
            product.PdfPath = "/upload/pdf/" + pdfname;
            product.Name = imgnames;
            product.PdfCount = count;
            product.Language = Language;
            client.UpdateOneById(product);
            return RedirectToAction("Index", new { id = _id });
        }
        public void Delete(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            Product info = client.FindOne<Product>(new { _id = oid });
            client.DeleteOneById<Product>(info);
        }
    }
}