using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Simir.Application.Helpers
{
    public static class Geral
    {
        public static void AddExcepition(ModelStateDictionary ModelState, Exception ex)
        {
            if (ex is ArgumentException)
            {
                var argEx = (ArgumentException) ex;
                if (!ModelState.ContainsKey(argEx.ParamName)) ModelState.Add(argEx.ParamName, new ModelState());
                var lines = Regex.Split(ex.Message, "\r\n");
                ModelState[argEx.ParamName].Errors.Add(new ModelError(ex, lines[0]));
                return;
            }

            if (!ModelState.ContainsKey("")) ModelState.Add("", new ModelState());

            ModelState[""].Errors.Add(new ModelError(ex, ex.Message));
        }
    }
}