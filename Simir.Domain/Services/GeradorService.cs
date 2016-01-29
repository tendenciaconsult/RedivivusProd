using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;
using Simir.Domain.Interfaces.ServiceAgents;

namespace Simir.Domain.Services
{
    public class GeradorService : ServiceBase<TBResiduosGerados>, IGeradorService
    {
        private readonly IGeradorMtrRepository _MtrRepository;
        private new readonly IResiduosGeradoRepository _repository;
        private readonly IResiduosGeradoItemRepository _repositoryItem;
        private readonly IArmazenamentoArquivo _armazemArquivo;

        public GeradorService(IResiduosGeradoRepository repository,
            IGeradorMtrRepository mtrRepository,
            IArmazenamentoArquivo armazemArquivo,
            IResiduosGeradoItemRepository repositoryItem
            ) : base(repository)
        {
            _repository = repository;
            _MtrRepository = mtrRepository;
            _repositoryItem = repositoryItem;
            _armazemArquivo = armazemArquivo;
        }

        public async Task<bool> SalvarResiduoGeradoAsync(TBResiduosGerados residuoGerado)
        {
            //todo
            return true;
        }

        public TBGeradorMtr NovoMtr(int empresaID, string path, string fileName)
        {
            var novoMtr = new TBGeradorMtr(empresaID, path, fileName);
            return novoMtr;
        }

        public async Task<bool> SalvarMtrAsync(TBGeradorMtr novoMtr)
        {
            _MtrRepository.Add(novoMtr);
            return true;
        }

        public IList<TBGeradorMtr> GetMtrsByEmpresaID(int empresaID)
        {
            return _MtrRepository.Find(x => x.EmpresaGeradoraID == empresaID).ToList();
        }

        public IList<TBResiduosGerados> GetResiduosGeradosByEmpresaID(int empresaID)
        {
            //return new List<TBResiduosGerado>();
            return _repository.Find(x => x.EmpresaID == empresaID).ToList();
        }

        public async Task<bool> ExcluirMtr(int empresaID, int geradorMtrID)
        {
            var arq = await _MtrRepository.GetByIdAsync(geradorMtrID);
            if (arq.EmpresaGeradoraID != empresaID)
            {
                throw new Exception(MensagensErro.empresaIDIncompativel);
            }
            _MtrRepository.Remove(arq);

            await _armazemArquivo.DeleteArquivo(arq.nmArquivo, "GeradorMtr");


            
            return true;
        }

        public bool Remove(TBResiduosGeradoItem itemModel)
        {
            _repositoryItem.Remove(itemModel);
            return true;
        }

        public async Task<bool> SalvarMtrAsync(TBGeradorMtr novoMtr, Stream inputStream)
        {
            _MtrRepository.Add(novoMtr);

            await _armazemArquivo.UploadArquivo(novoMtr,"GeradorMtr", inputStream);

            return true;
        }

        public async Task<Stream> DownloadMtr(int empresaID, int id)
        {
            var arq = await _MtrRepository.GetByIdAsync(id);
            if(arq.EmpresaGeradoraID != empresaID)
            {
                throw new Exception(MensagensErro.empresaIDIncompativel);
            }

            return await _armazemArquivo.DownloadArquivo(arq.nmArquivo, "GeradorMtr");
        }
    }
}