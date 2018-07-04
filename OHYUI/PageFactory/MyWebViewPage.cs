using OHYModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OHYDAL;

namespace OHYUI.PageFactory
{
    public abstract class MyWebViewPage<T> : System.Web.Mvc.WebViewPage<T>
    {
        public List<Nav> Navs
        {
            get
            {
                return HttpContext.Current.Session["nav"] as List<Nav>;
            }
        }

        public LanguageEnum Language
        {
            get
            {
                return (LanguageEnum)Enum.Parse(typeof(LanguageEnum),
                    HttpContext.Current.Request.Cookies["language"].Value);
            }
        }

        public Dictionary<int, string> LanguageList
        {
            get
            {
                return HttpContext.Current.Session["languageList"] as Dictionary<int, string>;
            }
        }
    }

    public abstract class MyWebViewPage : System.Web.Mvc.WebViewPage
    {
        public List<Nav> Navs
        {
            get
            {
                return HttpContext.Current.Session["nav"] as List<Nav>;
            }
        }

        public LanguageEnum Language
        {
            get
            {
                return (LanguageEnum)HttpContext.Current.Session["language"];
            }
        }
    }
}