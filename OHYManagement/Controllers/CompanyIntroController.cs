using OHYModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OHYManagement.Controllers
{
    /// <summary>
    /// 公司简介
    /// </summary>
    [Filter.LonginFilter]
    public class CompanyIntroController : BaseController
    {

        // GET: 公司简介页信息录入
        public ActionResult Index()
        {
            CompanyProfile pro = client.FindOne<CompanyProfile>(new { Language = Language });
            UM u = LoginUser;
            if (pro == null)
            {
                pro = new CompanyProfile();
                pro.Language = Language;
            }
            return View(pro);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileWrapper file, string content)
        {
            string imgname = Guid.NewGuid().ToString() + ".jpg";
            string imgpath = Server.MapPath("~/upload/image/" + imgname);
            file.SaveAs(imgpath);
            CompanyProfile pro = client.FindOne<CompanyProfile>(new { Language = Language });
            if (pro == null)
            {
                pro = new CompanyProfile();
                pro.ImaPath = "/upload/image/" + imgname;
                pro.Content = content;
                pro.Language = Language;
                pro.Type = ContentTypeEnum.公司简介;
                client.InsertOne(pro);
            }
            else
            {
                pro.ImaPath = "/upload/image/" + imgname;
                pro.Content = content;
                pro.Language = Language;
                pro.Type = ContentTypeEnum.公司简介;
                client.UpdateOneById(pro);
            }
            return RedirectToAction("Index");
        }



    }
}