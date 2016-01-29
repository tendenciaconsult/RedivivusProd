using System;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class EquipamentoColetaEventualService : ServiceBase<TBEquipamentoColetaEventual>,
        IEquipamentoColetaEventualService
    {
        private readonly IEquipamentoColetaEventualRepository _EquipamentoColetaEventual;
        private readonly ILogEventoRepository _repositoryLog;

        public EquipamentoColetaEventualService(IEquipamentoColetaEventualRepository EquipamentoColetaEventual,
            ILogEventoRepository repositoryLog)
            : base(EquipamentoColetaEventual)
        {
            _EquipamentoColetaEventual = EquipamentoColetaEventual;
            _repositoryLog = repositoryLog;
        }

        public async Task<bool> AddEquipamentosAsync(AspNetUser user, TBEquipamentoColetaEventual LimpezaEventual)
        {
            var dt = DateTime.Now;

            await _EquipamentoColetaEventual.AddComHistoricoAsync(user.Id, dt, LimpezaEventual);

            return true;
        }

        public async Task<bool> RemoveEquipamentosByIDAsync(AspNetUser user, int EquipamentoID)
        {
            var dt = DateTime.Now;

            var Equipamentos = await _EquipamentoColetaEventual.GetByIdAsync(EquipamentoID);

            Equipamentos.bAtivo = false;

            _EquipamentoColetaEventual.Remove(Equipamentos);

            return true;
        }

        public async Task<TBEquipamentoColetaEventual> ReturnEquipamentoByID(int id)
        {
            return await _EquipamentoColetaEventual.FindFirtAsync(x => x.EquipamentoColetaEventualID == id);
        }

        public async Task<bool> UpdateEquipamentosAsync(AspNetUser user, TBEquipamentoColetaEventual Equipamentos)
        {
            var dt = DateTime.Now;

            _EquipamentoColetaEventual.UpdateHistorico(user.Id, dt, Equipamentos);

            return true;
        }
    }
}