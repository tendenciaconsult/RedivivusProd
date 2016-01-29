using System;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class EnderecosColetaEventualService : ServiceBase<TBEnderecosColetaEventual>,
        IEnderecosColetaEventualService
    {
        private readonly IEnderecosColetaEventualRepository _EnderecosColetaEventual;
        private readonly ILogEventoRepository _repositoryLog;

        public EnderecosColetaEventualService(IEnderecosColetaEventualRepository EnderecosColetaEventual,
            ILogEventoRepository repositoryLog)
            : base(EnderecosColetaEventual)
        {
            _EnderecosColetaEventual = EnderecosColetaEventual;
            _repositoryLog = repositoryLog;
        }

        public async Task<bool> AddEnderecosAsync(AspNetUser user, TBEnderecosColetaEventual LimpezaEventual)
        {
            var dt = DateTime.Now;

            await _EnderecosColetaEventual.AddComHistoricoAsync(user.Id, dt, LimpezaEventual);

            return true;
        }

        public async Task<bool> RemoveEnderecosByIDAsync(AspNetUser user, int EnderecosID)
        {
            var dt = DateTime.Now;

            var Enderecos = await _EnderecosColetaEventual.GetByIdAsync(EnderecosID);

            Enderecos.bAtivo = false;

            _EnderecosColetaEventual.Remove(Enderecos);

            return true;
        }

        public async Task<TBEnderecosColetaEventual> ReturnEnderecosByID(int id)
        {
            return await _EnderecosColetaEventual.FindFirtAsync(x => x.EnderecosColetaEventualID == id);
        }

        public bool UpdateEnderecos(AspNetUser user, TBEnderecosColetaEventual Equipamentos)
        {
            var dt = DateTime.Now;

            _EnderecosColetaEventual.UpdateHistorico(user.Id, dt, Equipamentos);

            return true;
        }
    }
}