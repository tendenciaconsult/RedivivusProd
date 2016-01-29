using System.Collections.Generic;
using Simir.Domain.Entities;
using Simir.Domain.Enuns;

namespace Simir.Application.ViewModels
{
    public class FuncaoVM
    {
        public FuncaoVM()
        {
            FuncaoId = 0;
            Nome = "";
            Descricao = "";
            MaxFuncionarios = 1;
            Perfil = new PerfilVM();
        }

        public int FuncaoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoEmpresa TipoEmpresa { get; set; }
        public int MaxFuncionarios { get; set; }
        public virtual PerfilVM Perfil { get; set; }

        internal static FuncaoVM ToDomain(AspNetFuncao item)
        {
            return new FuncaoVM
            {
                FuncaoId = item.AspNetFuncaoId,
                Nome = item.Nome,
                Descricao = item.Descricao,
                TipoEmpresa = item.TipoEmpresa,
                MaxFuncionarios = item.MaxFuncionarios,
                Perfil = PerfilVM.ToDomain(item.Perfil)
            };
        }

        internal static ICollection<FuncaoVM> ToDomain(ICollection<AspNetFuncao> collection)
        {
            var funcao = new List<FuncaoVM>();
            if (collection == null) return funcao;
            foreach (var item in collection)
            {
                funcao.Add(ToDomain(item));
            }
            return funcao;
        }
    }
}