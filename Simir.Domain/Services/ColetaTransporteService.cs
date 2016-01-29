using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;
using Simir.Domain.Interfaces.ServiceAgents;

namespace Simir.Domain.Services
{
    public class ColetaTransporteService : ServiceBase<TBResiduosColetado>, IColetaTransporteService
    {
        private readonly IGeradorMtrRepository _MtrRepository;
        private new readonly IResiduosColetadoRepository _repository;
        private readonly IResiduosColetadoItemRepository _repositoryItem;
        private readonly IArmazenamentoArquivo _armazemArquivo;

        public ColetaTransporteService(IResiduosColetadoRepository repository,
            IResiduosColetadoItemRepository repositoryItem,
            IGeradorMtrRepository mtrRepository,
            IArmazenamentoArquivo armazemArquivo
            ) : base(repository)
        {
            _repository = repository;
            _repositoryItem = repositoryItem;
            _armazemArquivo = armazemArquivo;
            _MtrRepository = mtrRepository;
        }

        public async Task<Stream> DownloadMtr(int empresaID, int id)
        {
            var arq = await _MtrRepository.GetByIdAsync(id);
            if (arq.EmpresaGeradoraID != empresaID)
            {
                throw new Exception(MensagensErro.empresaIDIncompativel);
            }

            return await _armazemArquivo.DownloadArquivo(arq.nmArquivo, "ColetaMtr");

        }

        public async Task<bool> ExcluirMtr(int empresaID, int geradorMtrID)
        {
            var arq = await _MtrRepository.GetByIdAsync(geradorMtrID);
            if (arq.EmpresaGeradoraID != empresaID)
            {
                throw new Exception(MensagensErro.empresaIDIncompativel);
            }
            _MtrRepository.Remove(arq);

            await _armazemArquivo.DeleteArquivo(arq.nmArquivo, "ColetaMtr");



            return true;
        }

        public IList<TBGeradorMtr> GetMtrsByEmpresaID(int empresaID)
        {
            return _MtrRepository.Find(x => x.EmpresaGeradoraID == empresaID).ToList();
        }

        public IList<TBResiduosColetado> GetResiduosGeradosByEmpresaID(int empresaID)
        {
            return _repository.Find(x => x.EmpresaID == empresaID).ToList();
        }

        public bool Remove(TBResiduosColetadoItem itemModel)
        {
            _repositoryItem.Remove(itemModel);
            return true;
        }

        public async Task<bool> SalvarMtrAsync(TBGeradorMtr novoMtr, Stream inputStream)
        {
            _MtrRepository.Add(novoMtr);

            await _armazemArquivo.UploadArquivo(novoMtr, "ColetaMtr", inputStream);

            return true;
        }
    }
}
