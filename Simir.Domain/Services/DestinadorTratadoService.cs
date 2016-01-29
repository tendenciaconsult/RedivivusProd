using System.Linq;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class DestinadorTratadoService : ServiceBase<TBResiduosTratado>, IDestinadorTratadoService
    {
        private new readonly IResiduosDestinadorTratadoRepository _repository;

        private readonly IResiduosDestinadorRejeitoRepository _repositoryRejeitos;

        public DestinadorTratadoService(IResiduosDestinadorTratadoRepository repository,
            IResiduosDestinadorRejeitoRepository repositoryRejeitos

            ) : base(repository)
        {
            _repository = repository;
            _repositoryRejeitos = repositoryRejeitos;
        }


        public double GetRejeitosNaoTratados(int empresaID)
        {
            var ddd11 = _repository.Get(x => x.EmpresaID == empresaID)
                .Sum(x=>x.qtRejeito);
            var ttt = _repositoryRejeitos.Get(x => x.EmpresaID == empresaID)
                .Sum(x=>x.qtRejeitoVinculado);
            return ddd11 - ttt;
        }
    }
}
