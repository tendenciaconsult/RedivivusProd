using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class ColetaExecutadaService : ServiceBase<TBColetaExecutada>, IColetaExecutadaService
    {
        private readonly IColetaExecutadaRepository _ColetaExecutada;
        private readonly ILogEventoRepository _repositoryLog;

        public ColetaExecutadaService(IColetaExecutadaRepository ColetaExecutada,
            ILogEventoRepository repositoryLog)
            : base(ColetaExecutada)
        {
            _ColetaExecutada = ColetaExecutada;
            _repositoryLog = repositoryLog;
        }

        public async Task<TBColetaExecutada> RetornaColetaExecutadaByID(int id)
        {
            return await _ColetaExecutada.FindFirtAsync(x => x.ColetaExecutadaID == id && x.bAtivo);
        }

        public async Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBColetaExecutada Item)
        {
            var dt = DateTime.Now;

            await _ColetaExecutada.AddComHistoricoAsync(user.Id, dt, Item);
            //Add(Programação de Limpeza Ordinaria);

            var log = TBLogEvento.Novo(user, dt, "Adicionou uma nova Programação de Coleta Excecutada");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBColetaExecutada ColetaEventual)
        {
            var dt = DateTime.Now;

            _ColetaExecutada.UpdateHistorico(user.Id, dt, ColetaEventual);


            var log = TBLogEvento.Novo(user, dt, "Editou uma Programação de Coleta Excecutada");
            _repositoryLog.Add(log);

            return true;
        }
        public List<TBColetaExecutada> TotalResiduoColetado(int idResiduoColetado, int idRota, int idPrestadoraServicos,
                            DateTime dtInicio, DateTime dtFim, bool bColetaRealizada, int idPrefeitura)
        {

            return _ColetaExecutada.Get
                (
                    x => x.bAtivo &&
                        ((idPrestadoraServicos == 0) || x.TBColetaEventual.PrestadoraServicosID == idPrestadoraServicos) &&
                         ((idRota == 0) || x.TBColetaEventual.RotasID == idRota) &&
                         x.dtReferencia >= dtInicio &&
                         x.dtReferencia <= dtFim &&
                         x.bColetaRealizada == bColetaRealizada &&
                         x.PrefeituraID == idPrefeitura
                         , includeProperties: "TBColetaExecutadaDetalhadas"
                )
                .OrderBy(x => x.nmResiduoColetado)
                .ToList();
        }
    }
}