using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBPrestadoraServicosEquipamentosHistorico : Historico<TBPrestadoraServicosEquipamento>
    {
        public int PrestadoraServicosEquipamentosHistoricoID { get; set; }
        public int PrestadoraServicosEquipamentosID { get; set; }
        public int PrestadoraServicosID { get; set; }
        public string nmEquipamento { get; set; }
        public int qtEquipamento { get; set; }
        public decimal? Volume { get; set; }
        public string Discriminator { get; set; }

        public override void To(TBPrestadoraServicosEquipamento principal)
        {
            PrestadoraServicosEquipamentosID = principal.PrestadoraServicosEquipamentosID;
            PrestadoraServicosID = principal.PrestadoraServicosID;
            nmEquipamento = principal.nmEquipamento;
            qtEquipamento = principal.qtEquipamento;
            if (principal is TBPrestadoraServicosCaminhao)
                Volume = ((TBPrestadoraServicosCaminhao) principal).Volume;

            Discriminator = principal.GetType().Name;
        }

        public static TBPrestadoraServicosEquipamentosHistorico NewAndTo(TBPrestadoraServicosEquipamento principal)
        {
            var retorno = new TBPrestadoraServicosEquipamentosHistorico();
            retorno.To(principal);
            return retorno;
        }
    }
}