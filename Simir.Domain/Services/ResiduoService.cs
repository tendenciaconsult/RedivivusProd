using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class ResiduoService : ServiceBase<TBResiduo>, IResiduoService
    {
        private readonly IResiduoAtividadeRepository _atividadeRepository;
        private readonly IResiduoClasseRepository _classeRepository;
        private readonly IResiduoClassificadoRepository _classificadoRepository;
        private readonly IResiduoListaRepository _listaRepository;
        private new readonly IResiduoRepository _repository;

        public ResiduoService(IResiduoRepository repository,
            IResiduoClasseRepository classificacaoRepository,
            IResiduoAtividadeRepository ramoRepository,
            IResiduoListaRepository tipoListaRepository,
            IResiduoClassificadoRepository classificadoRepository
            ) : base(repository)
        {
            _repository = repository;
            _classeRepository = classificacaoRepository;
            _atividadeRepository = ramoRepository;
            _listaRepository = tipoListaRepository;
            _classificadoRepository = classificadoRepository;
        }

        public object[][] GetClassificacoesByRamo(int id)
        {
            return _classificadoRepository.Get(x => x.ResiduoAtividadeID == id, includeProperties: "Classe")
                .Select(x => x.Classe)
                .Distinct()
                .Select(x => new object[] {x.ResiduoClasseID, x.nmResiduoClasse, x.Descricao})
                .ToArray();
        }

        public object[][] GetTipoLista()
        {
            return _listaRepository.GetAll()
                .Select(x => new object[] {x.ResiduoListaID, x.nmResiduoLista, x.Descricao})
                .ToArray();
        }

        public object[][] GetRamoByTipolista(int idTipolista)
        {
            //var ddd = _classificadoRepository.Get(filter: x => x.ResiduoListaID == idTipolista).ToList();
            //var dd2 = _classificadoRepository.Get(filter: x => x.ResiduoListaID == idTipolista, includeProperties: "Atividade").ToList();

            return _classificadoRepository.Get(x => x.ResiduoListaID == idTipolista, includeProperties: "Atividade")
                .Select(x => x.Atividade)
                .Distinct()
                .Select(x => new object[] {x.ResiduoAtividadeID, x.nmResiduoAtividade, x.Descricao})
                .ToArray();
        }


        public object[][] GetResiduosClassificados(int listaId, int atividadeId, int classeId)
        {
            return _classificadoRepository.Get(x => x.ResiduoListaID == listaId && x.ResiduoAtividadeID == atividadeId && x.ResiduoClasseID == classeId, includeProperties: "Atividade")
                .Select(x => new object[] { x.ResiduoClassificadoID, x.Residuo.nmResiduo, x.Residuo.Descricao })
                .ToArray();
        }
    }
}