using System;
using System.Collections.Generic;
using System.Linq;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;

namespace Simir.Application
{
    public class LimpezaConsultaApp : AppServiceBase<SimirContext>, ILimpezaConsultaApp
    {
        private readonly ILimpezaEventualService _ILimpezaEventualService;

        public LimpezaConsultaApp(ILimpezaEventualService ILimpezaEventualService)
        {
            _ILimpezaEventualService = ILimpezaEventualService;
        }

        public List<ConsultasLimpezaEventualVM> CarregaGridLimpezaEventual(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao, bool Editavel)
        {
            List<ConsultasLimpezaEventualVM> retorno;

            retorno = new List<ConsultasLimpezaEventualVM>();

            retorno = _ILimpezaEventualService.CarregaGridLimpezaEventual(idRegiaoAdministrativa, idPrestadora,
                idLogradouro, idBairro, dtInicio, dtFim, bOrdinaria, bEventual, TipoProgramacao)
                .Select(x => new ConsultasLimpezaEventualVM(x, Editavel)).ToList();

            return retorno;
        }

        public List<ConsultasLimpezaEventualNaoRealizadaVM> CarregaGridLimpezaEventualNaoExecutado(
            int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao, bool Editavel)
        {
            List<ConsultasLimpezaEventualNaoRealizadaVM> retorno;

            retorno = new List<ConsultasLimpezaEventualNaoRealizadaVM>();

            retorno =
                _ILimpezaEventualService.CarregaGridLimpezaEventualNaoExecutado(idRegiaoAdministrativa, idPrestadora,
                    idLogradouro, idBairro, dtInicio, dtFim, bOrdinaria, bEventual, TipoProgramacao)
                    .Select(x => new ConsultasLimpezaEventualNaoRealizadaVM(x, Editavel)).ToList();

            return retorno;
        }

        public List<ConsultasLimpezaEventualPendenteVM> CarregaGridLimpezaEventualPendente(int idRegiaoAdministrativa,
            int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao, bool Editavel)
        {
            List<ConsultasLimpezaEventualPendenteVM> retorno;

            retorno = new List<ConsultasLimpezaEventualPendenteVM>();

            retorno = _ILimpezaEventualService.CarregaGridLimpezaEventualPendente(idRegiaoAdministrativa, idPrestadora,
                idLogradouro, idBairro, dtInicio, dtFim, bOrdinaria, bEventual, TipoProgramacao)
                .Select(x => new ConsultasLimpezaEventualPendenteVM(x, Editavel)).ToList();

            return retorno;
        }

        public List<ConsultasLimpezaEventualRealizadaVM> CarregaGridLimpezaEventualExecutado(int idRegiaoAdministrativa,
            int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao, bool Editavel)
        {
            List<ConsultasLimpezaEventualRealizadaVM> retorno;

            retorno = new List<ConsultasLimpezaEventualRealizadaVM>();

            retorno = _ILimpezaEventualService.CarregaGridLimpezaEventualExecutado(idRegiaoAdministrativa, idPrestadora,
                idLogradouro, idBairro, dtInicio, dtFim, bOrdinaria, bEventual, TipoProgramacao)
                .Select(x => new ConsultasLimpezaEventualRealizadaVM(x, Editavel)).ToList();

            return retorno;
        }

        public object[][] RetornaTipoConsulta()
        {
            var lista = new[]
            {
                new object[] {"0", "Todas as Programações"},
                new object[] {"1", "Programações Executadas"},
                new object[] {"2", "Programações Não Executadas"},
                new object[] {"3", "Programações Pendentes"}
            };

            return lista.ToArray();
        }

        public List<ConsultasLimpezaOrdinariaVM> CarregaGridLimpezaOrdinaria(int idRegiaoAdministrativa,
            int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim)
        {
            List<ConsultasLimpezaOrdinariaVM> retorno;

            retorno = new List<ConsultasLimpezaOrdinariaVM>();

            retorno = _ILimpezaEventualService.CarregaGridLimpezaOrdinaria(idRegiaoAdministrativa, idPrestadora,
                idLogradouro, idBairro, dtInicio, dtFim)
                .Select(x => new ConsultasLimpezaOrdinariaVM(x)).ToList();

            return retorno;
        }

        public List<ConsultasLimpezaOrdinariaNaoRealizadaVM> CarregaGridLimpezaOrdinariaNaoExecutado(
            int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim)
        {
            List<ConsultasLimpezaOrdinariaNaoRealizadaVM> retorno;

            retorno = new List<ConsultasLimpezaOrdinariaNaoRealizadaVM>();

            retorno =
                _ILimpezaEventualService.CarregaGridLimpezaOrdinariaNaoExecutado(idRegiaoAdministrativa, idPrestadora,
                    idLogradouro, idBairro, dtInicio, dtFim)
                    .Select(x => new ConsultasLimpezaOrdinariaNaoRealizadaVM(x)).ToList();

            return retorno;
        }

        public List<ConsultasLimpezaOrdinariaRealizadaVM> CarregaGridLimpezaOrdinariaExecutado(
            int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim)
        {
            List<ConsultasLimpezaOrdinariaRealizadaVM> retorno;

            retorno = new List<ConsultasLimpezaOrdinariaRealizadaVM>();

            retorno =
                _ILimpezaEventualService.CarregaGridLimpezaOrdinariaExecutado(idRegiaoAdministrativa, idPrestadora,
                    idLogradouro, idBairro, dtInicio, dtFim)
                    .Select(x => new ConsultasLimpezaOrdinariaRealizadaVM(x)).ToList();

            return retorno;
        }
    }
}