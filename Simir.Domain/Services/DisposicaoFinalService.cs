using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class DisposicaoFinalService : ServiceBase<TBDisposicaoFinalResiduo>, IDisposicaoFinalService
    {
        private new readonly IDisposicaoFinalRepository _repository;

        public DisposicaoFinalService(IDisposicaoFinalRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public List<TBDisposicaoFinalResiduo> GetAllProgramacaoByEmpresaID(int idEmpresa)
        {
            return _repository.Get
                (
                    x => x.EmpresaID == idEmpresa
                )
                .Where(x=>x.dtRecebimento.Year == DateTime.Now.Year)
                .OrderBy(x => x.dtRecebimento).ToList();
        }
        public async Task<TBDisposicaoFinalResiduo> RetornaProgramacaoByID(int id)
        {
            return _repository.Get(x => x.DisposicaoFinalResiduoID == id).FirstOrDefault();
        }

        public async Task<bool> AddNovaProgramacaoAsync(TBDisposicaoFinalResiduo item)
        {
            
            _repository.Add(item);
            //Add(Programação de Limpeza Ordinaria);

            return true;
        }

        public async Task<bool> UpdateProgramacaoAsync(TBDisposicaoFinalResiduo item)
        {
            _repository.Update(item);

            return true;
        }

        public async Task<bool> ExcluirProgramacaoAsync(int id)
        {
            var dt = DateTime.Now;

            var Dados = _repository.GetById(id);

            _repository.Remove(Dados);

            return true;
        }
    }
}
