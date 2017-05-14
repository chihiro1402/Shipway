using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shipway.Authorize
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    [System.Runtime.InteropServices.ComVisible(false)]
    public class ShipwayAuthorize : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            if (System.Web.HttpContext.Current.Session["CurrentUser"] == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
            }
        }
    }
}