using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Simir.Application.Helpers
{
    public class MaximoValidator : ValidationAttribute, IClientValidatable
    {
        private readonly string _restoPropertyName;
        private readonly string _maxPropertyName;
        public MaximoValidator(string maxPropertyName, string restoPropertyName)
        {
            _restoPropertyName = restoPropertyName;
            _maxPropertyName = maxPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var restoProperty = validationContext.ObjectType.GetProperty(_restoPropertyName);
            var maxProperty = validationContext.ObjectType.GetProperty(_maxPropertyName);
            
            if (maxProperty == null)
            {
                return new ValidationResult(string.Format("Propriedade vazia {0}", _maxPropertyName));
            }

            double restoValue = 0;
            
            if (restoProperty != null)
            {
                restoValue = (double)restoProperty.GetValue(validationContext.ObjectInstance, null);
            }

            double maxValue = (double)maxProperty.GetValue(validationContext.ObjectInstance, null);
            double currentValue = (double)value;
            if (currentValue + restoValue  > maxValue)
            {
                return new ValidationResult(
                    string.Format(
                        ErrorMessage,
                        restoValue,
                        maxValue
                        )
                    );
            }

            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "maximo",
                ErrorMessage = this.ErrorMessage,
            };
            rule.ValidationParameters["restovalueproperty"] = _restoPropertyName;
            rule.ValidationParameters["maxvalueproperty"] = _maxPropertyName;
            yield return rule;
        }
    }
}