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
    public class IndexImageListController : BaseController
    {
        // GET: IndexImageList
        public ActionResult Index(OHYManagement.Models.PageModel model)
        {
            long total = 0;
            List<IndexImage> list = client.FindPage<IndexImage>(a => a.Language == Language, model.PageIndex, out total);
            model.Count = total;
            model.Url = "/IndexImageList/index";
            ViewBag.model = model;
            return View(list);
        }
    }
}