using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class RegiaoAdministrativaService : ServiceBase<TBRegiaoAdministrativa>, IRegiaoAdministrativaService
    {
        private readonly IRegiaoAdministrativaRepository _RegiaoAdministrativarepository;
        private readonly ILogEventoRepository _repositoryLog;
        private readonly IRegiaoAdministrativaLogradouroRepository _repositoryLogradouro;

        public RegiaoAdministrativaService(IRegiaoAdministrativaRepository repository,
            IRegiaoAdministrativaLogradouroRepository repositoryLogradouro,
            ILogEventoRepository repositoryLog)
            : base(repository)
        {
            _repositoryLogradouro = repositoryLogradouro;
            _RegiaoAdministrativarepository = repository;
            _repositoryLog = repositoryLog;
        }

        public object[][] GetHashRegiaoAdministrativa(int prefeituraID)
        {
            return
                _RegiaoAdministrativarepository.Get(x => x.bAtivo && x.PrefeituraID == prefeituraID)
                    .Select(x => new object[] {x.RegiaoAdministrativaID, x.nmRegiaoAdministrativa})
                    .ToArray();
        }

        public async Task<bool> AddRegiaoAdministrativaLogradouroAsync(AspNetUser user,
            TBRegiaoAdministrativaLogradouro RegiaoAdministrativaLogradouro)
        {
            var dt = DateTime.Now;

            _repositoryLogradouro.AddHistorico(user.Id, dt, RegiaoAdministrativaLogradouro);
            //Add(TBRegiaoAdministrativaLogradouro);

            var log = TBLogEvento.Novo(user, dt, "Adicionou um Logradouro a uma Regiao Administrativa");
            _repositoryLog.Add(log);

            return true;
        }

        public object[][] GetBairrosByRegiaoAdministrativa(int idRegiaoAdministrativa)
        {
            return _repositoryLogradouro.Get(filter: x => x.RegiaoAdministrativaID == idRegiaoAdministrativa &&
                                                  x.bAtivo == true, includeProperties: "TBEnderecoBairro"
                ).Select(x => new object[] {x.EnderecoBairroID, x.TBEnderecoBairro.nmBairro}).ToArray();
        }

        public object[][] GetLogradouroByRegiaoAdministrativaANDBairro(int idRegiaoAdministrativa, int idBairro)
        {
            return _repositoryLogradouro.Get(x => x.RegiaoAdministrativaID == idRegiaoAdministrativa &&
                                                  x.bAtivo == true && x.EnderecoBairroID == idBairro, includeProperties: "TBEnderecoLogradouro"
                ).Select(x => new object[] {x.EnderecoLogradouroID, x.TBEnderecoLogradouro.nmLogradouro}).ToArray();
        }

        public async Task<bool> UpdateRegiaoAdministrativaLogradouroAsync(AspNetUser user,
            TBRegiaoAdministrativaLogradouro RegiaoAdministrativaLogradouro)
        {
            var dt = DateTime.Now;

            _repositoryLogradouro.UpdateHistorico(user.Id, dt, RegiaoAdministrativaLogradouro);


            var log = TBLogEvento.Novo(user, dt,
                "Editou um logradouro da Região Administrativa " +
                RegiaoAdministrativaLogradouro.TBRegiaoAdministrativa.nmRegiaoAdministrativa + ".");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> AddRegiaoAdministrativaAsync(AspNetUser user,
            TBRegiaoAdministrativa RegiaoAdministrativa)
        {
            var dt = DateTime.Now;

            _RegiaoAdministrativarepository.AddHistorico(user.Id, dt, RegiaoAdministrativa);


            var log = TBLogEvento.Novo(user, dt,
                "Criou uma nova Regiao Administrativa com o nome de '" + RegiaoAdministrativa.nmRegiaoAdministrativa +
                "'");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> UpdateRegiaoAdministrativaAsync(AspNetUser user,
            TBRegiaoAdministrativa RegiaoAdministrativa)
        {
            var dt = DateTime.Now;

            _RegiaoAdministrativarepository.UpdateHistorico(user.Id, dt, RegiaoAdministrativa);


            var log = TBLogEvento.Novo(user, dt,
                "Alterou a Regiao Administrativa com o nome de '" + RegiaoAdministrativa.nmRegiaoAdministrativa + "'");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> ExcluirRegiaoAdministrativaAsync(AspNetUser user, int RegiaoAdministrativaID)
        {
            var dt = DateTime.Now;

            var RegiaoAdministrativa = _RegiaoAdministrativarepository.GetById(RegiaoAdministrativaID);

            RegiaoAdministrativa.bAtivo = false;

            _RegiaoAdministrativarepository.UpdateHistorico(user.Id, dt, RegiaoAdministrativa);


            var log = TBLogEvento.Novo(user, dt,
                "Desativou a Região Administrativa " + RegiaoAdministrativa.nmRegiaoAdministrativa + ".");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> ExcluirLogradouroAsync(AspNetUser user, int idLogradouro)
        {
            var dt = DateTime.Now;

            var Logradouro = _repositoryLogradouro.GetById(idLogradouro);

            Logradouro.bAtivo = false;

            _repositoryLogradouro.UpdateHistorico(user.Id, dt, Logradouro);


            var log = TBLogEvento.Novo(user, dt, "Desativou o Logradouro " +
                                                 Logradouro.TBEnderecoLogradouro.nmLogradouro +
                                                 " da Região Administrativa " +
                                                 Logradouro.TBRegiaoAdministrativa.nmRegiaoAdministrativa + ".");

            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> ValidaLogradouroCadastrado(int RegiaoAdministrativaID, int LogradouroID)
        {
            var Retorno = true;

            var Result =
                _repositoryLogradouro.Get(
                    x =>
                        x.bAtivo == true && x.RegiaoAdministrativaID == RegiaoAdministrativaID &&
                        x.EnderecoLogradouroID == LogradouroID)
                    .Select(x => x.RegiaoAdministrativaLogradouroID)
                    .FirstOrDefault();

            if (Result > 0)
            {
                Retorno = false;
            }


            return Retorno;
        }

        public async Task<TBRegiaoAdministrativa> ReturnRegiaoAdministrativaByID(int id)
        {
            return _RegiaoAdministrativarepository.Get(x => x.bAtivo && x.RegiaoAdministrativaID == id).FirstOrDefault();
        }

        public async Task<TBRegiaoAdministrativaLogradouro> GetRegiaoAdministrativaLogradouroByID(int id)
        {
            return
                _repositoryLogradouro.Get(x => x.bAtivo == true && x.RegiaoAdministrativaLogradouroID == id)
                    .FirstOrDefault();
        }

        public async Task<TBRegiaoAdministrativa> ReturnPrimeiraRegiaoAdministrativa(int id)
        {
            return
                _RegiaoAdministrativarepository.Get(x => x.bAtivo && x.PrefeituraID == id)
                    .OrderBy(x => x.nmRegiaoAdministrativa)
                    .FirstOrDefault();
        }

        public IEnumerable<TBRegiaoAdministrativa> GetAllRegioesAdministrativasByPrefeituraID(int id)
        {
            return
                _RegiaoAdministrativarepository.Get(x => x.bAtivo && x.PrefeituraID == id)
                    .OrderBy(x => x.nmRegiaoAdministrativa);
        }

        public IEnumerable<TBRegiaoAdministrativaLogradouro> GetAllByRegiaoAdministrativa(int id)
        {
            return
                _repositoryLogradouro.Get(x => x.bAtivo == true && x.RegiaoAdministrativaID == id)
                    .OrderBy(x => x.TBEnderecoLogradouro.nmLogradouro);
        }
    }
}