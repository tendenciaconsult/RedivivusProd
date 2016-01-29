using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Simir.Domain.Enuns;

namespace Simir.WebInterfaceComAuth.Helpers
{
    public static class ClaimExtensions
    {
        public static int GetPrefeituraID(this IIdentity value)
        {
            var preId = ((ClaimsIdentity)value).FindFirst("AspNet.Identity.Prefeitura");

            return Int32.Parse(preId.Value);
        }


        public static TipoPermissao GetPermicao(this IIdentity value)
        {
            var permi = ((ClaimsIdentity)value).FindFirst("AspNet.Identity.Permissao");

            return (TipoPermissao)Int32.Parse(permi.Value);
        }


        public static bool TemPermicao(this IIdentity value, TipoPermissao tipoPermissao)
        {
            var permi = GetPermicao(value);


            return (permi & tipoPermissao) == tipoPermissao;
        }

        public static string GetNome(this IIdentity value)
        {
            var nome = ((ClaimsIdentity)value).FindFirst("AspNet.Identity.Nome");
            return nome.Value;
        }

    }
}