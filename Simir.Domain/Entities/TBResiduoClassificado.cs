namespace Simir.Domain.Entities
{
    public class TBResiduoClassificado
    {
        public int ResiduoClassificadoID { get; set; }
        public int ResiduoListaID { get; set; }
        public virtual TBResiduoLista Lista { get; set; }
        public int ResiduoAtividadeID { get; set; }
        public virtual TBResiduoAtividade Atividade { get; set; }
        public int ResiduoClasseID { get; set; }
        public virtual TBResiduoClasse Classe { get; set; }
        public int ResiduoID { get; set; }
        public virtual TBResiduo Residuo { get; set; }
    }
}