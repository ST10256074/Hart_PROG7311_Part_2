
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web;


public class SessionAuthorizeAttribute : ActionFilterAttribute
{
    public string SessionKey { get; set; }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (filterContext.HttpContext.Session.Keys.Count() == 0)
        {
            filterContext.Result = new RedirectResult("~/Home/Login");
            return;
        }
        base.OnActionExecuting(filterContext);
    }
}
