using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Security;
using TwitterClone.Models;

namespace CustomAuthenticationMVC.CustomAuthentication
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected virtual UserModel CurrentUser
        {
            get { return HttpContext.Current.User as UserModel; }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return ((CurrentUser != null && !CurrentUser.IsInRole(Roles)) || CurrentUser == null) ? false : true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;

            if (CurrentUser == null)
            {
                routeData = new RedirectToRouteResult
                     (new System.Web.Routing.RouteValueDictionary
                      (new
                     {
                         controller = "Account",
                         action = "Login",
                     }
                     ));
            }
            else
            {
                routeData = new RedirectToRouteResult
             (new System.Web.Routing.RouteValueDictionary
               (new
               {
                   controller = "Error",
                   action = "AccessDenied"
               }
                ));
            }

            filterContext.Result = routeData;
        }
    }
}
