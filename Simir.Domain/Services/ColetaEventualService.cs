using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class ColetaEventualService : ServiceBase<TBColetaEventual>, IColetaEventualService
    {
        private readonly IColetaEventualRepository _ColetaEventual;
        private readonly ILogEventoRepository _repositoryLog;

        public ColetaEventualService(IColetaEventualRepository ColetaEventual,
            ILogEventoRepository repositoryLog)
            : base(ColetaEventual)
        {
            _ColetaEventual = ColetaEventual;
            _repositoryLog = repositoryLog;
        }

        public List<TBColetaEventual> BuscaProgramacaoByData(DateTime dtReferencia, int prefeituraID)
        {
            return _ColetaEventual.Get
                (
                    x => x.PrefeituraID == prefeituraID &&
                         x.dtColeta == dtReferencia && x.bAtivo &&
                         x.TBColetaExecutada == null
                )
                .OrderBy(x => x.nmColetaEventual).ToList();
        }

        public async Task<TBColetaEventual> RetornaColetaEventualByID(int id)
        {
            return _ColetaEventual.Get(x => x.ColetaEventualID == id && x.bAtivo).FirstOrDefault();
        }

        public List<TBColetaEventual> GetAllProgramacaoByPrefeituraID(int PrefeituraID)
        {
            return _ColetaEventual.Get
                (
                    x => x.PrefeituraID == PrefeituraID
                         && x.bAtivo &&
                         x.TBColetaExecutada == null
                )
                .OrderBy(x => x.nmColetaEventual).ToList();
        }

        public async Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBColetaEventual ColetaEventual)
        {
            var dt = DateTime.Now;

            _ColetaEventual.AddHistorico(user.Id, dt, ColetaEventual);
            //Add(Programação de Limpeza Ordinaria);

            var log = TBLogEvento.Novo(user, dt, "Adicionou uma nova Programação de Coleta Eventual");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBColetaEventual ColetaEventual)
        {
            var dt = DateTime.Now;

            _ColetaEventual.UpdateHistorico(user.Id, dt, ColetaEventual);


            var log = TBLogEvento.Novo(user, dt, "Editou uma Programação de Coleta Eventual");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> ExcluirProgramacaoAsync(AspNetUser user, int idColeta)
        {
            var dt = DateTime.Now;

            var Coleta = _ColetaEventual.GetById(idColeta);

            Coleta.bAtivo = false;

            _ColetaEventual.UpdateHistorico(user.Id, dt, Coleta);


            var log = TBLogEvento.Novo(user, dt, "Desativou uma Programação de Coleta Eventual");
            _repositoryLog.Add(log);

            return true;
        }

        public List<TBColetaEventual> CarregaGrigColetaEventual(int idPrestadora, int RotaID, DateTime dtInicio,
            DateTime dtFim, bool bOrdinaria, bool bEventual)
        {
            var aux = 0;
            if (bOrdinaria && (bEventual == false))
            {
                bOrdinaria = true;
                aux = 1;
            }
            if ((bOrdinaria == false) && bEventual)
            {
                bOrdinaria = false;
                aux = 1;
            }
            return _ColetaEventual.Get
                (
                    x => x.bAtivo &&
                         ((idPrestadora == 0) || x.PrestadoraServicosID == idPrestadora) &&
                         ((RotaID == 0) || x.RotasID == RotaID) &&
                         ((aux == 0) || x.bColetaOrdinaria == bOrdinaria) &&
                         x.dtColeta >= dtInicio &&
                         x.dtColeta <= dtFim
                )
                .OrderBy(x => x.dtColeta).ToList();
        }

        public List<TBColetaEventual> CarregaGridColetaEventualRealizada(int idPrestadora, int RotaID, DateTime dtInicio,
            DateTime dtFim, bool bOrdinaria, bool bEventual)
        {
            var aux = 0;
            if (bOrdinaria && (bEventual == false))
            {
                bOrdinaria = true;
                aux = 1;
            }
            if ((bOrdinaria == false) && bEventual)
            {
                bOrdinaria = false;
                aux = 1;
            }
            return _ColetaEventual.Get
                (
                    x => x.bAtivo &&
                         ((idPrestadora == 0) || x.PrestadoraServicosID == idPrestadora) &&
                         ((RotaID == 0) || x.RotasID == RotaID) &&
                         ((aux == 0) || x.bColetaOrdinaria == bOrdinaria) &&
                         x.dtColeta >= dtInicio &&
                         x.dtColeta <= dtFim &&
                         x.TBColetaExecutada.bColetaRealizada
                )
                .OrderBy(x => x.dtColeta).ToList();
        }

        public List<TBColetaEventual> CarregaGridColetaEventualNaoRealizada(int idPrestadora, int RotaID,
            DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual)
        {
            var aux = 0;
            if (bOrdinaria && (bEventual == false))
            {
                bOrdinaria = true;
                aux = 1;
            }
            if ((bOrdinaria == false) && bEventual)
            {
                bOrdinaria = false;
                aux = 1;
            }
            return _ColetaEventual.Get
                (
                    x => x.bAtivo &&
                         ((idPrestadora == 0) || x.PrestadoraServicosID == idPrestadora) &&
                         ((RotaID == 0) || x.RotasID == RotaID) &&
                         ((aux == 0) || x.bColetaOrdinaria == bOrdinaria) &&
                         x.dtColeta >= dtInicio &&
                         x.dtColeta <= dtFim &&
                         x.TBColetaExecutada.bColetaRealizada == false
                )
                .OrderBy(x => x.dtColeta).ToList();
        }

        public List<TBColetaEventual> CarregaGridColetaEventualPendente(int idPrestadora, int RotaID, DateTime dtInicio,
            DateTime dtFim, bool bOrdinaria, bool bEventual)
        {
            var aux = 0;
            if (bOrdinaria && (bEventual == false))
            {
                bOrdinaria = true;
                aux = 1;
            }
            if ((bOrdinaria == false) && bEventual)
            {
                bOrdinaria = false;
                aux = 1;
            }
            var dtRef = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            return _ColetaEventual.Get
                (
                    x => x.bAtivo &&
                         ((idPrestadora == 0) || x.PrestadoraServicosID == idPrestadora) &&
                         ((RotaID == 0) || x.RotasID == RotaID) &&
                         ((aux == 0) || x.bColetaOrdinaria == bOrdinaria) &&
                         x.dtColeta < dtRef &&
                         (x.TBColetaExecutada == null)
                )
                .OrderBy(x => x.dtColeta).ToList();
        }
    }
}