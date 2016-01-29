using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;

namespace Simir.Application
{
    public class PrefeituraApp : AppServiceBase<SimirContext>, IPrefeituraApp
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IPrefeituraService _prefeituraService;

        public PrefeituraApp(
            IEnderecoService enderecoService,
            IPrefeituraService prefeituraService
            )
        {
            _prefeituraService = prefeituraService;
            _enderecoService = enderecoService;
        }

        public PrefeituraEditarVM GetEmpresa(int prefeituraID)
        {
            var prefeitura = _prefeituraService.GetById(prefeituraID);

            return PrefeituraEditarVM.ToView(prefeitura);
        }

        public PrefeituraVM GetEmpresaBasico(int prefeituraID)
        {
            var prefeitura = _prefeituraService.GetById(prefeituraID);

            return PrefeituraVM.ToView(prefeitura);
        }

        public async Task<IDictionary<string, ModelState>> Salvar(AspNetUser user, PrefeituraEditarVM model)
        {
            var resultado = new Dictionary<string, ModelState>();


            var prefeitura = user.TBUsuario.TBPrefeitura;
            var endereco = prefeitura.TBEndereco;

            prefeitura.CNPJ = model.CNPJ;
            prefeitura.nmPrefeito = model.Prefeito;
            prefeitura.nmPrefeitura = model.Nome;
            prefeitura.Site = model.Site;
            prefeitura.qtHabitantesUrbanos = (int)model.qtHabitantesUrbanos;
            prefeitura.qthabitantesTotalAtendido = (int)model.qthabitantesTotalAtendido;
            prefeitura.qthabitantesAtendidoColetaDomiciliar = (int)model.qthabitantesAtendidoColetaDomiciliar;
            prefeitura.qthabitantesAtendidoColetaSeletiva = (int)model.qthabitantesAtendidoColetaSeletiva;

            prefeitura.TBEndereco = EnderecoVM.ToModel(model.Endereco);
            prefeitura.TBEndereco.EnderecoID = endereco.EnderecoID;

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = _enderecoService.ValidaEndereco(endereco);
                if (tudoCerto)
                    tudoCerto = _prefeituraService.EditarPrefeitura(user, prefeitura);
                if (tudoCerto) await CommitAsync();
            }
            catch (ArgumentException ex)
            {
                if (!resultado.ContainsKey(ex.ParamName)) resultado.Add(ex.ParamName, new ModelState());
                var lines = Regex.Split(ex.Message, "\r\n");
                resultado[ex.ParamName].Errors.Add(lines[0]);
            }
            catch (Exception ex)
            {
                if (!resultado.ContainsKey("")) resultado.Add("", new ModelState());
                resultado[""].Errors.Add(ex);
            }
            return resultado;
        }
    }
}