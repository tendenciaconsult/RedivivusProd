using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class ConsultasLimpezaEventualNaoRealizadaVM
    {
        public ConsultasLimpezaEventualNaoRealizadaVM(TBLimpezaEventual x, bool bTipoPermissa)
        {
            LimpezaID = x.LimpezaEventualID;
            nmProgramacao = x.nmProgramacao;
            dtInicio = Convert.ToDateTime(x.dtInicio).ToShortDateString();
            dtFim = Convert.ToDateTime(x.dtFim).ToShortDateString();
            Logradouro = x.TBEnderecoLogradouro.nmLogradouro;
            OutroLocal = x.nmOutroLogradouro;

            bEditavel = bTipoPermissa;
        }

        public int LimpezaID { get; set; }
        public bool bEditavel { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data de Inicio")]
        public string dtInicio { get; set; }

        [Display(Name = "Data de Encerramento")]
        public string dtFim { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Outro Local")]
        public string OutroLocal { get; set; }
    }

    public class ConsultasLimpezaEventualPendenteVM
    {
        public ConsultasLimpezaEventualPendenteVM(TBLimpezaEventual x, bool bTipoPermissa)
        {
            LimpezaID = x.LimpezaEventualID;
            nmProgramacao = x.nmProgramacao;
            dtInicio = Convert.ToDateTime(x.dtInicio).ToShortDateString();
            dtFim = Convert.ToDateTime(x.dtFim).ToShortDateString();
            Logradouro = x.TBEnderecoLogradouro.nmLogradouro;
            OutroLocal = x.nmOutroLogradouro;

            bEditavel = bTipoPermissa;
        }

        public int LimpezaID { get; set; }
        public bool bEditavel { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data de Inicio")]
        public string dtInicio { get; set; }

        [Display(Name = "Data de Encerramento")]
        public string dtFim { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Outro Local")]
        public string OutroLocal { get; set; }
    }

    public class ConsultasLimpezaEventualRealizadaVM
    {
        public ConsultasLimpezaEventualRealizadaVM(TBLimpezaEventual x, bool bTipoPermissa)
        {
            LimpezaID = x.LimpezaEventualID;
            nmProgramacao = x.nmProgramacao;
            dtInicio = Convert.ToDateTime(x.dtInicio).ToShortDateString();
            dtFim = Convert.ToDateTime(x.dtFim).ToShortDateString();
            Logradouro = x.TBEnderecoLogradouro.nmLogradouro;
            OutroLocal = x.nmOutroLogradouro;

            bEditavel = bTipoPermissa;
        }

        public int LimpezaID { get; set; }
        public bool bEditavel { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data de Inicio")]
        public string dtInicio { get; set; }

        [Display(Name = "Data de Encerramento")]
        public string dtFim { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Outro Local")]
        public string OutroLocal { get; set; }
    }

    public class ConsultasLimpezaEventualVM
    {
        public ConsultasLimpezaEventualVM(TBLimpezaEventual x, bool bTipoPermissa) 
        {
            LimpezaID = x.LimpezaEventualID;
            nmProgramacao = x.nmProgramacao;
            dtInicio = Convert.ToDateTime(x.dtInicio).ToShortDateString();
            dtFim = Convert.ToDateTime(x.dtFim).ToShortDateString();
            Logradouro = x.TBEnderecoLogradouro.nmLogradouro;
            OutroLocal = x.nmOutroLogradouro;
            ProgramacaoRealizada = (x.TBLimpezaExecutada != null)
                ? x.TBLimpezaExecutada.ProgramacaoRealizada ? true : false
                : false;
            ProgramacaoPendente = ((x.TBLimpezaExecutada == null) &&
                                   x.dtFim < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                ? true
                : false;
            ProgramacaonNaoRealizada = (x.TBLimpezaExecutada != null)
                ? (x.TBLimpezaExecutada.ProgramacaoRealizada == false) ? true : false
                : false;
            Status = ProgramacaoRealizada
                ? "Realizado com Sucesso!"
                : ProgramacaoPendente ? "Pendente!" : ProgramacaonNaoRealizada ? "Não Realizado!" : "Em Dia!";

            bEditavel = bTipoPermissa;
        }

        public int LimpezaID { get; set; }
        public bool ProgramacaonNaoRealizada { get; set; }
        public bool ProgramacaoRealizada { get; set; }
        public bool ProgramacaoPendente { get; set; }

        public bool bEditavel { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data de Inicio")]
        public string dtInicio { get; set; }

        [Display(Name = "Data de Encerramento")]
        public string dtFim { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Outro Local")]
        public string OutroLocal { get; set; }

        [Display(Name = "Status da Operação")]
        public string Status { get; set; }
    }

    //------------------------limpeza ORDINARIA------------------------------
    public class ConsultasLimpezaOrdinariaNaoRealizadaVM
    {
        public ConsultasLimpezaOrdinariaNaoRealizadaVM(TBLimpezaEventual x)
        {
            LimpezaID = x.LimpezaEventualID;
            nmProgramacao = x.nmProgramacao;
            dtInicio = Convert.ToDateTime(x.dtInicio).ToShortDateString();
            dtFim = Convert.ToDateTime(x.dtFim).ToShortDateString();
            Logradouro = x.TBEnderecoLogradouro.nmLogradouro;
            OutroLocal = x.nmOutroLogradouro;
        }

        public int LimpezaID { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data de Inicio")]
        public string dtInicio { get; set; }

        [Display(Name = "Data de Encerramento")]
        public string dtFim { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Outro Local")]
        public string OutroLocal { get; set; }
    }

    public class ConsultasLimpezaOrdinariaRealizadaVM
    {
        public ConsultasLimpezaOrdinariaRealizadaVM(TBLimpezaEventual x)
        {
            LimpezaID = x.LimpezaEventualID;
            nmProgramacao = x.nmProgramacao;
            dtInicio = Convert.ToDateTime(x.dtInicio).ToShortDateString();
            dtFim = Convert.ToDateTime(x.dtFim).ToShortDateString();
            Logradouro = x.TBEnderecoLogradouro.nmLogradouro;
            OutroLocal = x.nmOutroLogradouro;
        }

        public int LimpezaID { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data de Inicio")]
        public string dtInicio { get; set; }

        [Display(Name = "Data de Encerramento")]
        public string dtFim { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Outro Local")]
        public string OutroLocal { get; set; }
    }

    public class ConsultasLimpezaOrdinariaVM
    {
        public ConsultasLimpezaOrdinariaVM(TBLimpezaEventual x)
        {
            LimpezaID = x.LimpezaEventualID;
            nmProgramacao = x.nmProgramacao;
            dtInicio = Convert.ToDateTime(x.dtInicio).ToShortDateString();
            dtFim = Convert.ToDateTime(x.dtFim).ToShortDateString();
            Logradouro = x.TBEnderecoLogradouro.nmLogradouro;
            OutroLocal = x.nmOutroLogradouro;
        }

        public int LimpezaID { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data de Inicio")]
        public string dtInicio { get; set; }

        [Display(Name = "Data de Encerramento")]
        public string dtFim { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Outro Local")]
        public string OutroLocal { get; set; }
    }

    public class LimpezaConsultaVM
    {
        public LimpezaConsultaVM()
        {
            //---------------LIMPEZA EVENTUAL------------------
            LimpezaEventualNaoRealizada = new List<ConsultasLimpezaEventualNaoRealizadaVM>();
            LimpezaEventualRealizada = new List<ConsultasLimpezaEventualRealizadaVM>();
            LimpezaEventual = new List<ConsultasLimpezaEventualVM>();
            //-------------------LIMPEZA ORDINARIA    
            LimpezaOrdinariaNaoRealizada = new List<ConsultasLimpezaOrdinariaNaoRealizadaVM>();
            LimpezaOrdinariaRealizada = new List<ConsultasLimpezaOrdinariaRealizadaVM>();
            LimpezaOrdinaria = new List<ConsultasLimpezaOrdinariaVM>();
        }

        public int TipoProgramacao { get; set; }
        public string Btn { get; set; }
        public bool bGridCarregado { get; set; }
        public ICollection<ConsultasLimpezaEventualVM> LimpezaEventual { get; set; }
        public ICollection<ConsultasLimpezaEventualRealizadaVM> LimpezaEventualRealizada { get; set; }
        public ICollection<ConsultasLimpezaEventualNaoRealizadaVM> LimpezaEventualNaoRealizada { get; set; }
        public ICollection<ConsultasLimpezaOrdinariaVM> LimpezaOrdinaria { get; set; }
        public ICollection<ConsultasLimpezaOrdinariaRealizadaVM> LimpezaOrdinariaRealizada { get; set; }
        public ICollection<ConsultasLimpezaOrdinariaNaoRealizadaVM> LimpezaOrdinariaNaoRealizada { get; set; }

        [Display(Name = "Selecione uma Prestadora de Serviços")]
        public string PrestadoraServicosID { get; set; }

        public string nmPrestadoraServicos { get; set; }

        [Display(Name = "Selecione uma Região Administrativa")]
        public string RegiaoAdministrativaID { get; set; }

        public string nmRegiaoAdministrativa { get; set; }

        [Display(Name = "Selecione um Bairro")]
        public string EnderecoBairroID { get; set; }

        public string nmEnderecoBairro { get; set; }

        [Display(Name = "Selecione um Logradouro")]
        public string EnderecoLogradouroID { get; set; }

        public string nmEnderecoLogradouro { get; set; }

        [Display(Name = "Inicio")]
        [StringLength(10)]
        [InputMask("99/99/9999", Final = "Data", IsReverso = true)]
        public string dtInicio { get; set; }

        [Display(Name = "Fim")]
        [StringLength(10)]
        [InputMask("99/99/9999", Final = "Data", IsReverso = true)]
        public string dtFim { get; set; }

        [Display(Name = "Informe o Tipo de Consulta Desejado")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string TipoConsultaID { get; set; }

        public string nmTipoConsulta { get; set; }

        [Display(Name = "Programaçao Ordinária")]
        public bool bOrdinaria { get; set; }

        [Display(Name = "Programação Eventual")]
        public bool bEventual { get; set; }
    }
}