using System;
using System.Linq;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.Domain;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;

namespace Simir.Application
{
    public class EnderecoApp : AppServiceBase<SimirContext>, IEnderecoApp
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoApp(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        public object[][] GetUfs()
        {
            return _enderecoService.GetUfs();
        }

        public object[][] GetMunicipiosByUf(int idUf)
        {
            return _enderecoService.GetMunicipiosByUf(idUf);
        }

        public object[][] GetBairrosByMunicipio(int idMunicipio)
        {
            var lista = _enderecoService.GetBairrosByMunicipio(idMunicipio).ToList();
            lista.Insert(0, new object[] {"0", " "});

            return lista.ToArray();
        }

        public EnderecoVM ConsultaCep(string cep)
        {
            var novoCep = EnderecoVM.ValidaCep(cep);
            var end = _enderecoService.ConsultaCep(novoCep);

            if (end == null)
            {
                throw new ArgumentOutOfRangeException("cep", MensagensErro.cepInexistente);
            }
            return EnderecoVM.ToView(_enderecoService.ConsultaCep(novoCep));
        }

        public object[][] GetLogradouroByBairro(int p)
        {
            var lista = _enderecoService.GetLogradouroByBairro(p).ToList();
            lista.Insert(0, new object[] {"0", " "});

            return lista.ToArray();
        }
    }
}