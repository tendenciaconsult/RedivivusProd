using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MultiplosBotoesAttribute : ActionNameSelectorAttribute
    {
        public string Variavel { get; set; }
        public string Valor { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var isValidName = false;
            var value = controllerContext.Controller.ValueProvider.GetValue(Variavel);

            if (value != null && value.AttemptedValue == Valor)
            {
                controllerContext.Controller.ControllerContext.RouteData.Values[Variavel] = Valor;
                isValidName = true;
            }

            return isValidName;
        }
    }
}