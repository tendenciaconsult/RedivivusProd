using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class UsuarioService : ServiceBase<TBUsuario>, IUsuarioService
    {
        private new readonly IUsuarioRepository _repository;
        private readonly ILogEventoRepository _repositoryLog;
        private readonly IAspNetPerfilRepository _PerfilRepository;

        public UsuarioService(IUsuarioRepository repository,
            IAspNetPerfilRepository PerfilRepository,
            ILogEventoRepository repositoryLog
            ) : base(repository)
        {
            _repository = repository;
            _PerfilRepository = PerfilRepository;
            _repositoryLog = repositoryLog;
        }

        public IEnumerable<TBUsuario> GetAllByPrefeitura(int prefeituraID)
        {

            return _repository.Get
                   (
                       x => x.bAtivo == true
                            && x.PrefeituraID == prefeituraID
                   );
        }

        public IEnumerable<AspNetPerfil> GetAllperfilByPrefeitura(int PrefeituraID)
        {
            return _PerfilRepository.Get
                (
                    x => x.bAtivo == true
                         && x.PrefeituraID == PrefeituraID
                );
        }

        public async Task<bool> AddAsync(AspNetUser user, TBUsuario usuario)
        {
            var valido = true;
            var dt = DateTime.Now;

            if (valido)
                await _repository.AddComHistoricoAsync((int) user.TBUsuario.PrefeituraID, user.Id, dt, usuario);

            var log = TBLogEvento.Novo(user, dt, "Adicionou um Usuário");
            _repositoryLog.Add(log);

            return valido;
        }

        public async Task<bool> UpdateAsync(AspNetUser user, TBUsuario usuario)
        {
            var valido = true;
            var dt = DateTime.Now;

            if (valido)
                _repository.UpdateComHistorico(user.Id, dt, usuario);

            var log = TBLogEvento.Novo(user, dt, "Atualizou um Usuário");
            _repositoryLog.Add(log);

            return valido;
        }

        public TBUsuario GetById(int prefeituraID, int Id)
        {
            return _repository.GetById(prefeituraID, Id);
        }

        public async Task<bool> DeleteAsync(AspNetUser user, TBUsuario usuario)
        {
            var valido = true;
            var dt = DateTime.Now;

            if (valido)
                _repository.DeletarComHistorico(user.Id, dt, usuario);

            var log = TBLogEvento.Novo(user, dt, "Desativou um Usuário");
            _repositoryLog.Add(log);

            return valido;
        }
    }
}