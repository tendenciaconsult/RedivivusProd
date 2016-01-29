using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Domain.Services
{
    public class ContratoService : ServiceBase<TBContrato>, IContratoService
    {
        private new readonly IContratoRepository _repository;
        private readonly ILogEventoRepository _repositoryLog;

        public ContratoService(IContratoRepository repository,
            ILogEventoRepository repositoryLog
            ) : base(repository)
        {
            _repositoryLog = repositoryLog;
            _repository = repository;
        }


        public TBContrato GetById2(int id)
        {
            return _repository.Get(x=>x.ContratoID == id,includeProperties: "Servicos,Funcoes,Equipamentos,Veiculos").FirstOrDefault();
        }

        public async Task<bool> AddAsync(AspNetUser user, TBContrato contrato)
        {
            const bool valido = true;
            var dt = DateTime.Now;
            contrato.bAtivo = true;
            await _repository.AddComHistoricoAsync(user.Id, dt, contrato);
            //_repository.AddHistorico(user.Id, dt, contrato);
            
            var log = TBLogEvento.Novo(user, dt, "Adicionou um Contrato");
            _repositoryLog.Add(log);

            return valido;
        }

        public async Task<bool> UpdateAsync(AspNetUser user, TBContrato contrato)
        {
            const bool valido = true;
            var dt = DateTime.Now;

            _repository.UpdateHistorico(user.Id, dt, contrato);

            var log = TBLogEvento.Novo(user, dt, "Atualizou um Contrato");
            _repositoryLog.Add(log);

            return valido;
        }
    }
}
