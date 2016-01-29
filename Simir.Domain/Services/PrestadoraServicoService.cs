using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class PrestadoraServicoService : ServiceBase<TBPrestadoraServico>, IPrestadoraServicoService
    {
        private readonly IPrestadoraServicoEquipamentoRepository _equipamentosRepository;
        private new readonly IPrestadoraServicoRepository _repository;
        private readonly ILogEventoRepository _repositoryLog;

        public PrestadoraServicoService(IPrestadoraServicoRepository repository,
            IPrestadoraServicoEquipamentoRepository equipamentosRepository,
            ILogEventoRepository repositoryLog
            ) : base(repository)
        {
            _repositoryLog = repositoryLog;
            _repository = repository;
            _equipamentosRepository = equipamentosRepository;
        }

        public IEnumerable<TBPrestadoraServico> GetAllByPrefeitura(int prefeituraID)
        {
            return _repository.Find(x => x.PrefeituraID == prefeituraID && x.bAtivo);
        }

        public async Task<bool> AddAsync(AspNetUser user, TBPrestadoraServico prestadora)
        {
            const bool valido = true;
            var dt = DateTime.Now;
            prestadora.bAtivo = true;
            await _repository.AddComHistoricoAsync(user.Id, dt, prestadora);

            var log = TBLogEvento.Novo(user, dt, "Adicionou uma Prestadora de Serviço");
            _repositoryLog.Add(log);

            return valido;
        }

        public async Task<bool> UpdateAsync(AspNetUser user, TBPrestadoraServico prestadora)
        {
            const bool valido = true;
            var dt = DateTime.Now;

            _repository.UpdateHistorico(user.Id, dt, prestadora);

            var log = TBLogEvento.Novo(user, dt, "Atualizou uma Prestadora de Serviço");
            _repositoryLog.Add(log);

            return valido;
        }

        public object[][] ReturnPrestadoraServicosByPrefeitura(int prefeituraID)
        {
            return
                _repository.Get(x => x.bAtivo && x.PrefeituraID == prefeituraID)
                    .Select(x => new object[] {x.PrestadoraServicosID, x.nmPrestadoraServico})
                    .ToArray();
        }

        public async Task<bool> AddEquipamentoAsync(AspNetUser user, TBPrestadoraServicosEquipamento equip)
        {
            var valido = true;
            var dt = DateTime.Now;

            if (valido)
                _equipamentosRepository.AddHistorico(user.Id, dt, equip);

            var log = TBLogEvento.Novo(user, dt, "Adicionou um Equipamento da Prestadora de Serviço");
            _repositoryLog.Add(log);

            return valido;
        }

        public async Task<bool> UpdateEquipamentoAsync(AspNetUser user, TBPrestadoraServicosEquipamento equip)
        {
            var valido = true;
            var dt = DateTime.Now;

            if (valido)
                _equipamentosRepository.UpdateHistorico(user.Id, dt, equip);

            var log = TBLogEvento.Novo(user, dt, "Atualizou um Equipamento da Prestadora de Serviço");
            _repositoryLog.Add(log);

            return valido;
        }
    }
}