﻿using Music.Web.Common;
using System.Web.Mvc;
using System.Web.Routing;

namespace Music.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Login", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}