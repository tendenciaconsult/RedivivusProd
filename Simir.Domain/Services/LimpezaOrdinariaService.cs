using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class LimpezaOrdinariaService : ServiceBase<TBLimpezaOrdinaria>, ILimpezaOrdinariaService
    {
        private readonly ILimpezaOrdinariaRepository _repositoryLimpezaOrdinaira;
        private readonly ILogEventoRepository _repositoryLog;

        public LimpezaOrdinariaService(ILimpezaOrdinariaRepository repositoryLimpezaOrdinaira,
            ILogEventoRepository repositoryLog)
            : base(repositoryLimpezaOrdinaira)
        {
            _repositoryLimpezaOrdinaira = repositoryLimpezaOrdinaira;
            _repositoryLog = repositoryLog;
        }

        public async Task<TBLimpezaOrdinaria> ReturnProgramacaoByID(int id)
        {
            return await _repositoryLimpezaOrdinaira.FindFirtAsync(x => x.bAtivo && x.LimpezaOrdinariaID == id);
        }

        //public object[][] RetornRegiaoAdministrativaBYPrefeitura(int prefeituraID)
        //{
        //    return _repositoryLimpezaOrdinaira.Get(x => x.bAtivo && x.PrefeituraID == prefeituraID).Select(x => new object[] { x.RegiaoAdministrativaID, x.TBRegiaoAdministrativa.nmRegiaoAdministrativa }).ToArray();
        //}
        public object[][] ReturnPrestadoraServicosByPrefeitura(int prefeituraID)
        {
            return
                _repositoryLimpezaOrdinaira.Get(x => x.bAtivo && x.PrefeituraID == prefeituraID)
                    .Select(
                        x => new object[] {x.RegiaoAdministrativaID, x.TBRegiaoAdministrativa.nmRegiaoAdministrativa})
                    .ToArray();
        }

        public List<TBLimpezaOrdinaria> GetAllProgramacaoLimpezaOrdinariaByPrefeitura(int PrefeituraID)
        {
            return
                _repositoryLimpezaOrdinaira.Get(x => x.bAtivo && x.PrefeituraID == PrefeituraID)
                    .OrderBy(x => x.TBRegiaoAdministrativa.nmRegiaoAdministrativa)
                    .ToList();
        }

        public async Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBLimpezaOrdinaria LimpezaOrdinaria)
        {
            var dt = DateTime.Now;

            _repositoryLimpezaOrdinaira.AddHistorico(user.Id, dt, LimpezaOrdinaria);
            //Add(Programação de Limpeza Ordinaria);

            var log = TBLogEvento.Novo(user, dt, "Adicionou uma nova Programação de Limpeza Ordinaria");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBLimpezaOrdinaria LimpezaOrdinaria)
        {
            var dt = DateTime.Now;

            _repositoryLimpezaOrdinaira.UpdateHistorico(user.Id, dt, LimpezaOrdinaria);


            var log = TBLogEvento.Novo(user, dt, "Editou uma Programação de Limpeza Ordinaria");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> ExcluirProgramacaoAsync(AspNetUser user, int LimpezaOrdinariaID)
        {
            var dt = DateTime.Now;

            var LimpezaOrdinaria = _repositoryLimpezaOrdinaira.GetById(LimpezaOrdinariaID);

            LimpezaOrdinaria.bAtivo = false;

            _repositoryLimpezaOrdinaira.UpdateHistorico(user.Id, dt, LimpezaOrdinaria);


            var log = TBLogEvento.Novo(user, dt, "Desativou uma Programação de Limpeza Ordinaria");
            _repositoryLog.Add(log);

            return true;
        }
    }
}