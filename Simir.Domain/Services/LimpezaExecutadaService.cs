using System;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class LimpezaExecutadaService : ServiceBase<TBLimpezaExecutada>, ILimpezaExecutadaService
    {
        private readonly ILimpezaExecutadaRepository _LimpezaExecutadaRepository;
        private readonly ILogEventoRepository _repositoryLog;

        public LimpezaExecutadaService(ILimpezaExecutadaRepository LimpezaExecutadaRepository,
            ILogEventoRepository repositoryLog)
            : base(LimpezaExecutadaRepository)
        {
            _LimpezaExecutadaRepository = LimpezaExecutadaRepository;
            _repositoryLog = repositoryLog;
        }

        public object[][] GetHasLimpezaEventualBYData(int prefeituraID, DateTime Data)
        {
            return _LimpezaExecutadaRepository.Get(x => x.TBLimpezaEventual.dtFim <= Data &&
                                                        x.TBLimpezaEventual.bAtivo == true)
                .Select(x => new object[] {x.nmLimpezaExecutada, x.TBLimpezaEventual.nmProgramacao})
                .ToArray();
        }

        public async Task<TBLimpezaExecutada> ReturnProgramacaoByID(int id)
        {
            return await _LimpezaExecutadaRepository.FindFirtAsync(x => x.LimpezaExecutadaID == id);
        }

        public async Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBLimpezaExecutada LimpezaExecutada)
        {
            var dt = DateTime.Now;

            await _LimpezaExecutadaRepository.AddComHistoricoAsync(user.Id, dt, LimpezaExecutada);

            var log = TBLogEvento.Novo(user, dt, "Executou a Programação " + LimpezaExecutada.nmLimpezaExecutada + ".");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBLimpezaExecutada LimpezaExecutada)
        {
            var dt = DateTime.Now;

            _LimpezaExecutadaRepository.UpdateHistorico(user.Id, dt, LimpezaExecutada);

            var log = TBLogEvento.Novo(user, dt,
                "Editou a execução da Programação " + LimpezaExecutada.nmLimpezaExecutada + ".");
            _repositoryLog.Add(log);

            return true;
        }
    }
}