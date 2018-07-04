using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OHYDAL;
using OHYModel;

namespace OHYUI.Controllers
{
    public class BaseController : Controller
    {
        protected LanguageEnum Language = LanguageEnum.中文;

        private static Dictionary<int, string> _languageList;

        protected Dictionary<int, string> LanguageList
        {
            get
            {
                if (_languageList == null)
                {
                    _languageList = new Dictionary<int, string>();
                    string[] names = Enum.GetNames(typeof(LanguageEnum));
                    foreach (string name in names)
                    {
                        int value = (int)((LanguageEnum)Enum.Parse(typeof(LanguageEnum), name));
                        _languageList.Add(value, name);
                    }
                }
                return _languageList;
            }
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            HttpContextBase context = requestContext.HttpContext;
            var cookieLanguage = context.Request.Cookies["language"];
            if (cookieLanguage == null)
            {
                cookieLanguage = new HttpCookie("language", ((int)Language).ToString());
                context.Request.Cookies.Set(cookieLanguage);
                context.Response.Cookies.Add(cookieLanguage);
            }
            else
            {
                Language = (LanguageEnum)int.Parse(cookieLanguage.Value);
            }

            //if (context.Session["language"] == null)
            //    context.Session["language"] = Language;

            if (context.Session["languageList"] == null)
                context.Session["languageList"] = LanguageList;

            if (context.Session["nav"] == null)
            {
                OhyMongoClient client = new OhyMongoClient();
                List<Nav> navs = client.Find<Nav>(new { Language = Language });
                navs.Sort();
                context.Session.Add("nav", navs);
            }
            else
            {
                var navs = (List<Nav>)context.Session["nav"];
                if (navs.Count == 0 || navs[0].Language != Language)
                {
                    OhyMongoClient client = new OhyMongoClient();
                    navs = client.Find<Nav>(new { Language = Language });
                    navs.Sort();
                    context.Session["nav"] = navs;
                }
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}