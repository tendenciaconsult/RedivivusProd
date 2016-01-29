using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class ColetaOrdinariaService : ServiceBase<TBColetaOrdinaria>, IColetaOrdinariaService
    {
        private readonly IColetaOrdinariaRepository _ColetaOrdinaria;
        private readonly ILogEventoRepository _repositoryLog;

        public ColetaOrdinariaService(IColetaOrdinariaRepository ColetaOrdinaria,
            ILogEventoRepository repositoryLog)
            : base(ColetaOrdinaria)
        {
            _ColetaOrdinaria = ColetaOrdinaria;
            _repositoryLog = repositoryLog;
        }

        public async Task<TBColetaOrdinaria> RetornaColetaOrdinariaByID(int id)
        {
            return await _ColetaOrdinaria.FindFirtAsync(x => x.ColetaOrdinariaID == id && x.bAtivo);
        }

        public List<TBColetaOrdinaria> GetAllProgramacaoByPrefeituraID(int PrefeituraID)
        {
            return _ColetaOrdinaria.Get
                (
                    x => x.PrefeituraID == PrefeituraID && x.bAtivo
                )
                .OrderBy(x => x.nmColetaOrdinaria).ToList();
        }

        public async Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBColetaOrdinaria ColetaOrdinaria)
        {
            var dt = DateTime.Now;

            _ColetaOrdinaria.AddHistorico(user.Id, dt, ColetaOrdinaria);
            //Add(Programação de Limpeza Ordinaria);

            var log = TBLogEvento.Novo(user, dt, "Adicionou uma nova Programação de Coleta Ordinaria");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBColetaOrdinaria ColetaOrdinaria)
        {
            var dt = DateTime.Now;

            _ColetaOrdinaria.UpdateHistorico(user.Id, dt, ColetaOrdinaria);


            var log = TBLogEvento.Novo(user, dt, "Editou uma Programação de Coleta Ordinária");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> ExcluirProgramacaoAsync(AspNetUser user, int idColeta)
        {
            var dt = DateTime.Now;

            var Coleta = _ColetaOrdinaria.GetById(idColeta);

            Coleta.bAtivo = false;

            _ColetaOrdinaria.UpdateHistorico(user.Id, dt, Coleta);


            var log = TBLogEvento.Novo(user, dt, "Desativou uma Programação de Coleta Ordinaria");
            _repositoryLog.Add(log);

            return true;
        }
    }
}