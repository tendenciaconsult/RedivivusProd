using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class AterroService : ServiceBase<TBAterro>, IAterroService
    {
        private readonly IAterroRepository _Aterro;
        private readonly IEnderecoRepository _Endereco;
        private readonly ILogEventoRepository _repositoryLog;

        public AterroService(IAterroRepository Aterro,
            IEnderecoRepository Endereco,
            ILogEventoRepository repositoryLog)
            : base(Aterro)
        {
            _Aterro = Aterro;
            _Endereco = Endereco;
            _repositoryLog = repositoryLog;
        }
        public async Task<TBAterro> getAterroByID(int id)
        {
            return _Aterro.Get(x => x.AterroID == id && x.bAtivo).FirstOrDefault();
        }
        public List<TBAterro> GetAllProgramacaoByPrefeituraID(int PrefeituraID)
        {
            return _Aterro.Get
                (
                    x => x.PrefeituraID == PrefeituraID
                         && x.bAtivo
                )
                .OrderBy(x => x.nmFantasiaAterro).ToList();
        }
        public async Task<bool> AddNovoAterroAsync(AspNetUser user, TBAterro Aterro)
        {
            var dt = DateTime.Now;

            await _Aterro.AddComHistoricoAsync(user.Id, dt, Aterro);
            //Add(Programação de Limpeza Ordinaria);

            var log = TBLogEvento.Novo(user, dt, "Adicionou um novo aterro");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> UpdateAterroAsync(AspNetUser user, TBAterro Aterro)
        {
            var dt = DateTime.Now;

            _Aterro.UpdateHistorico(user.Id, dt, Aterro);


            var log = TBLogEvento.Novo(user, dt, "Alterou informações do aterro " + Aterro.nmFantasiaAterro);
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> ExcluirAterroAsync(AspNetUser user, int id)
        {
            var dt = DateTime.Now;

            var Retorno = _Aterro.GetById(id);

            Retorno.bAtivo = false;

            _Aterro.UpdateHistorico(user.Id, dt, Retorno);


            var log = TBLogEvento.Novo(user, dt, "Desativou um o aterro " + Retorno.nmFantasiaAterro);
            _repositoryLog.Add(log);

            return true;
        }
    }
}
