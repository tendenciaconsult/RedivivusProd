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
    public class ContratoFuncionarioService : ServiceBase<TBServicoFuncionario>,
        IContratoFuncionarioService
    {
        private new readonly IServicoFuncionarioRepository _repository;
        private readonly IServicoFuncaoTituloRepository _tituloRepository;
        private readonly IServicoFuncaoSubtituloRepository _subtituloRepository;

        public ContratoFuncionarioService(IServicoFuncionarioRepository repository,
            IServicoFuncaoTituloRepository tituloRepository,
            IServicoFuncaoSubtituloRepository subtituloRepository
            ) : base(repository)
        {
            _repository = repository;
            _tituloRepository = tituloRepository;
            _subtituloRepository = subtituloRepository;
        }

        public string[][] GetAllFuncaoTitulo()
        {
            return _tituloRepository.GetAll().Select(x=> new string[]{ x.ServicoFuncaoTituloID.ToString(), x.nmServicoFuncaoTitulo }).ToArray();
        }

        public string[][] GetFuncaoTituloBySubtitulo(int id)
        {
            return _subtituloRepository.Find(x=>x.ServicoFuncaoTituloID == id).Select(x => new string[] { x.ServicoFuncaoSubtituloID.ToString(), x.nmServicoFuncaoSubtitulo }).ToArray();
        }
    }
}
