using OHYDAL;
using OHYModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OHYManagement.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            //var UserName = Request.Cookies["UserName"] == null ? "" : Request.Cookies["UserName"].Value;
            //ViewBag.UserName = UserName;

            return View();
        }
        public string Loginlocal(UM userInfo)
        {
            string re = "";
            OhyMongoClient omc = new OhyMongoClient();
            UM users = omc.FindOne<UM>(a => a.UserName == userInfo.UserName && a.PassWord == userInfo.PassWord);

            if (users!=null)
            {
                //Session["User"] = userInfo.UserName;
                HttpCookie user = new HttpCookie("User");
                user.Value = users._id.ToString();
                System.Web.HttpContext.Current.Response.SetCookie(user);
                re = "1";
            }
            return re;
        }

        /// <summary>
        /// 验证码的校验
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ActionResult CheckCode()
        {
            //生成验证码
            VerifyCode validateCode = new VerifyCode();
            string code = validateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
    }
}