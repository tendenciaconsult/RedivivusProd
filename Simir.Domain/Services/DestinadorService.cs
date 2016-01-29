using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class DestinadorService : ServiceBase<TBResiduosDestinadore>,
        IDestinadorService
    {
        private new readonly IDestinadorRepository _repository;
        private readonly IDestinadorItemRepository _repositoryItem;

        private readonly IResiduosDestinadorTratadoRepository _repositoryTratados;

        public DestinadorService(IDestinadorRepository repository,
            IDestinadorItemRepository repositoryItem,
            IResiduosDestinadorTratadoRepository repositoryTratados) : base(repository)
        {
            _repository = repository;
            _repositoryItem = repositoryItem;
            _repositoryTratados = repositoryTratados;
        }

        public IList<TBResiduosDestinadore> GetResiduosGeradosByEmpresaID(int empresaID)
        {
            return _repository.Find(x => x.EmpresaID == empresaID).ToList();
        }

        public bool Remove(TBResiduosDestinadoreItem itemModel)
        {
            _repositoryItem.Remove(itemModel);
            return true;
        }


        public object[][] HashResiduosRecebidoNaoTratados(int empresaId)
        {



            var ddd11 = _repository.Get(x => x.EmpresaID == empresaId)
                .SelectMany(x => x.Itens)
                .GroupBy(x =>new { x.emLitros, x.ResiduoClassificadoID })
                .Select(x => new
                {
                    x.First().ResiduoClassificadoID,
                    Nome = x.First().ResiduoClassificado.Residuo.nmResiduo +( x.First().emLitros ?" (litros)": " (kg)"),
                    Soma = x.Sum(y => y.qtResiduo),
                    x.First().emLitros
                });
            var ttt = _repositoryTratados.Get(x => x.EmpresaID == empresaId)
                .GroupBy(x => new { x.emLitros, x.ResiduoClassificadoID })
                .Select(x => new
                {
                    x.First().ResiduoClassificadoID,
                    Soma = x.Sum(y => y.qtResiduoTratado),
                    x.First().emLitros
                }).ToList();



            var query =
                ddd11.GroupJoin(ttt, recebidos => new { recebidos.emLitros, recebidos.ResiduoClassificadoID },
                    tratado => new { tratado.emLitros, tratado.ResiduoClassificadoID }, (recebidos, td) => new {recebidos, td})
                    .SelectMany(@t => @t.td.DefaultIfEmpty(),
                        (@t, tratadoDeful) =>
                            new object[]
                            {
                                @t.recebidos.ResiduoClassificadoID,
                                @t.recebidos.Nome,
                                tratadoDeful == null ? @t.recebidos.Soma : @t.recebidos.Soma - tratadoDeful.Soma
                            }).ToArray();


            return query;
        }
        public object[][] HashResiduosRecebidoNaoTratadosBKP(int empresaId)
        {



            var ddd11 = _repository.Find(x => x.EmpresaID == empresaId);
            var ddd = ddd11.SelectMany(x => x.Itens)
                    .GroupBy(x=>x.ResiduoClassificadoID)
                    .Select(x=> new
                    {
                        x.First().ResiduoClassificadoID,
                        x.First().ResiduoClassificado.Residuo.nmResiduo,
                        Soma = x.Sum(y=>y.qtResiduo)
                    })
                    .Join(_repositoryTratados.Find(x => x.EmpresaID == empresaId)
                        .GroupBy(x => x.ResiduoClassificadoID)
                        .Select(x => new
                        {
                            x.First().ResiduoClassificadoID,
                            x.First().ResiduoClassificado.Residuo.nmResiduo,
                            Soma = x.Sum(y => y.qtResiduoTratado)
                        })
                      , recebidos => recebidos.ResiduoClassificadoID
                      , tratado => tratado.ResiduoClassificadoID
                      , (r, t) => new object[]{ r.ResiduoClassificadoID, t.nmResiduo, r.Soma - t.Soma })
                      .Where(x=> (int) x[2] > 0)
                    .ToArray();

            return ddd;
        }
    }
}
