using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientManagementBusiness;

namespace PatientManagementUI.CustomAttributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        UserRoleBL context = new UserRoleBL(); // my entity  
        private readonly string[] allowedroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            foreach (var role in allowedroles)
            {
                var currrentRole = context.GetRoleForUser(httpContext.User.Identity.Name);
                if (role.Trim().ToLower() == currrentRole.Trim().ToLower())
                    authorize = true;                
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}