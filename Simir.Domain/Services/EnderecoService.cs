using System;
using System.Linq;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class EnderecoService : ServiceBase<TBEndereco>, IEnderecoService
    {
        private readonly IEnderecoBairroRepository _bairroRepository;
        private readonly IEnderecoCidadeRepository _cidadeRepository;
        private readonly IEnderecoEstadoRepository _estadoRepository;
        private readonly IEnderecoLogradouroRepository _logradouroRepository;
        private new readonly IEnderecoRepository _repository;

        public EnderecoService(IEnderecoRepository repository,
            IEnderecoEstadoRepository estadoRepository,
            IEnderecoCidadeRepository cidadeRepository,
            IEnderecoBairroRepository bairroRepository,
            IEnderecoLogradouroRepository logradouroRepository)
            : base(repository)
        {
            _estadoRepository = estadoRepository;
            _cidadeRepository = cidadeRepository;
            _bairroRepository = bairroRepository;
            _logradouroRepository = logradouroRepository;
            _repository = repository;
        }

        public object[][] GetUfs()
        {
            return _estadoRepository.GetAll().Select(x => new object[] {x.EnderecoEstadoID, x.Abraviacao}).ToArray();
        }

        public object[][] GetMunicipiosByUf(int idUf)
        {
            return
                _cidadeRepository.Find(x => x.EnderecoEstadoID == idUf)
                    .Select(x => new object[] {x.EnderecoCidadeID, x.nmCidade})
                    .ToArray();
        }

        public object[][] GetBairrosByMunicipio(int idMunicipio)
        {
            return
                _bairroRepository.Find(x => x.EnderecoCidadeID == idMunicipio)
                    .Select(x => new object[] {x.EnderecoBairroID, x.nmBairro})
                    .ToArray();
        }

        public TBEnderecoLogradouro ConsultaCep(string cep)
        {
            return _logradouroRepository.Find(x => x.CEP == cep).FirstOrDefault();
        }

        public bool ValidaEndereco(TBEndereco tBEndereco)
        {
            var logra = ConsultaCep(tBEndereco.CEP);
            if (logra != null)
            {
                if (tBEndereco.EnderecoEstadoID != logra.TBEnderecoBairro.TBEnderecoCidade.EnderecoEstadoID)
                    throw new ArgumentException(MensagensErro.cepEstadoDiferente, "EnderecoEstadoID");
                if (tBEndereco.EnderecoCidadeID != logra.TBEnderecoBairro.EnderecoCidadeID)
                    throw new ArgumentException(MensagensErro.cepCidadeDiferente, "EnderecoCidadeID");
                if (tBEndereco.EnderecoBairroID != logra.EnderecoBairroID)
                    throw new ArgumentException(MensagensErro.cepBairroDiferente, "EnderecoBairroID");
            }
            else
            {
                var bairro = _bairroRepository.GetById(tBEndereco.EnderecoBairroID);
                if (bairro == null)
                    throw new ArgumentException(MensagensErro.bairroInexistente, "EnderecoBairroID");

                if (bairro.EnderecoCidadeID != tBEndereco.EnderecoCidadeID)
                    throw new ArgumentException(MensagensErro.bairroCidadeDiferente, "EnderecoCidadeID");

                if (bairro.TBEnderecoCidade.EnderecoEstadoID != tBEndereco.EnderecoEstadoID)
                    throw new ArgumentException(MensagensErro.cidadeEstadoDiferente, "EnderecoEstadoID");
            }

            return true;
        }

        public object[][] GetLogradouroByBairro(int idBairro)
        {
            return
                _logradouroRepository.Find(x => x.EnderecoBairroID == idBairro)
                    .Select(x => new object[] {x.EnderecoLogradouroID, x.nmLogradouro})
                    .ToArray();
        }
    }
}