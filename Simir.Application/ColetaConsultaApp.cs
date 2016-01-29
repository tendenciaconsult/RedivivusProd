using System;
using System.Collections.Generic;
using System.Linq;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;

namespace Simir.Application
{
    public class ColetaConsultaApp : AppServiceBase<SimirContext>, IColetaConsultaApp
    {
        private readonly IColetaEventualService _ColetaEventual;

        public ColetaConsultaApp(IColetaEventualService ColetaEventual)
        {
            _ColetaEventual = ColetaEventual;
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

        public List<ConsultasColetaEventualVM> CarregaGrigColetaEventual(int idPrestadora, int RotaID, DateTime dtInicio,
            DateTime dtFim, bool bOrdinaria, bool bEventual)
        {
            List<ConsultasColetaEventualVM> retorno;

            retorno = new List<ConsultasColetaEventualVM>();

            retorno =
                _ColetaEventual.CarregaGrigColetaEventual(idPrestadora, RotaID, dtInicio, dtFim, bOrdinaria, bEventual)
                    .Select(x => new ConsultasColetaEventualVM(x)).ToList();

            return retorno;
        }

        public List<ConsultasColetaEventualRealizadaVM> CarregaGridColetaEventualRealizada(int idPrestadora, int RotaID,
            DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual, bool Editavel)
        {
            List<ConsultasColetaEventualRealizadaVM> retorno;

            retorno = new List<ConsultasColetaEventualRealizadaVM>();

            retorno =
                _ColetaEventual.CarregaGridColetaEventualRealizada(idPrestadora, RotaID, dtInicio, dtFim, bOrdinaria,
                    bEventual)
                    .Select(x => new ConsultasColetaEventualRealizadaVM(x, Editavel)).ToList();

            return retorno;
        }

        public List<ConsultasColetaEventualNaoRealizadaVM> CarregaGridColetaEventualNaoRealizada(int idPrestadora,
            int RotaID, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual, bool Editavel)
        {
            List<ConsultasColetaEventualNaoRealizadaVM> retorno;

            retorno = new List<ConsultasColetaEventualNaoRealizadaVM>();

            retorno =
                _ColetaEventual.CarregaGridColetaEventualNaoRealizada(idPrestadora, RotaID, dtInicio, dtFim, bOrdinaria,
                    bEventual)
                    .Select(x => new ConsultasColetaEventualNaoRealizadaVM(x, Editavel)).ToList();

            return retorno;
        }

        public List<ConsultasColetaEventualPendenteVM> CarregaGridColetaEventualPendente(int idPrestadora, int RotaID,
            DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual, bool Editavel)
        {
            List<ConsultasColetaEventualPendenteVM> retorno;

            retorno = new List<ConsultasColetaEventualPendenteVM>();

            retorno =
                _ColetaEventual.CarregaGridColetaEventualPendente(idPrestadora, RotaID, dtInicio, dtFim, bOrdinaria,
                    bEventual)
                    .Select(x => new ConsultasColetaEventualPendenteVM(x, Editavel)).ToList();

            return retorno;
        }
    }
}