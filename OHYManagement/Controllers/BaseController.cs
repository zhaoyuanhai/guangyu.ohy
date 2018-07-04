using MongoDB.Bson;
using OHYModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OHYManagement.Controllers
{
    public class BaseController : Controller
    {
        public OHYDAL.OhyMongoClient client = new OHYDAL.OhyMongoClient();
        public LanguageEnum Language = LanguageEnum.中文;
        protected UM LoginUser
        {
            get
            {
                HttpCookie user = Request.Cookies.Get("User");
                if (user != null)
                {

                    ObjectId id = ObjectId.Parse(user.Value);
                    UM userlogin = client.FindOne<UM>(new {_id=id });
                    return userlogin;
                }
               else
                {
                    return null;
                }
            }
        }
        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {

            if (!string.IsNullOrWhiteSpace(requestContext.HttpContext.Request["language"]))
            {
                Language = (LanguageEnum)Enum.Parse(typeof(LanguageEnum), requestContext.HttpContext.Request["language"]);
            }
            requestContext.HttpContext.Session["Language"] = Language;
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}