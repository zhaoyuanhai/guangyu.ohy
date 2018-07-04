using MongoDB.Bson;
using OHYDAL;
using OHYModel;
using OHYUI.Models;
using System.Web.Mvc;
using System.Linq;

namespace OHYUI.Controllers
{
    public class DetailController : BaseController
    {
        OhyMongoClient client = new OhyMongoClient();

        /// <summary>
        /// 产品详情
        /// </summary>
        /// <returns></returns>
        //[OutputCache(Duration = 60 * 10, VaryByParam = "id")]
        public ActionResult ProductDetail(string id)
        {
            var product = client.FindOne<Product>(e => e._id == ObjectId.Parse(id));
            var version = double.Parse(Request.Browser.Version);
            if (Request.Browser.Id.ToLower() == "internetexplorer" /*&& version <= 10*/)
                return File(Server.MapPath(product.PdfPath), "application/PDF", product.Name);
            else
                return View(new FileImageModel() { Id = id, Count = product.PdfCount, Path = $"/temp/{id}/", Conver = product.Cover });
        }

        /// <summary>
        /// 公司简介
        /// </summary>
        /// <returns></returns>
        public ActionResult CompanyProfile()
        {
            CompanyProfile company = client.FindOne<CompanyProfile>(e => e.Language == Language);

            return View(company);
        }

        /// <summary>
        /// 合作伙伴
        /// </summary>
        /// <returns></returns>
        public ActionResult Cooperativepartner()
        {
            var models = client.Find<CooperativePartner>(e => e.Language == Language);
            return View(models);
        }

        /// <summary>
        /// 产品中心
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductCenter()
        {
            var modelList = client.Find<Product>(e => e.Language == Language);
            return View(modelList);
        }

        /// <summary>
        /// 解决方案
        /// </summary>
        /// <returns></returns>
        public ActionResult Solution()
        {
            var modelList = client.Find<Solution>(e => e.Language == Language);
            return View(modelList);
        }

        /// <summary>
        /// 业绩展示
        /// </summary>
        /// <returns></returns>
        public ActionResult PreShow()
        {
            var modelList = client.Find<PerformancePresentation>(e => e.Language == Language);
            return View(modelList);
        }

        /// <summary>
        /// 新闻中心
        /// </summary>
        /// <returns></returns>
        public ActionResult NewsCenter(PageingModel pageing)
        {
            pageing.PageSize = 4;
            long total;
            var modelList = client.FindPage<PressCenter>(e => e.Language == Language /*&& e.Type == ContentTypeEnum.企业动态*/,
                pageing.PageIndex, out total, pageing.PageSize, -1);

            pageing.Total = (int)total;
            ViewBag.Pageing = pageing;
            return View(modelList);
        }

        public ActionResult NewsDetail(string id)
        {
            var news = client.FindOne<PressCenter>(e => e._id == ObjectId.Parse(id));

            return View(news);
        }

        /// <summary>
        /// 联系方式
        /// </summary>
        /// <returns></returns>
        public ActionResult ContactInformation()
        {
            var model = client.FindOne<CompanyProfile>(e => e.Language == Language);
            return View(model);
        }
    }
}