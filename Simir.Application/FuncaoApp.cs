using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;

namespace Simir.Application
{
    public class FuncaoApp : AppServiceBase<SimirContext>, IFuncaoApp
    {
        private readonly IAspNetFuncaoService _simirFuncaoService;

        public FuncaoApp(
            IAspNetFuncaoService simirFuncaoService
            )
        {
            _simirFuncaoService = simirFuncaoService;
        }

        public ICollection<FuncaoVM> GetAllFuncao()
        {
            var funcoes = _simirFuncaoService.GetAll();

            var funcoesVM = new List<FuncaoVM>();
            foreach (var item in funcoes)
            {
                funcoesVM.Add(FuncaoVM.ToDomain(item));
            }

            return funcoesVM;
        }

        public FuncaoVM GetFuncaoByNome(string funcaoNome)
        {
            var funcao = _simirFuncaoService.GetFuncaoByNome(funcaoNome);
            if (funcao == null)
                return new FuncaoVM();
            return FuncaoVM.ToDomain(funcao);
        }

        public void UpdateFuncao(FuncaoVM model, int pefilId)
        {
            BeginTransaction();
            if (_simirFuncaoService.UpdateFuncao(model.TipoEmpresa, model.Nome, model.Descricao, model.MaxFuncionarios))
                Commit();
            if (_simirFuncaoService.AddFuncaoToPerfil(model.Nome, pefilId)) Commit();
        }

        public MultiSelectList GetAllFuncaoMS(int[] selecionados)
        {
            var perfis = _simirFuncaoService.GetAll().ToDictionary(k => k.AspNetFuncaoId, v => v.Nome);

            if (selecionados == null)
                return new MultiSelectList(perfis, "Key", "Value");
            return new MultiSelectList(perfis, "Key", "Value", selecionados);
        }
    }
}