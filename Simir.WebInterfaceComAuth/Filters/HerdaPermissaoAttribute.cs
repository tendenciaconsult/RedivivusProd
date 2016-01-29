using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class HerdaPermissaoAttribute : ActionNameSelectorAttribute
    {

        public string Action { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var isValidName = false;


            if (methodInfo.Name == actionName)
            {
                if (string.IsNullOrWhiteSpace(Action))
                    return true;

                var value = controllerContext.HttpContext.Request.Url.AbsolutePath.TrimStart('/').TrimEnd('/');
                var valueAction = value.Split('/');
                valueAction[valueAction.Length - 1] = Action;
                var final = string.Join("/", valueAction);

                var identity = (ClaimsIdentity)controllerContext.HttpContext.User.Identity;

                identity.AddClaim(new Claim("Invi.din", final));

                return true;
            }

            return false;
        }
    }
}