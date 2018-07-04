using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OHYManagement.Filter
{
    public class LonginFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies.Get("User");
            if(user==null)
            {
                filterContext.Result = new RedirectResult("/Login/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}