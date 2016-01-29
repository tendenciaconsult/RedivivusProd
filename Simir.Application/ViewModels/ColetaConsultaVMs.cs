using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class ConsultasColetaEventualNaoRealizadaVM
    {
        public ConsultasColetaEventualNaoRealizadaVM(TBColetaEventual x, bool bTipoPermissa)
        {
            ColetaID = x.ColetaEventualID;
            nmProgramacao = x.nmColetaEventual;
            dtColeta = Convert.ToDateTime(x.dtColeta).ToShortDateString();
            EnderecoColeta = (x.RotasID == null) ? "Endereços específicos" : x.TBRota.nmRota;
            Rota = (x.RotasID == null) ? "Não" : "Sim";

            bEditavel = bTipoPermissa;
        }

        public int ColetaID { get; set; }
        public bool bEditavel { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data da Coleta")]
        public string dtColeta { get; set; }

        [Display(Name = "Local coleta")]
        public string EnderecoColeta { get; set; }

        [Display(Name = "Rota")]
        public string Rota { get; set; }
    }

    public class ConsultasColetaEventualRealizadaVM
    {
        public ConsultasColetaEventualRealizadaVM(TBColetaEventual x, bool bTipoPermissa)
        {
            ColetaID = x.ColetaEventualID;
            nmProgramacao = x.nmColetaEventual;
            dtColeta = Convert.ToDateTime(x.dtColeta).ToShortDateString();
            EnderecoColeta = (x.RotasID == null) ? "Endereços específicos" : x.TBRota.nmRota;
            Rota = (x.RotasID == null) ? "Não" : "Sim";

            bEditavel = bTipoPermissa;
        }

        public int ColetaID { get; set; }
        public bool bEditavel { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data da Coleta")]
        public string dtColeta { get; set; }

        [Display(Name = "Local coleta")]
        public string EnderecoColeta { get; set; }

        [Display(Name = "Rota")]
        public string Rota { get; set; }
    }

    public class ConsultasColetaEventualPendenteVM
    {
        public ConsultasColetaEventualPendenteVM(TBColetaEventual x, bool bTipoPermissa)
        {
            ColetaID = x.ColetaEventualID;
            nmProgramacao = x.nmColetaEventual;
            dtColeta = Convert.ToDateTime(x.dtColeta).ToShortDateString();
            EnderecoColeta = (x.RotasID == null) ? "Endereços específicos" : x.TBRota.nmRota;
            Rota = (x.RotasID == null) ? "Não" : "Sim";

            bEditavel = bTipoPermissa;
        }

        public int ColetaID { get; set; }
        public bool bEditavel { get; set; }


        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data da Coleta")]
        public string dtColeta { get; set; }

        [Display(Name = "Local coleta")]
        public string EnderecoColeta { get; set; }

        [Display(Name = "Rota")]
        public string Rota { get; set; }
    }

    public class ConsultasColetaEventualVM
    {
        public ConsultasColetaEventualVM(TBColetaEventual x)
        {
            ColetaID = x.ColetaEventualID;
            nmProgramacao = x.nmColetaEventual;
            dtColeta = Convert.ToDateTime(x.dtColeta).ToShortDateString();
            EnderecoColeta = (x.RotasID == null) ? "Endereços específicos" : x.TBRota.nmRota;
            Rota = (x.RotasID == null) ? "Não" : "Sim";
            ProgramacaoRealizada = (x.TBColetaExecutada != null)
                ? x.TBColetaExecutada.bColetaRealizada ? true : false
                : false;
            ProgramacaoPendente = ((x.TBColetaExecutada == null) &&
                                   x.dtColeta < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                ? true
                : false;
            ProgramacaonNaoRealizada = (x.TBColetaExecutada != null)
                ? (x.TBColetaExecutada.bColetaRealizada == false) ? true : false
                : false;
            Status = ProgramacaoRealizada
                ? "Realizado com Sucesso!"
                : ProgramacaoPendente ? "Pendente!" : ProgramacaonNaoRealizada ? "Não Realizado!" : "Em Dia!";
        }

        public int ColetaID { get; set; }
        public bool ProgramacaonNaoRealizada { get; set; }
        public bool ProgramacaoRealizada { get; set; }
        public bool ProgramacaoPendente { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data da Coleta")]
        public string dtColeta { get; set; }

        [Display(Name = "Local coleta")]
        public string EnderecoColeta { get; set; }

        [Display(Name = "Rota")]
        public string Rota { get; set; }

        [Display(Name = "Status da Operação")]
        public string Status { get; set; }
    }

    public class ColetaConsultaVM
    {
        public ColetaConsultaVM()
        {
            //---------------LIMPEZA EVENTUAL------------------
            ColetaEventualNaoRealizada = new List<ConsultasColetaEventualNaoRealizadaVM>();
            ColetaEventualRealizada = new List<ConsultasColetaEventualRealizadaVM>();
            ColetaEventual = new List<ConsultasColetaEventualVM>();
            ColetaPendente = new List<ConsultasColetaEventualPendenteVM>();
        }

        public string Btn { get; set; }
        public ICollection<ConsultasColetaEventualVM> ColetaEventual { get; set; }
        public ICollection<ConsultasColetaEventualPendenteVM> ColetaPendente { get; set; }
        public ICollection<ConsultasColetaEventualRealizadaVM> ColetaEventualRealizada { get; set; }
        public ICollection<ConsultasColetaEventualNaoRealizadaVM> ColetaEventualNaoRealizada { get; set; }

        [Display(Name = "Selecione uma Prestadora de Serviços")]
        public string PrestadoraServicosID { get; set; }

        public string nmPrestadoraServicos { get; set; }

        [Display(Name = "Selecione uma Rota")]
        public string RotaID { get; set; }

        public string nmRota { get; set; }

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