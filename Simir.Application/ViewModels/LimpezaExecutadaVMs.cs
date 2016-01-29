using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class ConsultaProgramacaoVM
    {
        public ConsultaProgramacaoVM(TBLimpezaEventual x)
        {
            LimpezaID = x.LimpezaEventualID;
            nmProgramacao = x.nmProgramacao;
            dtFim = Convert.ToDateTime(x.dtFim).ToShortDateString();
            ServicoOrdinario = (x.bServicoOrdinario == true) ? "Sim" : "Não";
        }

        public int LimpezaID { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data Prevista conclusão")]
        public string dtFim { get; set; }

        [Display(Name = "Programação Ordinária")]
        public string ServicoOrdinario { get; set; }
    }

    public class LimpezaExecutadaVM
    {
        public LimpezaExecutadaVM()
        {
            ConsultaLimpezaEventual = new List<ConsultaProgramacaoVM>();
            Equipamentos = new List<EquipamentoVM>();
        }

        public int PrefeituraID { get; set; }
        public int LimpezaExecutadaID { get; set; }
        public string Btn { get; set; }
        public bool bProgramacaoNaoRealizada { get; set; }
        public int ProgramacaoID { get; set; }
        public ICollection<ConsultaProgramacaoVM> ConsultaLimpezaEventual { get; set; }

        [Display(Name = "Data da Programação")]
        [Ajuda(
            "Com base nesta data será apresentada as programações agendadas para este dia. Não poderá selecionar uma data posterior a hoje."
            )]
        [StringLength(10)]
        [InputMask("99/99/9999", Final = "Data", IsReverso = true)]
        public string dtProgramacao { get; set; }

        [Display(Name = "Nome da Programação")]
        [Ajuda(
            "Localize uma programação Atravé do botão ao lado. Será filtrado todas as programações agendadas para a data informada."
            )]
        public string nmProgramacao { get; set; }

        [Display(Name = "Motivo")]
        [Ajuda("Informe o motivo que o impediu de realizar esta programação.")]
        public string MotivoProgramacaoNaoRealizada { get; set; }

        [Display(Name = "Data de Início")]
        [StringLength(10)]
        [InputMask("99/99/9999", Final = "Data", IsReverso = true)]
        public string dtInicio { get; set; }

        [Display(Name = "Data de término")]
        [StringLength(10)]
        [InputMask("99/99/9999", Final = "Data", IsReverso = true)]
        public string dtFim { get; set; }

        [Display(Name = "Quantidade de Garis")]
        [Ajuda("Informar a quantidade de garis alocados para esta tarefa.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGaris { get; set; }

        [Display(Name = "Quantidade de Supervisor")]
        [Ajuda("Informar a quantidade de Supervisor alocados para esta tarefa.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtSupervisor { get; set; }

        [Display(Name = "Quantidade de Encarregado")]
        [Ajuda("Informar a quantidade de Encarregado alocados para esta tarefa.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtEncarregado { get; set; }

        [Display(Name = "Tipos e quantidade de equipamentos utilizados")]
        [Ajuda("Incluir os equipamentos utilizados para esta programação.")]
        public IList<EquipamentoVM> Equipamentos { get; set; }

        [Display(Name = "Observação")]
        public string sObservacao { get; set; }

        [Display(Name = "Data de Início")]
        public string dtInicioPlanejado { get; set; }

        [Display(Name = "Data de Término")]
        public string dtFimPlanejado { get; set; }

        [Display(Name = "Bairro")]
        public string nmBairroPlanejado { get; set; }

        [Display(Name = "Logradouro")]
        public string nmLogradouroPlanejado { get; set; }

        [Display(Name = "Outro Local")]
        public string nmOutroLocalPlanejado { get; set; }

        [Display(Name = "Feira Livre")]
        public string nmFeiraLivrePlanejado { get; set; }

        [Display(Name = "Prestadora de Serviços")]
        public string nmPrestadoraServicoPlanejado { get; set; }

        [Display(Name = "Tipo de Programação")]
        public string nmTipoProgramacao { get; set; }

        [Display(Name = "Região Administrativa")]
        public string nmRegiaoAdministrativaPlanejada { get; set; }

        internal static LimpezaExecutadaVM ToView(TBLimpezaEventual Limpeza)
        {
            return new LimpezaExecutadaVM
            {
                ProgramacaoID = Limpeza.LimpezaEventualID,
                nmProgramacao = Limpeza.nmProgramacao,
                PrefeituraID = Limpeza.PrefeituraID,
                dtProgramacao = Convert.ToDateTime(Limpeza.dtInicio).ToShortDateString(),
                dtInicioPlanejado = Convert.ToDateTime(Limpeza.dtInicio).ToShortDateString(),
                dtFimPlanejado = Convert.ToDateTime(Limpeza.dtFim).ToShortDateString(),
                nmBairroPlanejado = Limpeza.TBEnderecoBairro.nmBairro,
                nmLogradouroPlanejado = Limpeza.TBEnderecoLogradouro.nmLogradouro,
                nmOutroLocalPlanejado = Limpeza.nmOutroLogradouro,
                nmFeiraLivrePlanejado = (Limpeza.bFeiraLivre) ? "Sim" : "Não",
                nmPrestadoraServicoPlanejado = Limpeza.TBPrestadoraServico.nmPrestadoraServico,
                nmRegiaoAdministrativaPlanejada = Limpeza.TBRegiaoAdministrativa.nmRegiaoAdministrativa,
                nmTipoProgramacao = Limpeza.nmTipoProgramacao
            };
        }
    }
}