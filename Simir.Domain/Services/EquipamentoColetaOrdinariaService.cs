using System;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class EquipamentoColetaOrdinariaService : ServiceBase<TBEquipamentoColetaOrdinaria>,
        IEquipamentoColetaOrdinariaService
    {
        private readonly IEquipamentoColetaOrdinariaRepository _EquipamentoColetaOrdinaria;

        public EquipamentoColetaOrdinariaService(IEquipamentoColetaOrdinariaRepository EquipamentoColetaOrdinaria)
            : base(EquipamentoColetaOrdinaria)
        {
            _EquipamentoColetaOrdinaria = EquipamentoColetaOrdinaria;
        }

        public async Task<bool> AddEquipamentosAsync(AspNetUser user, TBEquipamentoColetaOrdinaria Equipamento)
        {
            var dt = DateTime.Now;

            await _EquipamentoColetaOrdinaria.AddComHistoricoAsync(user.Id, dt, Equipamento);

            return true;
        }

        public async Task<bool> RemoveEquipamentosByIDAsync(AspNetUser user, int EquipamentoID)
        {
            var dt = DateTime.Now;

            var Equipamentos = await _EquipamentoColetaOrdinaria.GetByIdAsync(EquipamentoID);

            Equipamentos.bAtivo = false;

            _EquipamentoColetaOrdinaria.UpdateHistorico(user.Id, dt, Equipamentos);

            return true;
        }

        public async Task<TBEquipamentoColetaOrdinaria> ReturnEquipamentoByID(int id)
        {
            return _EquipamentoColetaOrdinaria.Get(x => x.EquipamentoColetaOrdinariaID == id).FirstOrDefault();
        }

        public async Task<bool> UpdateEquipamentosAsync(AspNetUser user, TBEquipamentoColetaOrdinaria Equipamentos)
        {
            var dt = DateTime.Now;

            _EquipamentoColetaOrdinaria.UpdateHistorico(user.Id, dt, Equipamentos);

            return true;
        }
    }
}