using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBUsuario : DaPrefeitura
    {

        public int usuarioID { get; set; }
        public string nmUsuario { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string CPF { get; set; }
        public string matricula { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int? EnderecoID { get; set; }
        public virtual TBEndereco TBEndereco { get; set; }

    }
}