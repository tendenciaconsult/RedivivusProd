using System;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class EquipamentoLimpezaEventualService : ServiceBase<TBEquipamentoLimpezaEventual>,
        IEquipamentoLimpezaEventualService
    {
        private readonly IEquipamentoLimpezaEventualRepository _repositoryEquipamentoLimpezaEventual;
        private readonly ILogEventoRepository _repositoryLog;

        public EquipamentoLimpezaEventualService(
            IEquipamentoLimpezaEventualRepository repositoryEquipamentoLimpezaEventual,
            ILogEventoRepository repositoryLog)
            : base(repositoryEquipamentoLimpezaEventual)
        {
            _repositoryEquipamentoLimpezaEventual = repositoryEquipamentoLimpezaEventual;
            _repositoryLog = repositoryLog;
        }

        public async Task<bool> AddEquipamentosAsync(AspNetUser user, TBEquipamentoLimpezaEventual LimpezaEventual)
        {
            var dt = DateTime.Now;

            await _repositoryEquipamentoLimpezaEventual.AddComHistoricoAsync(user.Id, dt, LimpezaEventual);

            return true;
        }

        public async Task<bool> RemoveEquipamentosByIDAsync(AspNetUser user, int EquipamentoID)
        {
            var dt = DateTime.Now;

            var Equipamentos = _repositoryEquipamentoLimpezaEventual.GetById(EquipamentoID);

            Equipamentos.bAtivo = false;

            _repositoryEquipamentoLimpezaEventual.UpdateHistorico(user.Id, dt, Equipamentos);

            return true;
        }

        public async Task<TBEquipamentoLimpezaEventual> ReturnEquipamentoByID(int id)
        {
            return _repositoryEquipamentoLimpezaEventual.Get(x => x.EquipamentoLimpezaEventualID == id).FirstOrDefault();
        }

        public async Task<bool> UpdateEquipamentosAsync(AspNetUser user, TBEquipamentoLimpezaEventual Equipamentos)
        {
            var dt = DateTime.Now;

            _repositoryEquipamentoLimpezaEventual.UpdateHistorico(user.Id, dt, Equipamentos);

            return true;
        }
    }
}