using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Simir.Domain.Helpers;

namespace Simir.Application.Helpers
{
    public class CustomValidationCNPJAttribute : ValidationAttribute, IClientValidatable
    {
        /// <summary>
        ///     Validação client
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = "CNPJ inválido", //this.FormatErrorMessage(null),
                ValidationType = "customvalidationcnpj"
            };
        }

        /// <summary>
        ///     Validação server
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return false;

            var valido = Help.CnpjValido(value.ToString());
            if (!valido) return valido;
            /*
            if (!ComDuplicidade)
            {
                var empresaApp = ServiceLocator.Current.GetInstance<IEmpresaApp>();
                var emp = empresaApp.GetEmpresaByCnpjAsync(value.ToString()).Result;
                if (emp != null)
                {
                    valido = false;
                }
            }
             */
            return valido;
        }
    }
}