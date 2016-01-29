using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEmpresa
    {
        public TBEmpresa()
        {
            this.AspNetUsers = new List<AspNetUser>();
            this.TBArquivoes = new List<TBArquivo>();
            this.TBDestinacaoRejeitoes = new List<TBDestinacaoRejeito>();
            this.TBDisposicaoFinalResiduos = new List<TBDisposicaoFinalResiduo>();
            this.TBLicencaOperacaos = new List<TBLicencaOperacao>();
            this.TBResiduosGerados = new List<TBResiduosGerado>();
            this.TBResiduosColetados = new List<TBResiduosColetado>();
            this.TBResiduosDestinadores = new List<TBResiduosDestinadore>();
            this.TBResiduosDestinadorRejeitoes = new List<TBResiduosDestinadorRejeito>();
            this.TBResiduosTratados = new List<TBResiduosTratado>();
        }

        public int EmpresaID { get; set; }
        public string nmRazaoSocial { get; set; }
        public string nmFantasia { get; set; }
        public string CNPJ { get; set; }
        public Nullable<int> PorteEmpresaID { get; set; }
        public Nullable<int> RamoEmpresaID { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public Nullable<int> EnderecoID { get; set; }
        public string InscricaoEsdatudal { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string CNAE { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public string AlvaraFuncionamento { get; set; }
        public bool bGeradorResiduo { get; set; }
        public bool bTratamentoResiduo { get; set; }
        public bool bColetorResiduo { get; set; }
        public bool bDisposicaoFinalResiduo { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        public virtual ICollection<TBArquivo> TBArquivoes { get; set; }
        public virtual ICollection<TBDestinacaoRejeito> TBDestinacaoRejeitoes { get; set; }
        public virtual ICollection<TBDisposicaoFinalResiduo> TBDisposicaoFinalResiduos { get; set; }
        public virtual TBEndereco TBEndereco { get; set; }
        public virtual TBPorteEmpresa TBPorteEmpresa { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual TBRamoEmpresa TBRamoEmpresa { get; set; }
        public virtual ICollection<TBLicencaOperacao> TBLicencaOperacaos { get; set; }
        public virtual ICollection<TBResiduosGerado> TBResiduosGerados { get; set; }
        public virtual ICollection<TBResiduosColetado> TBResiduosColetados { get; set; }
        public virtual ICollection<TBResiduosDestinadore> TBResiduosDestinadores { get; set; }
        public virtual ICollection<TBResiduosDestinadorRejeito> TBResiduosDestinadorRejeitoes { get; set; }
        public virtual ICollection<TBResiduosTratado> TBResiduosTratados { get; set; }
    }
}
