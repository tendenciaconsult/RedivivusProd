using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class HistoricoColetaOrdinariaVM
    {
        public HistoricoColetaOrdinariaVM(TBColetaOrdinaria x)
        {
            ColetaordinariaID = x.ColetaOrdinariaID;
            nmProgramacao = x.nmColetaOrdinaria;
            nmRota = x.TBRota.nmRota;
        }

        public int ColetaordinariaID { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Rota")]
        public string nmRota { get; set; }
    }

    public class ColetaOrdinariaVM
    {
        public ColetaOrdinariaVM()
        {
            HistoricoColetaOrdinaria = new List<HistoricoColetaOrdinariaVM>();
            Caminhoes = new List<CaminhaoVM>();
        }

        public string Btn { get; set; }
        public int PrefeituraID { get; set; }
        public int ColetaordinariaID { get; set; }
        public ICollection<HistoricoColetaOrdinariaVM> HistoricoColetaOrdinaria { get; set; }

        [Display(Name = "Tipos e quantidade de equipamentos e caminhões utilizados")]
        [Ajuda("Incluir os equipamentos utilizados para esta programação.")]
        public IList<CaminhaoVM> Caminhoes { get; set; }

        public IList<EquipamentoVM> Equipamentos { get; set; }

        [Display(Name = "Nome da Programação")]
        [Required(ErrorMessage = "Obrigatório informar um nome para esta programação")]
        [StringLength(200)]
        public string nmProgramacao { get; set; }

        [Display(Name = "Selecione uma Rota")]
        [Required(ErrorMessage = "Obrigatório informar a Rota Utilizada")]
        public string RotaID { get; set; }

        public string nmRota { get; set; }

        [Display(Name = "Selecione uma Prestadora de Serviços")]
        [Required(ErrorMessage = "Obrigatório informar uma prestadora de serviços")]
        public string PrestadoraServicosID { get; set; }

        public string nmPrestadoraServicos { get; set; }

        [Display(Name = "Segunda-Feira")]
        public bool bSegunda { get; set; }

        [Display(Name = "Quant. de Coleta")]
        [Ajuda("Informe quantas vezes será coletado o resíduo neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtColetaSegunda { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Ao marcar este campo o sistema entenderá que não deverá executar este serviço manualmente, obrigando assim, o usuário preencher os dados da execução deste serviço manualmente."
            )]
        public bool bSegundaFiscalizado { get; set; }

        [Display(Name = "Terça-Feira")]
        public bool bTerca { get; set; }

        [Display(Name = "Quant. de Coleta.")]
        [Ajuda("Informe quantas vezes será coletado o resíduo neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtColetaTerca { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Ao marcar este campo o sistema entenderá que não deverá executar este serviço manualmente, obrigando assim, o usuário preencher os dados da execução deste serviço manualmente."
            )]
        public bool bTercaFiscalizado { get; set; }

        [Display(Name = "Quarta-Feira")]
        public bool bQuarta { get; set; }

        [Display(Name = "Quant. de Coleta.")]
        [Ajuda("Informe quantas vezes será coletado o resíduo neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtColetaQuarta { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Ao marcar este campo o sistema entenderá que não deverá executar este serviço manualmente, obrigando assim, o usuário preencher os dados da execução deste serviço manualmente."
            )]
        public bool bQuartaFiscalizado { get; set; }

        [Display(Name = "Quinta-Feira")]
        public bool bQuinta { get; set; }

        [Display(Name = "Quant. de Coleta.")]
        [Ajuda("Informe quantas vezes será coletado o resíduo neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtColetaQuinta { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Ao marcar este campo o sistema entenderá que não deverá executar este serviço manualmente, obrigando assim, o usuário preencher os dados da execução deste serviço manualmente."
            )]
        public bool bQuintaFiscalizado { get; set; }

        [Display(Name = "Sexta-Feira")]
        public bool bSexta { get; set; }

        [Display(Name = "Quant. de Coleta.")]
        [Ajuda("Informe quantas vezes será coletado o resíduo neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtColetaSexta { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Ao marcar este campo o sistema entenderá que não deverá executar este serviço manualmente, obrigando assim, o usuário preencher os dados da execução deste serviço manualmente."
            )]
        public bool bSextaFiscalizado { get; set; }

        [Display(Name = "Sábado")]
        public bool bSabado { get; set; }

        [Display(Name = "Quant. de Coleta.")]
        [Ajuda("Informe quantas vezes será coletado o resíduo neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtColetaSabado { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Ao marcar este campo o sistema entenderá que não deverá executar este serviço manualmente, obrigando assim, o usuário preencher os dados da execução deste serviço manualmente."
            )]
        public bool bSabadoFiscalizado { get; set; }

        [Display(Name = "Domingo")]
        public bool bDomingo { get; set; }

        [Display(Name = "Quant. de Coleta.")]
        [Ajuda("Informe quantas vezes será coletado o resíduo neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtColetaDomingo { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Ao marcar este campo o sistema entenderá que não deverá executar este serviço manualmente, obrigando assim, o usuário preencher os dados da execução deste serviço manualmente."
            )]
        public bool bDomingoFiscalizado { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de Coleta.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisSegunda { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de Coleta.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisTerca { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de Coleta.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisQuarta { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de Coleta.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisQuinta { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de Coleta.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisSexta { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de Coleta.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisSabado { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de Coleta.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisDomingo { get; set; }

        internal static ColetaOrdinariaVM ToView(TBColetaOrdinaria Coleta)
        {
            return new ColetaOrdinariaVM
            {
                ColetaordinariaID = Coleta.ColetaOrdinariaID,
                RotaID = Convert.ToString(Coleta.RotasID),
                nmRota = Coleta.TBRota.nmRota,
                PrestadoraServicosID = Convert.ToString(Coleta.PrestadoraServicosID),
                nmPrestadoraServicos = Coleta.TBPrestadoraServico.nmPrestadoraServico,
                nmProgramacao = Coleta.nmColetaOrdinaria,
                bSegunda = Coleta.bSegunda,
                bTerca = Coleta.bTerca,
                bQuarta = Coleta.bQuarta,
                bQuinta = Coleta.bQuinta,
                bSexta = Coleta.bSexta,
                bSabado = Coleta.bSabado,
                PrefeituraID = Coleta.PrefeituraID,
                Caminhoes = CaminhaoVM.ToViewColetaOrdinaria(Coleta.TBEquipamentoColetaOrdinarias.Where(x => x.bAtivo).ToList()),
                qtColetaSegunda = Convert.ToInt32(Coleta.qtColetaSegunda),
                bSegundaFiscalizado = Convert.ToBoolean(Coleta.bSegundaFiscalizado),
                qtColetaTerca = Convert.ToInt32(Coleta.qtColetaTerca),
                bTercaFiscalizado = Convert.ToBoolean(Coleta.bTercaFiscalizado),
                qtColetaQuarta = Convert.ToInt32(Coleta.qtColetaQuarta),
                bQuartaFiscalizado = Convert.ToBoolean(Coleta.bQuartaFiscalizado),
                qtColetaQuinta = Convert.ToInt32(Coleta.qtColetaQuinta),
                bQuintaFiscalizado = Convert.ToBoolean(Coleta.bQuintaFiscalizado),
                qtColetaSexta = Convert.ToInt32(Coleta.qtColetaSexta),
                bSextaFiscalizado = Convert.ToBoolean(Coleta.bSextaFiscalizado),
                qtColetaSabado = Convert.ToInt32(Coleta.qtColetaSabado),
                bSabadoFiscalizado = Convert.ToBoolean(Coleta.bSabadoFiscalizado),
                bDomingo = Convert.ToBoolean(Coleta.bDomingo),
                qtColetaDomingo = Convert.ToInt32(Coleta.qtColetaDomingo),
                bDomingoFiscalizado = Convert.ToBoolean(Coleta.bDomingoFiscalizado),
                qtGarisSegunda = Convert.ToString(Coleta.qtGarisSegunda),
                qtGarisTerca = Convert.ToString(Coleta.qtGarisTerca),
                qtGarisQuarta = Convert.ToString(Coleta.qtGarisQuarta),
                qtGarisQuinta = Convert.ToString(Coleta.qtGarisQuinta),
                qtGarisSexta = Convert.ToString(Coleta.qtGarisSexta),
                qtGarisSabado = Convert.ToString(Coleta.qtGarisSabado),
                qtGarisDomingo = Convert.ToString(Coleta.qtGarisDomingo)
            };
        }
    }
}