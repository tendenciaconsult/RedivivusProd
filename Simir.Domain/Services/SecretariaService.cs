using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class SecretariaService : ServiceBase<TBSecretaria>, ISecretariaService
    {
        private new readonly ISecretariaRepository _repository;
        private readonly ILogEventoRepository _repositoryLog;
        private readonly IResponsabilidadesRepository _responsabilidadeRepository;
        private readonly ISecretariaResponsabilidadesRepository _secretariaResponsabilidadeRepository;

        public SecretariaService(ISecretariaRepository repository,
            ISecretariaResponsabilidadesRepository secretariaResponsabilidadeRepository,
            IResponsabilidadesRepository responsabilidadeRepository,
            ILogEventoRepository repositoryLog
            ) : base(repository)
        {
            _repository = repository;
            _secretariaResponsabilidadeRepository = secretariaResponsabilidadeRepository;
            _responsabilidadeRepository = responsabilidadeRepository;
            _repositoryLog = repositoryLog;
        }

        public IEnumerable<TBResponsabilidade> GetAllResponsabilidades()
        {
            return _responsabilidadeRepository.GetAll();
        }

        public async Task<bool> AddSecretariaAsync(AspNetUser user, TBSecretaria secretaria,
            string[] responsabilidadesIDs)
        {
            var valido = secretaria.Validar();

            secretaria.TBSecretariasResponsabilidades = new List<TBSecretariasResponsabilidade>();
            foreach (var item in responsabilidadesIDs)
            {
                var resp = _responsabilidadeRepository.Find(x => x.nmResponsabilidades == item).FirstOrDefault();
                var secResp = new TBSecretariasResponsabilidade
                {
                    nmOutros = item,
                    PrefeituraID = secretaria.PrefeituraID,
                    TBSecretaria = secretaria
                };
                if (resp != null)
                {
                    secResp.ResponsabilidadesID = resp.ResponsabilidadesID;
                    secResp.TBResponsabilidade = resp;
                }
                secretaria.TBSecretariasResponsabilidades.Add(secResp);
            }

            var dt = DateTime.Now;

            if (valido)
                await _repository.AddComHistoricoAsync(user.Id, dt, secretaria);
            //Add(secretaria);

            var log = TBLogEvento.Novo(user, dt, "Adicionou uma Secretaria");
            _repositoryLog.Add(log);

            return valido;
        }

        public async Task<bool> UpdateSecretariaAsync(AspNetUser user, TBSecretaria secretaria,
            string[] responsabilidadesIDs)
        {
            var valido = secretaria.Validar();

            var listFicaram = new List<TBSecretariasResponsabilidade>();

            if (responsabilidadesIDs != null)
                foreach (var item in responsabilidadesIDs)
                {
                    int idResp;
                    if (Int32.TryParse(item, out idResp))
                    {
                        listFicaram.Add(
                            secretaria.TBSecretariasResponsabilidades.FirstOrDefault(
                                x => x.SecretariasResponsabilidadesID == idResp));
                    }
                    else
                    {
                        var resp = _responsabilidadeRepository.Find(x => x.nmResponsabilidades == item).FirstOrDefault();
                        var secResp = new TBSecretariasResponsabilidade
                        {
                            nmOutros = item,
                            PrefeituraID = secretaria.PrefeituraID,
                            TBSecretaria = secretaria
                        };
                        if (resp != null)
                        {
                            secResp.ResponsabilidadesID = resp.ResponsabilidadesID;
                            secResp.TBResponsabilidade = resp;
                        }
                        listFicaram.Add(secResp);
                    }
                }

            var respRemove = secretaria.TBSecretariasResponsabilidades.Except(listFicaram);

            secretaria.TBSecretariasResponsabilidades = listFicaram;

            var dt = DateTime.Now;

            if (valido)
            {
                _repository.UpdateHistorico(user.Id, dt, secretaria);

                foreach (var item in respRemove)
                {
                    _secretariaResponsabilidadeRepository.Remove(item);
                }
            }


            var log = TBLogEvento.Novo(user, dt, "Editou uma Secretaria");
            _repositoryLog.Add(log);

            return valido;
        }

        public async Task<bool> ExcluirSecretariaAsync(AspNetUser user, int secretariaId)
        {
            var dt = DateTime.Now;

            var secretaria = _repository.GetById(secretariaId);
            secretaria.bAtivo = false;
            _repository.UpdateHistorico(user.Id, dt, secretaria);


            var log = TBLogEvento.Novo(user, dt, "Desativou uma Secretaria");
            _repositoryLog.Add(log);

            return true;
        }

        public List<TBSecretaria> GetAllByPrefeitura(int prefeituraID)
        {
            return _repository.Find(
                x => x.bAtivo && 
                    x.PrefeituraID == prefeituraID
                ).ToList();
        }
    }
}