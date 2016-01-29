using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class LimpezaOrdinariaVM
    {
        public LimpezaOrdinariaVM()
        {
            LimpezasCadastrados = new List<LimpezasCadastradosVM>();
            RegiaoAdministrativaID = "";
            nmRegiaoAdministrativa = "Selecione uma Região Administrativa...";

            PrestadoraServicosID = "";
            nmPrestadoraServicos = "Selecione uma Prestadora de Serviços...";
        }

        public int LimpezaOrdinariaID { get; set; }
        public int PrefeituraID { get; set; }
        public string Btn { get; set; }
        public int TipoServico { get; set; }
        public ICollection<LimpezasCadastradosVM> LimpezasCadastrados { get; set; }

        [Display(Name = "Nome da programação *")]
        [StringLength(100)]
        [Required(ErrorMessage = "Obrigatório informar um nome para esta programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Selecione uma Região Administrativa *")]
        [Required(ErrorMessage = "Obrigatório informar uma Região Administrativa")]
        public string RegiaoAdministrativaID { get; set; }

        public string nmRegiaoAdministrativa { get; set; }

        [Display(Name = "Prestadora de Serviço *")]
        [Required(ErrorMessage = "Obrigatório informar uma Prestadora de Serviço")]
        public string PrestadoraServicosID { get; set; }

        public string nmPrestadoraServicos { get; set; }

        [Display(Name = "Feira Livre")]
        [Ajuda("Informe em qual feira livre será realizada esta programação.")]
        public string FeiraLivreID { get; set; }

        public string nmFeiraLivre { get; set; }

        [Display(Name = "Bairro")]
        public string BairroID { get; set; }

        public string nmBairro { get; set; }

        [Display(Name = "Logradouro")]
        public string LogradouroID { get; set; }

        public string nmLogradouro { get; set; }

        [Display(Name = "Extensão de sarjeta que será varrida.")]
        [Ajuda("Informar a metragem que será varrido neste logradouro.")]
        [InputMask("000.000.000", Final = "Metros", IsReverso = true)]
        public string ExtensaoSargetas { get; set; }

        [Display(Name = "Segunda-Feira")]
        public bool bSegunda { get; set; }

        [Display(Name = "Quant. de Varrição")]
        [Ajuda("informe quantas vezes será varrido o logradouro ou feira livre neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtVarricaoSegunda { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Selecione este campo caso esta rua será fiscalizada, e deverá informar manualmente os dados referente a execução deste serviço."
            )]
        public bool bSegundaFiscalizado { get; set; }

        [Display(Name = "Terça-Feira")]
        public bool bTerca { get; set; }

        [Display(Name = "Quant. de Varrição.")]
        [Ajuda("informe quantas vezes será varrido o logradouro ou feira livre neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtVarricaoTerca { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Selecione este campo caso esta rua será fiscalizada, e deverá informar manualmente os dados referente a execução deste serviço."
            )]
        public bool bTercaFiscalizado { get; set; }

        [Display(Name = "Quarta-Feira")]
        public bool bQuarta { get; set; }

        [Display(Name = "Quant. de Varrição.")]
        [Ajuda("informe quantas vezes será varrido o logradouro ou feira livre neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtVarricaoQuarta { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Selecione este campo caso esta rua será fiscalizada, e deverá informar manualmente os dados referente a execução deste serviço."
            )]
        public bool bQuartaFiscalizado { get; set; }

        [Display(Name = "Quinta-Feira")]
        public bool bQuinta { get; set; }

        [Display(Name = "Quant. de Varrição.")]
        [Ajuda("informe quantas vezes será varrido o logradouro ou feira livre neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtVarricaoQuinta { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Selecione este campo caso esta rua será fiscalizada, e deverá informar manualmente os dados referente a execução deste serviço."
            )]
        public bool bQuintaFiscalizado { get; set; }

        [Display(Name = "Sexta-Feira")]
        public bool bSexta { get; set; }

        [Display(Name = "Quant. de Varrição.")]
        [Ajuda("informe quantas vezes será varrido o logradouro ou feira livre neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtVarricaoSexta { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Selecione este campo caso esta rua será fiscalizada, e deverá informar manualmente os dados referente a execução deste serviço."
            )]
        public bool bSextaFiscalizado { get; set; }

        [Display(Name = "Sábado")]
        public bool bSabado { get; set; }

        [Display(Name = "Quant. de Varrição.")]
        [Ajuda("informe quantas vezes será varrido o logradouro ou feira livre neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtVarricaoSabado { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Selecione este campo caso esta rua será fiscalizada, e deverá informar manualmente os dados referente a execução deste serviço."
            )]
        public bool bSabadoFiscalizado { get; set; }

        [Display(Name = "Domingo")]
        public bool bDomingo { get; set; }

        [Display(Name = "Quant. de Varrição.")]
        [Ajuda("informe quantas vezes será varrido o logradouro ou feira livre neste dia.")]
        [InputMask("000", IsReverso = true)]
        public int qtVarricaoDomingo { get; set; }

        [Display(Name = "Será Fiscalizado")]
        [Ajuda(
            "Selecione este campo caso esta rua será fiscalizada, e deverá informar manualmente os dados referente a execução deste serviço."
            )]
        public bool bDomingoFiscalizado { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de varrição.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisSegunda { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de varrição.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisTerca { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de varrição.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisQuarta { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de varrição.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisQuinta { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de varrição.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisSexta { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de varrição.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisSabado { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados por dia de varrição.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGarisDomingo { get; set; }

        [Display(Name = "Expecifique")]
        [Ajuda("Informe o tipo de serviço a ser realizado!")]
        [StringLength(100)]
        public string nmOutroServico { get; set; }

        //LimpezaOrdinariaID = Convert.ToInt32(Limpeza.LimpezaOrdinariaID),

        internal static LimpezaOrdinariaVM ToView(TBLimpezaOrdinaria Limpeza)
        {
            return new LimpezaOrdinariaVM
            {
                nmProgramacao = Limpeza.nmProgramacao,
                LimpezaOrdinariaID = Convert.ToInt32(Limpeza.LimpezaOrdinariaID),
                PrefeituraID = Limpeza.PrefeituraID,
                RegiaoAdministrativaID = Convert.ToString(Limpeza.RegiaoAdministrativaID),
                nmRegiaoAdministrativa = Limpeza.TBRegiaoAdministrativa.nmRegiaoAdministrativa,
                PrestadoraServicosID = Convert.ToString(Limpeza.PrestadoraServicosID),
                nmPrestadoraServicos = Limpeza.TBPrestadoraServico.nmPrestadoraServico,
                ExtensaoSargetas = Convert.ToString(Limpeza.ExtensaoSargetas),
                BairroID = (Limpeza.EnderecoBairroID == null) ? null : Convert.ToString(Limpeza.EnderecoBairroID),
                nmBairro = (Limpeza.EnderecoBairroID == null) ? null : Limpeza.TBEnderecoBairro.nmBairro,
                LogradouroID =
                    (Limpeza.EnderecoLogradouroID == null) ? null : Convert.ToString(Limpeza.EnderecoLogradouroID),
                nmLogradouro = (Limpeza.EnderecoLogradouroID == null) ? null : Limpeza.TBEnderecoLogradouro.nmLogradouro,
                FeiraLivreID = (Limpeza.FeiraLivreID == null) ? null : Convert.ToString(Limpeza.FeiraLivreID),
                nmFeiraLivre = (Limpeza.FeiraLivreID == null) ? null : Limpeza.TBFeiraLivre.nmProgramacao,
                nmOutroServico = Limpeza.nmOutroServico,
                TipoServico = Convert.ToInt32(Limpeza.TipoServico),
                bSegunda = Limpeza.bSegunda,
                qtVarricaoSegunda = Convert.ToInt32(Limpeza.qtVarricaoSegunda),
                bSegundaFiscalizado = Limpeza.bSegundaFiscalizado,
                bTerca = Limpeza.bTerca,
                qtVarricaoTerca = Convert.ToInt32(Limpeza.qtVarricaoTerca),
                bTercaFiscalizado = Limpeza.bTercaFiscalizado,
                bQuarta = Limpeza.bQuarta,
                qtVarricaoQuarta = Convert.ToInt32(Limpeza.qtVarricaoQuarta),
                bQuartaFiscalizado = Limpeza.bQuartaFiscalizado,
                bQuinta = Limpeza.bQuinta,
                qtVarricaoQuinta = Convert.ToInt32(Limpeza.qtVarricaoQuinta),
                bQuintaFiscalizado = Limpeza.bQuintaFiscalizado,
                bSexta = Limpeza.bSexta,
                qtVarricaoSexta = Convert.ToInt32(Limpeza.qtVarricaoSexta),
                bSextaFiscalizado = Limpeza.bSextaFiscalizado,
                bSabado = Limpeza.bSabado,
                qtVarricaoSabado = Convert.ToInt32(Limpeza.qtVarricaoSabado),
                bSabadoFiscalizado = Limpeza.bSabadoFiscalizado,
                bDomingo = Limpeza.bDomingo,
                qtVarricaoDomingo = Convert.ToInt32(Limpeza.qtVarricaoDomingo),
                bDomingoFiscalizado = Limpeza.bDomingoFiscalizado,
                qtGarisSegunda = Convert.ToString(Limpeza.qtGarisSegunda),
                qtGarisTerca = Convert.ToString(Limpeza.qtGarisTerca),
                qtGarisQuarta = Convert.ToString(Limpeza.qtGarisQuarta),
                qtGarisQuinta = Convert.ToString(Limpeza.qtGarisQuinta),
                qtGarisSexta = Convert.ToString(Limpeza.qtGarisSexta),
                qtGarisSabado = Convert.ToString(Limpeza.qtGarisSabado),
                qtGarisDomingo = Convert.ToString(Limpeza.qtGarisDomingo)
            };
        }
    }

    public class LimpezasCadastradosVM
    {
        public LimpezasCadastradosVM(TBLimpezaOrdinaria x)
        {
            nmProgramacao = (x.nmProgramacao == null) ? "" : x.nmProgramacao;
            LimpezaID = x.LimpezaOrdinariaID;
            nmLogradouro = (x.EnderecoLogradouroID != null)
                ? x.TBEnderecoLogradouro.nmLogradouro
                : (x.FeiraLivreID == null) ? "" : x.TBFeiraLivre.TBEnderecoLogradouro.nmLogradouro;
            nmBairro = (x.EnderecoBairroID != null)
                ? x.TBEnderecoBairro.nmBairro
                : (x.FeiraLivreID == null) ? "" : x.TBFeiraLivre.TBEnderecoBairro.nmBairro;
            nmPrestadoraServico = x.TBPrestadoraServico.nmPrestadoraServico;
            nmRegiaoAdmin = x.TBRegiaoAdministrativa.nmRegiaoAdministrativa;
            bFeiraLivre = (x.FeiraLivreID == null) ? "Não" : "Sim";
        }

        public int LimpezaID { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Nome do Logradouro")]
        public string nmLogradouro { get; set; }

        [Display(Name = "Nome do Bairro")]
        public string nmBairro { get; set; }

        [Display(Name = "Nome da Prestadora de Serviço")]
        public string nmPrestadoraServico { get; set; }

        [Display(Name = "Nome da Regiao Administrativa")]
        public string nmRegiaoAdmin { get; set; }

        [Display(Name = "Feira Livre")]
        public string bFeiraLivre { get; set; }
    }
}