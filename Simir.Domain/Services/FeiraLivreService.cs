using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class FeiraLivreService : ServiceBase<TBFeiraLivre>, IFeiraLivreService
    {
        private readonly IFeiraLivreRepository _FeiraLivre;
        private readonly ILogEventoRepository _repositoryLog;

        public FeiraLivreService(IFeiraLivreRepository FeiraLivre,
            ILogEventoRepository repositoryLog)
            : base(FeiraLivre)
        {
            _FeiraLivre = FeiraLivre;
            _repositoryLog = repositoryLog;
        }

        public object[][] GetFeiraLivreByRegiaoAdministrativa(int idRegiaoAdministrativa)
        {
            return _FeiraLivre.Get(x => x.RegiaoAdministrativaID == idRegiaoAdministrativa &&
                                        x.bAtivo
                ).Select(x => new object[] {x.FeiraLivreID, x.nmProgramacao}).ToArray();
        }

        public async Task<TBFeiraLivre> GetFeriaByID(int id)
        {
            return _FeiraLivre.Get(x => x.FeiraLivreID == id).FirstOrDefault();
        }

        public async Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBFeiraLivre Dados)
        {
            var dt = DateTime.Now;

            _FeiraLivre.AddHistorico(user.Id, dt, Dados);
            //Add(Programação de Limpeza Ordinaria);

            var log = TBLogEvento.Novo(user, dt, "Adicionou uma nova Feira Livre");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBFeiraLivre Dados)
        {
            var dt = DateTime.Now;

            _FeiraLivre.UpdateHistorico(user.Id, dt, Dados);


            var log = TBLogEvento.Novo(user, dt, "Editou uma Feira Livre");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> ExcluirProgramacaoAsync(AspNetUser user, int FeiraLivreID)
        {
            var dt = DateTime.Now;

            var Dados = _FeiraLivre.GetById(FeiraLivreID);

            Dados.bAtivo = false;

            _FeiraLivre.UpdateHistorico(user.Id, dt, Dados);


            var log = TBLogEvento.Novo(user, dt, "Desativou uma Programação de Limpeza Eventual");
            _repositoryLog.Add(log);

            return true;
        }

        public List<TBFeiraLivre> ConsultaFeiraLivre()
        {
            return _FeiraLivre.Get
                (
                    x => x.bAtivo
                )
                .OrderBy(x => x.nmProgramacao).ToList();
        }
    }
}