namespace Simir.Domain.Entities
{
    public abstract class TBPrestadoraServicosEquipamento
    {
        public int PrestadoraServicosEquipamentosID { get; set; }
        public string nmEquipamento { get; set; }
        public int qtEquipamento { get; set; }
        public int PrestadoraServicosID { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBPrestadoraServico PrestadoraServico { get; set; }
    }

    public class TBPrestadoraServicosEquipamentoPoda : TBPrestadoraServicosEquipamento
    {
    }

    public class TBPrestadoraServicosVarredeira : TBPrestadoraServicosEquipamento
    {
    }

    public class TBPrestadoraServicosCaminhao : TBPrestadoraServicosEquipamento
    {
        public decimal? Volume { get; set; }
    }
}