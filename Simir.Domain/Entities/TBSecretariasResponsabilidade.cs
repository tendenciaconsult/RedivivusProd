namespace Simir.Domain.Entities
{
    public class TBSecretariasResponsabilidade
    {
        public int SecretariasResponsabilidadesID { get; set; }
        public int? ResponsabilidadesID { get; set; }
        public int? SecretariaID { get; set; }
        public int? PrefeituraID { get; set; }
        public string nmOutros { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual TBResponsabilidade TBResponsabilidade { get; set; }
        public virtual TBSecretaria TBSecretaria { get; set; }
    }
}