using System.Collections.Generic;

namespace Simir.Application.ViewModels
{
    public class ProverAcessoVM
    {
        public int FucionarioId { get; set; }
        public string NomeCompleto { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Funcoes { get; set; }
    }
}