using System;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;


namespace Simir.Domain.Services
{
    public class RotasDescricaoService : ServiceBase<TBRotasDescricao>, IRotasDescricaoService
    {
        private readonly ILogEventoRepository _repositoryLog;
        private readonly IRotasDescricaoRepository _RotaDescricao;

        public RotasDescricaoService(IRotasDescricaoRepository RotaDescricao,
            ILogEventoRepository repositoryLog)
            : base(RotaDescricao)
        {
            _RotaDescricao = RotaDescricao;
            _repositoryLog = repositoryLog;
        }
        public async Task<bool> AddDadosAsync(AspNetUser user, TBRotasDescricao Dados)
        {
            var dt = DateTime.Now;

            await _RotaDescricao.AddComHistoricoAsync(user.Id, dt, Dados);

            return true;
        }

        public async Task<bool> RemoverDadosByIDAsync(AspNetUser user, int id)
        {
            var dt = DateTime.Now;

            var Retorno = _RotaDescricao.GetById(id);

            Retorno.bAtivo = false;

            _RotaDescricao.UpdateHistorico(user.Id, dt, Retorno);


            return true;
        }

        public async Task<TBRotasDescricao> ReturnDadosByID(int id)
        {
            return await _RotaDescricao.FindFirtAsync(x => x.RotasDescricaoID == id);
        }

        public async Task<bool> UpdateDadosAsync(AspNetUser user, TBRotasDescricao Dados)
        {
            var dt = DateTime.Now;

            _RotaDescricao.UpdateHistorico(user.Id, dt, Dados);

            return true;
        }
    }
}