using System;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class ColetaExecutadaDetalhadaService : ServiceBase<TBColetaExecutadaDetalhada>,
        IColetaExecutadaDetalhadaService
    {
        private readonly IColetaExecutadaDetalhadaRepository _ColetaExecutadaDetalhada;
        private readonly ILogEventoRepository _repositoryLog;

        public ColetaExecutadaDetalhadaService(IColetaExecutadaDetalhadaRepository ColetaExecutadaDetalhada,
            ILogEventoRepository repositoryLog)
            : base(ColetaExecutadaDetalhada)
        {
            _ColetaExecutadaDetalhada = ColetaExecutadaDetalhada;
            _repositoryLog = repositoryLog;
        }

        public async Task<bool> AddDadossAsync(AspNetUser user, TBColetaExecutadaDetalhada Equipamento)
        {
            var dt = DateTime.Now;

            await _ColetaExecutadaDetalhada.AddComHistoricoAsync(user.Id, dt, Equipamento);

            return true;
        }

        public async Task<bool> RemoveDadosByIDAsync(AspNetUser user, int EquipamentoID)
        {
            var dt = DateTime.Now;

            var Dados = _ColetaExecutadaDetalhada.GetById(EquipamentoID);

            Dados.bAtivo = false;

            _ColetaExecutadaDetalhada.UpdateHistorico(user.Id, dt, Dados);

            return true;
        }

        public async Task<TBColetaExecutadaDetalhada> ReturnDadosByID(int id)
        {
            return _ColetaExecutadaDetalhada.Get(x => x.ColetaExecutadaDetalhadaID == id).FirstOrDefault();
        }

        public async Task<bool> UpdateDadosAsync(AspNetUser user, TBColetaExecutadaDetalhada Equipamentos)
        {
            var dt = DateTime.Now;

            _ColetaExecutadaDetalhada.UpdateHistorico(user.Id, dt, Equipamentos);

            return true;
        }
    }
}