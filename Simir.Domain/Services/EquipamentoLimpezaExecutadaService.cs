using System;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class EquipamentoLimpezaExecutadaService : ServiceBase<TBEquipamentoLimpezaExecutada>,
        IEquipamentoLimpezaExecutadaService
    {
        private readonly IEquipamentoLimpezaExecutadaRepository _EquipamentoLimpezaExecutadaRepository;
        private readonly ILimpezaExecutadaRepository _LimpezaExecutadaRepository;
        private readonly ILogEventoRepository _repositoryLog;

        public EquipamentoLimpezaExecutadaService(
            IEquipamentoLimpezaExecutadaRepository EquipamentoLimpezaExecutadaRepository,
            ILogEventoRepository repositoryLog,
            ILimpezaExecutadaRepository LimpezaExecutadaRepository)
            : base(EquipamentoLimpezaExecutadaRepository)
        {
            _EquipamentoLimpezaExecutadaRepository = EquipamentoLimpezaExecutadaRepository;
            _repositoryLog = repositoryLog;
            _LimpezaExecutadaRepository = LimpezaExecutadaRepository;
        }

        public async Task<bool> AddEquipamentosAsync(AspNetUser user, TBEquipamentoLimpezaExecutada LimpezaExecutada)
        {
            var dt = DateTime.Now;

            await _EquipamentoLimpezaExecutadaRepository.AddComHistoricoAsync(user.Id, dt, LimpezaExecutada);

            return true;
        }

        public async Task<bool> RemoveEquipamentosByIDAsync(AspNetUser user, int EquipamentoID)
        {
            var dt = DateTime.Now;

            var Equipamentos = _EquipamentoLimpezaExecutadaRepository.GetById(EquipamentoID);

            Equipamentos.bAtivo = false;

            _EquipamentoLimpezaExecutadaRepository.UpdateHistorico(user.Id, dt, Equipamentos);

            return true;
        }

        public async Task<TBEquipamentoLimpezaExecutada> ReturnEquipamentoByID(int id)
        {
            return
                _EquipamentoLimpezaExecutadaRepository.Get(x => x.EquipamentoLimpezaExecutadaID == id).FirstOrDefault();
        }

        public async Task<bool> UpdateEquipamentosAsync(AspNetUser user, TBEquipamentoLimpezaExecutada Equipamentos)
        {
            var dt = DateTime.Now;

            _EquipamentoLimpezaExecutadaRepository.UpdateHistorico(user.Id, dt, Equipamentos);

            return true;
        }
    }
}