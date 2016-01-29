using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class RotaService : ServiceBase<TBRota>, IRotaService
    {
        private readonly ILogEventoRepository _repositoryLog;
        private readonly IRotasRepository _Rota;

        public RotaService(IRotasRepository Rota,
            ILogEventoRepository repositoryLog)
            : base(Rota)
        {
            _Rota = Rota;
            _repositoryLog = repositoryLog;
        }

        public object[][] GetRotasByPrefeitura(int prefeituraID)
        {
            return
                _Rota.Get(x => x.bAtivo && x.PrefeituraID == prefeituraID)
                    .Select(x => new object[] {x.RotasID, x.nmRota})
                    .ToArray();
        }
        public async Task<TBRota> ReturnProgramacaoByID(int id)
        {
            var aux = _Rota.Get(x => x.RotasID == id , includeProperties: "TBRotasDescricaos").FirstOrDefault();

            return aux;
        }
        public async Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBRota Dados)
        {
            var dt = DateTime.Now;

            _Rota.AddHistorico(user.Id, dt, Dados);
            //Add(Programação de Limpeza Ordinaria);

            var log = TBLogEvento.Novo(user, dt, "Adicionou uma nova Rota");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBRota Dados)
        {
            var dt = DateTime.Now;

            _Rota.UpdateHistorico(user.Id, dt, Dados);


            var log = TBLogEvento.Novo(user, dt, "Editou uma Rota");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> ExcluirProgramacaoAsync(AspNetUser user, int id)
        {
            var dt = DateTime.Now;

            var Retorno = _Rota.GetById(id);

            Retorno.bAtivo = false;

            _Rota.UpdateHistorico(user.Id, dt, Retorno);


            var log = TBLogEvento.Novo(user, dt, "Desativou uma Rota");
            _repositoryLog.Add(log);

            return true;
        }

        public List<TBRota> CarregaGrid(int PrefeituraID)
        {

            return _Rota.Get
                (
                    x => x.bAtivo == true &&
                        x.PrefeituraID == PrefeituraID
                )
                .OrderBy(x => x.nmRota).ToList();
        }
    }
}