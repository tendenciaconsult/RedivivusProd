using System;
using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBEmpresa
    {
        public TBEmpresa()
        {
            TBLicencaOperacaos = new List<TBLicencaOperacao>();
            /*
            TBDestinacaoRejeitoes = new List<TBDestinacaoRejeito>();
            TBDisposicaoFinalResiduos = new List<TBDisposicaoFinalResiduo>();
            
            TBResiduosColetados = new List<TBResiduosColetado>();
            TBResiduosDestinadores = new List<TBResiduosDestinadore>();
            TBResiduosGerados = new List<TBResiduosGerado>();
            TBResiduosTratados = new List<TBResiduosTratado>();
             * */
        }

        public int EmpresaID { get; set; }
        public string nmRazaoSocial { get; set; }
        public string nmFantasia { get; set; }
        public string CNPJ { get; set; }
        public int? PorteEmpresaID { get; set; }
        public int? RamoEmpresaID { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int? EnderecoID { get; set; }
        public string InscricaoEsdatudal { get; set; }
        public string InscricaoMunicipal { get; set; }

        public string Alvara { get; set; }
        public DateTime? dtEmissaoAlvara { get; set; }
        public bool bVencIndeterminadoAlvara { get; set; }
        public DateTime? dtVencAlvara { get; set; }


        public string CNAE { get; set; }
        public int? PrefeituraID { get; set; }
        public string AlvaraFuncionamento { get; set; }
        public bool bGeradorResiduo { get; set; }
        public bool bTratamentoResiduo { get; set; }
        public bool bColetorResiduo { get; set; }
        public bool bDisposicaoFinalResiduo { get; set; }
        //public virtual ICollection<TBDestinacaoRejeito> TBDestinacaoRejeitoes { get; set; }
        //public virtual ICollection<TBDisposicaoFinalResiduo> TBDisposicaoFinalResiduos { get; set; }
        public virtual TBEndereco TBEndereco { get; set; }
        public virtual TBPorteEmpresa TBPorteEmpresa { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual TBRamoEmpresa TBRamoEmpresa { get; set; }
        public virtual ICollection<TBLicencaOperacao> TBLicencaOperacaos { get; set; }
        //public virtual ICollection<TBResiduosColetado> TBResiduosColetados { get; set; }
        //public virtual ICollection<TBResiduosDestinadore> TBResiduosDestinadores { get; set; }
        //public virtual ICollection<TBResiduosGerado> TBResiduosGerados { get; set; }
        //public virtual ICollection<TBResiduosTratado> TBResiduosTratados { get; set; }

        internal bool Validar()
        {
            if (!bColetorResiduo && !bDisposicaoFinalResiduo
                && !bGeradorResiduo && !bTratamentoResiduo)
            {
                throw new ArgumentException(MensagensErro.atividadesEmpresa, "atividadesEmpresa");
            }
            //todo:

            return true;
        }
    }
}