namespace Simir.Domain.Entities
{
    public abstract class TBArquivo
    {
        public int ArquivoID { get; set; }
        public string nmArquivo { get; set; }
        public string Url { get; set; }
        //public string Discriminator { get; set; }
        public int Tamanho { get; set; }
    }
}