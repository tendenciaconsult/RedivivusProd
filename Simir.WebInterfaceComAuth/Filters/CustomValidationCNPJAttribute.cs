﻿using Simir.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Filters
{
    public class CustomValidationCNPJAttribute: ValidationAttribute, IClientValidatable
{
    /// <summary>
    /// Construtor
    /// </summary>
        public CustomValidationCNPJAttribute() { }

    /// <summary>
    /// Validação server
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public override bool IsValid(object value)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
        return true;

        bool valido = Help.CnpjValido(value.ToString());
        return valido;
    }

    /// <summary>
    /// Validação client
    /// </summary>
    /// <param name="metadata"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
        ModelMetadata metadata, ControllerContext context)
    {
        yield return new ModelClientValidationRule
        {
            ErrorMessage = this.FormatErrorMessage("CNPJ Inválido"),
            ValidationType = "customvalidationcnpj"
        };
    }
}
}