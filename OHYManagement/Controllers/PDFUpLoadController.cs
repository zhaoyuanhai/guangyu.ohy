using System;
using System.Collections.Generic;
using System.Linq;
using OHYDAL;
using OHYModel;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace OHYManagement.Controllers
{
    [Filter.LonginFilter]
    public class PDFUpLoadController : Controller
    {
        OhyMongoClient omc = new OhyMongoClient();
        // GET: PDFUpLoad
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }
        /// <summary>
        /// 提交方法
        /// </summary>
        /// <param name="tm">模型数据</param>
        /// <param name="file">上传的文件对象，此处的参数名称要与View中的上传标签名称相同</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Upload(PDF pdf, HttpPostedFileBase file)
        {
            if (file == null)
            {
                return Content("没有文件！", "text/plain");
            }
            var fileName = Path.Combine(Request.MapPath("~/Upload"), Path.GetFileName(file.FileName));
            try
            {
                file.SaveAs(fileName);
                //tm.AttachmentPath = fileName;//得到全部model信息

                pdf.AttachmentPath = "../upload/" + Path.GetFileName(file.FileName);
                //return Content("上传成功！", "text/plain");
                //omc.UserManagerUM.InsertOne(new UM() { UserName = "admin", Password = "admin@123" });
                  omc.PDFP.InsertOne(new PDF() { Title = pdf.Title, AttachmentPath = pdf.AttachmentPath, Content = pdf.Content });
                return RedirectToAction("Show", pdf);
            }
            catch
            {
                return Content("上传异常 ！", "text/plain");
            }
        }
        public ActionResult Show(PDF tm)
        {
            return View(tm);
        }
    }
}