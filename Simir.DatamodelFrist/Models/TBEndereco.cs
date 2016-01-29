using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEndereco
    {
        public TBEndereco()
        {
            this.TBEmpresas = new List<TBEmpresa>();
            this.TBPrefeituras = new List<TBPrefeitura>();
            this.TBPrestadoraServicos = new List<TBPrestadoraServico>();
            this.TBSecretarias = new List<TBSecretaria>();
            this.TBUsuarios = new List<TBUsuario>();
        }

        public int EnderecoID { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int EnderecoBairroID { get; set; }
        public int EnderecoCidadeID { get; set; }
        public int EnderecoEstadoID { get; set; }
        public string CEP { get; set; }
        public string nmLogradouro { get; set; }
        public virtual ICollection<TBEmpresa> TBEmpresas { get; set; }
        public virtual TBEnderecoBairro TBEnderecoBairro { get; set; }
        public virtual TBEnderecoCidade TBEnderecoCidade { get; set; }
        public virtual TBEnderecoEstado TBEnderecoEstado { get; set; }
        public virtual ICollection<TBPrefeitura> TBPrefeituras { get; set; }
        public virtual ICollection<TBPrestadoraServico> TBPrestadoraServicos { get; set; }
        public virtual ICollection<TBSecretaria> TBSecretarias { get; set; }
        public virtual ICollection<TBUsuario> TBUsuarios { get; set; }
    }
}
