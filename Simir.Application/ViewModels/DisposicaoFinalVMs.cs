using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class DisposicaoFinalHistoricoVM
    {
        public DisposicaoFinalHistoricoVM(TBDisposicaoFinalResiduo x)
        {
            EmpresaID = x.EmpresaID;
            DisposicaoFinalResiduoID = x.DisposicaoFinalResiduoID;
            CNPJTransportadora = x.CNPJTransportadora;
            nmRazaoSocialTransportadora = x.nmRazaoSocialTransportadora;
            dtRecebimento = Convert.ToDateTime(x.dtRecebimento).ToShortDateString();
            qtRejeito = x.qtRejeito;
            AterroControlado = (x.bAterroControlado == true)?"Sim": "Não";
        }

        public int DisposicaoFinalResiduoID { get; set; }
        public string CNPJTransportadora { get; set; }
        public int EmpresaID { get; set; }

        [Display(Name = "Transportadora")]
        public string nmRazaoSocialTransportadora { get; set; }
        [Display(Name = "Data do Lançamento")]
        public string dtRecebimento { get; set; }
        [Display(Name = "Quantidade")]
        public double qtRejeito { get; set; }
        [Display(Name = "Mês de Refeência")]
        public string MesRef { get; set; }
        
        [Display(Name = "Aterro Controlado?")]
        public string AterroControlado { get; set; }


    }
    public class DisposicaoFinalVM
    {
        public string Btn { get; set; }
        public int DisposicaoFinalResiduoID { get; set; }
        public int EmpresaID { get; set; }

        public DisposicaoFinalVM()
        {

        }
        [Display(Name = "CNPJ")]
        public string TransportadoraCnpj { get; set; }

        [Display(Name = "Razão Social")]
        public string TransportadoraSocial { get; set; }

        [Display(Name = "Mês Referência")]
        [StringLength(7)]
        [InputMask("99/9999")]
        public string DataEntrega { get; set; }

        [InputMask("999.999.999", Final = "kg")]
        public string Quantidade { get; set; }

        [Display(Name = "Aterro Controlado?")]
        public bool bAterroControlado { get; set; }

        //public ICollection<ResiduosRecebidosBasicoVM> ResiduosTratadosHistorico { get; set; }

    }
}