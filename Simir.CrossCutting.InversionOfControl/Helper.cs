using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Simir.CrossCutting.InversionOfControl
{
    internal static class Helper
    {
        /// <summary>
        ///     implementação dinâmica das classes que seguem a arquitetura DDD
        ///     ideal para as classes que não não tem nenhuma especificação
        ///     exemplode uso: DynamicImplementation(
        ///     typeof(RepositoryBase<>).MakeGenericType(typeof(LocalidadeUf)),
        ///     typeof(ILocalidadeUfRepository)
        ///     )
        /// </summary>
        /// <param name="baseType"> a classe base </param>
        /// <param name="repositoryInteface"> inteface </param>
        /// <returns></returns>
        public static Type DynamicImplementation(Type baseType, Type repositoryInteface)
        {
            var asmName = new AssemblyName(
                string.Format("{0}_{1}", "tmpAsm", Guid.NewGuid().ToString("N"))
                );

            // create in memory assembly only
            var asmBuilder =
                AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Run);

            var moduleBuilder =
                asmBuilder.DefineDynamicModule("core");

            var proxyTypeName = string.Format("{0}_{1}", repositoryInteface.Name, Guid.NewGuid().ToString("N"));

            var typeBuilder =
                moduleBuilder.DefineType(proxyTypeName);

            typeBuilder.AddInterfaceImplementation(repositoryInteface);
            typeBuilder.SetParent(baseType);

            return typeBuilder.CreateType();
        }
    }
}