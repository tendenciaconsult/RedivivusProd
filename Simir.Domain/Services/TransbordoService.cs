using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class TransbordoService : ServiceBase<TBTransbordo>, ITransbordoService
    {
        private readonly ITransbordoRepository _Transbordo;
        private readonly IEnderecoRepository _Endereco;
        private readonly ILogEventoRepository _repositoryLog;

        public TransbordoService(ITransbordoRepository Transbordo,
            IEnderecoRepository Endereco,
            ILogEventoRepository repositoryLog)
            : base(Transbordo)
        {
            _Transbordo = Transbordo;
            _Endereco = Endereco;
            _repositoryLog = repositoryLog;
        }
        public async Task<TBTransbordo> getTransbordoByID(int id)
        {
            return _Transbordo.Get(x => x.TransbordoID == id && x.bAtivo).FirstOrDefault();
        }
        public List<TBTransbordo> GetAllProgramacaoByPrefeituraID(int PrefeituraID)
        {
            return _Transbordo.Get
                (
                    x => x.PrefeituraID == PrefeituraID
                         && x.bAtivo
                )
                .OrderBy(x => x.nmFantasiaTransbordo).ToList();
        }
        public async Task<bool> AddNovoTransbordoAsync(AspNetUser user, TBTransbordo Transbordo)
        {
            var dt = DateTime.Now;

            _Transbordo.AddHistorico(user.Id, dt, Transbordo);
            //Add(Programação de Limpeza Ordinaria);

            var log = TBLogEvento.Novo(user, dt, "Adicionou um novo Transbordo");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> UpdateTransbordoAsync(AspNetUser user, TBTransbordo Transbordo)
        {
            var dt = DateTime.Now;

            _Transbordo.UpdateHistorico(user.Id, dt, Transbordo);


            var log = TBLogEvento.Novo(user, dt, "Alterou informações do aterro " + Transbordo.nmFantasiaTransbordo);
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> ExcluirTransbordoAsync(AspNetUser user, int id)
        {
            var dt = DateTime.Now;

            var Retorno = _Transbordo.GetById(id);

            Retorno.bAtivo = false;

            _Transbordo.UpdateHistorico(user.Id, dt, Retorno);


            var log = TBLogEvento.Novo(user, dt, "Desativou um o aterro " + Retorno.nmFantasiaTransbordo);
            _repositoryLog.Add(log);

            return true;
        }
    }
}
