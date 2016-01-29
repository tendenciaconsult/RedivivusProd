namespace Simir.Domain.Entities
{
    public class AspNetClient
    {
        public int Id { get; set; }
        public string ClientKey { get; set; }
        public string SimirUser_Id { get; set; }
        public string FuncaoSelecionada { get; set; }
    }
}