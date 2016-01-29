using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class LimpezaEventualService : ServiceBase<TBLimpezaEventual>, ILimpezaEventualService
    {
        private readonly ILimpezaEventualRepository _repositoryLimpezaEventual;
        private readonly ILogEventoRepository _repositoryLog;

        public LimpezaEventualService(ILimpezaEventualRepository repositoryLimpezaEventual,
            ILogEventoRepository repositoryLog)
            : base(repositoryLimpezaEventual)
        {
            _repositoryLimpezaEventual = repositoryLimpezaEventual;
            _repositoryLog = repositoryLog;
        }

        public object[][] GetHasLimpezaEventualBYData(int prefeituraID, DateTime Data)
        {
            return _repositoryLimpezaEventual.Get
                (
                    x => x.PrefeituraID == prefeituraID &&
                         x.dtFim <= Data && x.bAtivo == true &&
                         x.TBLimpezaExecutada == null
                )
                .Select(x => new object[]
                {
                    x.LimpezaEventualID, x.nmProgramacao +
                                         "  " + DateTime.Parse(x.dtFim.ToString()).ToShortDateString()
                }).ToArray();
        }

        public List<TBLimpezaEventual> GetAllProgramacaoNaoRealizadas(int PrefeituraID)
        {
            return _repositoryLimpezaEventual.Get
                (
                    x => x.PrefeituraID == PrefeituraID &&
                         x.bAtivo == true &&
                         x.TBLimpezaExecutada == null
                )
                .OrderBy(x => x.nmProgramacao).ToList();
        }

        public List<TBLimpezaEventual> BuscaProgramacaoByData(DateTime dtReferencia, int prefeituraID)
        {
            return _repositoryLimpezaEventual.Get
                (
                    x => x.PrefeituraID == prefeituraID &&
                         x.dtInicio == dtReferencia && x.bAtivo == true &&
                         x.TBLimpezaExecutada == null
                )
                .OrderBy(x => x.nmProgramacao).ToList();
        }

        public async Task<TBLimpezaEventual> ReturnProgramacaoByID(int id)
        {
            return _repositoryLimpezaEventual.Get(x => x.LimpezaEventualID == id).FirstOrDefault();
        }

        public async Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBLimpezaEventual LimpezaEventual)
        {
            var dt = DateTime.Now;

            _repositoryLimpezaEventual.AddHistorico(user.Id, dt, LimpezaEventual);
            //Add(Programação de Limpeza Ordinaria);

            var log = TBLogEvento.Novo(user, dt, "Adicionou uma nova Programação de Limpeza Eventual");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBLimpezaEventual LimpezaEventual)
        {
            var dt = DateTime.Now;

            _repositoryLimpezaEventual.UpdateHistorico(user.Id, dt, LimpezaEventual);


            var log = TBLogEvento.Novo(user, dt, "Editou uma Programação de Limpeza Eventual");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> ExcluirProgramacaoAsync(AspNetUser user, int LimpezaEventualID)
        {
            var dt = DateTime.Now;

            var LimpezaEventual = _repositoryLimpezaEventual.GetById(LimpezaEventualID);

            LimpezaEventual.bAtivo = false;

            _repositoryLimpezaEventual.UpdateHistorico(user.Id, dt, LimpezaEventual);


            var log = TBLogEvento.Novo(user, dt, "Desativou uma Programação de Limpeza Eventual");
            _repositoryLog.Add(log);

            return true;
        }

        public List<TBLimpezaEventual> CarregaGridLimpezaEventual(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao)
        {
            var aux = 0;
            if (bOrdinaria && (bEventual == false))
            {
                bOrdinaria = true;
                aux = 1;
            }
            if ((bOrdinaria == false) && bEventual)
            {
                bOrdinaria = false;
                aux = 1;
            }


            return _repositoryLimpezaEventual.Get
                (
                    x => x.bAtivo == true &&
                         x.TipoProgramacao == TipoProgramacao &&
                         ((idRegiaoAdministrativa == 0) || x.RegiaoAdministrativaID == idRegiaoAdministrativa) &&
                         ((idPrestadora == 0) || x.PrestadoraServicosID == idPrestadora) &&
                         ((idLogradouro == 0) || x.EnderecoLogradouroID == idLogradouro) &&
                         ((idBairro == 0) || x.EnderecoBairroID == idBairro) &&
                         ((aux == 0) || x.bServicoOrdinario == bOrdinaria) &&
                         x.dtInicio >= dtInicio &&
                         x.dtInicio <= dtFim
                )
                .OrderBy(x => x.nmProgramacao).ToList();
        }

        public List<TBLimpezaEventual> CarregaGridLimpezaEventualExecutado(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao)
        {
            var aux = 0;
            if (bOrdinaria && (bEventual == false))
            {
                bOrdinaria = true;
                aux = 1;
            }
            if ((bOrdinaria == false) && bEventual)
            {
                bOrdinaria = false;
                aux = 1;
            }
            return _repositoryLimpezaEventual.Get
                (
                    x => x.bAtivo == true &&
                         x.TipoProgramacao == TipoProgramacao &&
                         ((idRegiaoAdministrativa == 0) || x.RegiaoAdministrativaID == idRegiaoAdministrativa) &&
                         ((idPrestadora == 0) || x.PrestadoraServicosID == idPrestadora) &&
                         ((idLogradouro == 0) || x.EnderecoLogradouroID == idLogradouro) &&
                         ((idBairro == 0) || x.EnderecoBairroID == idBairro) &&
                         ((aux == 0) || x.bServicoOrdinario == bOrdinaria) &&
                         x.dtInicio >= dtInicio &&
                         x.dtInicio <= dtFim &&
                         x.TBLimpezaExecutada.ProgramacaoRealizada
                )
                .OrderBy(x => x.nmProgramacao).ToList();
        }

        public List<TBLimpezaEventual> CarregaGridLimpezaEventualNaoExecutado(int idRegiaoAdministrativa,
            int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao)
        {
            var aux = 0;
            if (bOrdinaria && (bEventual == false))
            {
                bOrdinaria = true;
                aux = 1;
            }
            if ((bOrdinaria == false) && bEventual)
            {
                bOrdinaria = false;
                aux = 1;
            }
            return _repositoryLimpezaEventual.Get
                (
                    x => x.bAtivo == true &&
                         x.TipoProgramacao == TipoProgramacao &&
                         ((idRegiaoAdministrativa == 0) || x.RegiaoAdministrativaID == idRegiaoAdministrativa) &&
                         ((idPrestadora == 0) || x.PrestadoraServicosID == idPrestadora) &&
                         ((idLogradouro == 0) || x.EnderecoLogradouroID == idLogradouro) &&
                         ((idBairro == 0) || x.EnderecoBairroID == idBairro) &&
                         ((aux == 0) || x.bServicoOrdinario == bOrdinaria) &&
                         x.dtInicio >= dtInicio &&
                         x.dtInicio <= dtFim &&
                         x.TBLimpezaExecutada.ProgramacaoRealizada == false
                )
                .OrderBy(x => x.nmProgramacao).ToList();
        }

        public List<TBLimpezaEventual> CarregaGridLimpezaEventualPendente(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao)
        {
            var aux = 0;
            if (bOrdinaria && (bEventual == false))
            {
                bOrdinaria = true;
                aux = 1;
            }
            if ((bOrdinaria == false) && bEventual)
            {
                bOrdinaria = false;
                aux = 1;
            }
            var dtRef = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            return _repositoryLimpezaEventual.Get
                (
                    x => x.bAtivo == true &&
                         x.TipoProgramacao == TipoProgramacao &&
                         ((idRegiaoAdministrativa == 0) || x.RegiaoAdministrativaID == idRegiaoAdministrativa) &&
                         ((idPrestadora == 0) || x.PrestadoraServicosID == idPrestadora) &&
                         ((idLogradouro == 0) || x.EnderecoLogradouroID == idLogradouro) &&
                         ((idBairro == 0) || x.EnderecoBairroID == idBairro) &&
                         ((aux == 0) || x.bServicoOrdinario == bOrdinaria) &&
                         x.dtFim < dtRef &&
                         ((x.TBLimpezaExecutada == null) ||
                          x.TBLimpezaExecutada.dtFim == null && x.TBLimpezaExecutada.ProgramacaoRealizada)
                )
                .OrderBy(x => x.nmProgramacao).ToList();
        }

        public List<TBLimpezaEventual> CarregaGridLimpezaOrdinaria(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim)
        {
            return _repositoryLimpezaEventual.Get
                (
                    x => x.bAtivo == true &&
                         ((idRegiaoAdministrativa == 0) || x.PrestadoraServicosID == idRegiaoAdministrativa) &&
                         ((idPrestadora == 0) || x.PrestadoraServicosID == idPrestadora) &&
                         ((idLogradouro == 0) || x.EnderecoLogradouroID == idLogradouro) &&
                         ((idBairro == 0) || x.EnderecoBairroID == idBairro) &&
                         x.dtInicio >= dtInicio &&
                         x.dtInicio <= dtFim &&
                         x.bServicoOrdinario == true
                )
                .OrderBy(x => x.nmProgramacao).ToList();
        }

        public List<TBLimpezaEventual> CarregaGridLimpezaOrdinariaExecutado(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim)
        {
            return _repositoryLimpezaEventual.Get
                (
                    x => x.bAtivo == true &&
                         ((idRegiaoAdministrativa == 0) || x.PrestadoraServicosID == idRegiaoAdministrativa) &&
                         ((idPrestadora == 0) || x.PrestadoraServicosID == idPrestadora) &&
                         ((idLogradouro == 0) || x.EnderecoLogradouroID == idLogradouro) &&
                         ((idBairro == 0) || x.EnderecoBairroID == idBairro) &&
                         x.dtInicio >= dtInicio &&
                         x.dtInicio <= dtFim &&
                         x.TBLimpezaExecutada != null &&
                         x.bServicoOrdinario == true
                )
                .OrderBy(x => x.nmProgramacao).ToList();
        }

        public List<TBLimpezaEventual> CarregaGridLimpezaOrdinariaNaoExecutado(int idRegiaoAdministrativa,
            int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim)
        {
            return _repositoryLimpezaEventual.Get
                (
                    x => x.bAtivo == true &&
                         ((idRegiaoAdministrativa == 0) || x.PrestadoraServicosID == idRegiaoAdministrativa) &&
                         ((idPrestadora == 0) || x.PrestadoraServicosID == idPrestadora) &&
                         ((idLogradouro == 0) || x.EnderecoLogradouroID == idLogradouro) &&
                         ((idBairro == 0) || x.EnderecoBairroID == idBairro) &&
                         x.dtInicio >= dtInicio &&
                         x.dtInicio <= dtFim &&
                         x.TBLimpezaExecutada == null &&
                         x.bServicoOrdinario == true
                )
                .OrderBy(x => x.nmProgramacao).ToList();
        }
    }
}