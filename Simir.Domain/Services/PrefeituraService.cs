using System;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class PrefeituraService : ServiceBase<TBPrefeitura>, IPrefeituraService
    {
        private new readonly IPrefeituraRepository _repository;
        private readonly ILogEventoRepository _repositoryLog;

        public PrefeituraService(IPrefeituraRepository repository,
            ILogEventoRepository repositoryLog
            ) : base(repository)
        {
            _repositoryLog = repositoryLog;
            _repository = repository;
        }

        public bool EditarPrefeitura(AspNetUser user, TBPrefeitura prefeitura)
        {
            var valido = prefeitura.Validar();
            var dt = DateTime.Now;
            if (valido)
                _repository.UpdateHistorico(user.Id, dt, prefeitura);

            var log = TBLogEvento.Novo(user, dt, "Editou a Prefeitura");
            _repositoryLog.Add(log);

            return valido;
        }
    }
}