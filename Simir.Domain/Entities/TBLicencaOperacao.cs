using System;

namespace Simir.Domain.Entities
{
    public class TBLicencaOperacao
    {
        public int LicencaOperacaoID { get; set; }
        public string nmLicencaOperacao { get; set; }
        public string CodigoLicencaOperacao { get; set; }
        public DateTime dtValidade { get; set; }
        public int? EmpresaID { get; set; }

        public override string ToString()
        {
            return nmLicencaOperacao + " - " + CodigoLicencaOperacao;
        }

        // public virtual TBEmpresa TBEmpresa { get; set; }

        internal void Valida()
        {
            if (dtValidade < DateTime.Now)
                throw new ArgumentException(MensagensErro.dataVencida, "dtValidade");
        }


    }
}