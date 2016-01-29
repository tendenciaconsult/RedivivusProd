using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Simir.Application.Helpers;
using Simir.Domain.Entities;
using Simir.Domain.Enuns;

namespace Simir.Application.ViewModels
{
    public class ConsultaProgramacaoColetaEventualVM
    {
        public ConsultaProgramacaoColetaEventualVM(TBColetaEventual x)
        {
            ColetaID = x.ColetaEventualID;
            nmProgramacao = x.nmColetaEventual;
            dtColeta = Convert.ToDateTime(x.dtColeta).ToShortDateString();
            ServicoOrdinario = x.bColetaOrdinaria ? "Sim" : "Não";
        }

        public int ColetaID { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data da Coleta")]
        public string dtColeta { get; set; }

        [Display(Name = "Programação Ordinária")]
        public string ServicoOrdinario { get; set; }
    }

    public class ListaDetalhamentoColetaVM
    {
        public int ColetaExecutadaDetalhadaID { get; set; }
        public int ColetaExecutadaID { get; set; }
        public string HoraChegadaRota { get; set; }
        public string LocalEnchimentoCaminhao { get; set; }
        public string ExtensaoPercorridaEnchimento { get; set; }
        public string HoraEnchimento { get; set; }
        public string horaChegadaLocalDescarga { get; set; }
        public string QtResiduo { get; set; }
        public string PlacaVeiculo { get; set; }
        public bool bLitro { get; set; }
        public int Status { get; set; }

        internal static IList<ListaDetalhamentoColetaVM> ToView(ICollection<TBColetaExecutadaDetalhada> collection)
        {
            return collection.Select(x => ToView(x)).ToList();
        }

        internal static ListaDetalhamentoColetaVM ToView(TBColetaExecutadaDetalhada item)
        {
            return new ListaDetalhamentoColetaVM
            {
                ColetaExecutadaDetalhadaID = item.ColetaExecutadaDetalhadaID,
                ColetaExecutadaID = Convert.ToInt32(item.ColetaExecutadaID),
                HoraChegadaRota = item.HoraChegadaRota,
                LocalEnchimentoCaminhao = item.LocalEnchimentoCaminhao,
                ExtensaoPercorridaEnchimento = Convert.ToString(item.ExtensaoPercorridaEnchimento),
                HoraEnchimento = item.HoraEnchimento,
                horaChegadaLocalDescarga = item.horaChegadaLocalDescarga,
                QtResiduo = Convert.ToString(item.QtResiduo),
                PlacaVeiculo = item.PlacaVeiculo,
                bLitro = item.bLitro,
                Status = 1
            };
        }
    }

    public class ColetaExecutadaVM
    {
        public ColetaExecutadaVM()
        {
            TransbordoUtilizadoValor = "-1";
            TransbordoUtilizadoDescricao = "Selecione o Transbordo...";
            ListaDetalhamentoColeta = new List<ListaDetalhamentoColetaVM>();
        }

        public string Btn { get; set; }
        public int PrefeituraID { get; set; }
        public int ColetaExecutadaID { get; set; }
        public int ColetaEventualID { get; set; }
        public bool bColetaRealizada { get; set; }

        [Display(Name = "Detalhamento da coleta")]
        public ICollection<ListaDetalhamentoColetaVM> ListaDetalhamentoColeta { get; set; }

        [Display(Name = "Data da Programação *")]
        [Ajuda(
            "Com base nesta data será apresentada as programações agendadas para este dia. Não poderá selecionar uma data posterior a hoje."
            )]
        [StringLength(10)]
        [InputMask("99/99/9999", Final = "Data", IsReverso = true)]
        public string dtReferencia { get; set; }

        [Display(Name = "Nome da Programação")]
        [Ajuda(
            "Localize uma programação Atravé do botão ao lado. Será filtrado todas as programações agendadas para a data informada."
            )]
        public string nmProgramacao { get; set; }

        [Display(Name = "Motivo")]
        [Ajuda("Informe o motivo que o impediu de realizar esta programação.")]
        [StringLength(800)]
        public string Motivo { get; set; }

        [Display(Name = "Horário de saída da garagem")]
        [Ajuda(
            "Com base nesta data será apresentada as programações agendadas para este dia. Não poderá selecionar uma data posterior a hoje."
            )]
        [StringLength(10)]
        [InputMask("00:00", Final = "<span class='glyphicon glyphicon-time'></span>", IsReverso = false)]
        public string HoraSaidaGaragem { get; set; }

        [Display(Name = "Horário de chegada na garagem")]
        [Ajuda(
            "Com base nesta data será apresentada as programações agendadas para este dia. Não poderá selecionar uma data posterior a hoje."
            )]
        [StringLength(10)]
        [InputMask("00:00", Final = "<span class='glyphicon glyphicon-time'></span>", IsReverso = false)]
        public string HoraChegadaGaragem { get; set; }

        [Display(Name = "Quantidade de Garis")]
        [Ajuda("Informar a quantidade de garis alocados para esta programacao.")]
        [InputMask("000.000", IsReverso = true)]
        public string qtGaris { get; set; }

        [Display(Name = "Observação")]
        [Ajuda("Informe o motivo que o impediu de realizar esta programação.")]
        [StringLength(800)]
        public string Observacao { get; set; }

        [Display(Name = "Extensão percorrida da garagem até o inicio da rota")]
        [Ajuda("Informar a quantidade de garis alocados para esta programacao.")]
        [InputMask("000.000", Final = "Km", IsReverso = true)]
        public string ExtensaoPercorridaInicio { get; set; }

        [Display(Name = "Distancia do local de descarga à garagem")]
        [Ajuda("Informar a quantidade de garis alocados para esta programacao.")]
        [InputMask("000.000", Final = "Km", IsReverso = true)]
        public string DistanciaDescargaGaragem { get; set; }


        [Display(Name = "Prestadora de Serviços")]
        public string nmPrestadoraServicos { get; set; }

        [Display(Name = "Rota")]
        public string nmRota { get; set; }

        [Display(Name = "Tipo de Coleta:")]
        public string TipoColeta { get; set; }


        [Display(Name = "Tipo de Coleta")]
        public bool ColetaConvencional { get; set; }

        public TipoColeta TipoColetaConvencional { get; set; }

        [Display(Name = "Especifique")]
        [StringLength(100)]
        public string TipoColetaEspecifica { get; set; }



        [Display(Name = "Realiza Transbordo?")]
        public bool RealizaTransbordo { get; set; }

        [Display(Name = "Empresa que realizou o transbordo")]
        public string TransbordoUtilizadoValor { get; set; }
        public string TransbordoUtilizadoDescricao { get; set; }


        [Display(Name = "Realiza Aterro?")]
        public bool RealizaAterro { get; set; }

        [Display(Name = "Aterro")]
        public string AterroUtilizadoValor { get; set; }
        public string AterroUtilizadoDescricao { get; set; }

        [Display(Name = "Prestadora de serviço destino")]
        public string DestinadoraValor { get; set; }
        public string DestinadoraDescricao { get; set; }


        internal static ColetaExecutadaVM ToView(TBColetaEventual Coleta)
        {
            return new ColetaExecutadaVM
            {
                PrefeituraID = Coleta.PrefeituraID,
                ColetaEventualID = Coleta.ColetaEventualID,
                nmProgramacao = Coleta.nmColetaEventual,
                dtReferencia = Convert.ToDateTime(Coleta.dtColeta).ToShortDateString(),
                nmPrestadoraServicos = Coleta.TBPrestadoraServico.nmPrestadoraServico,
                nmRota = (Coleta.TBRota != null) ? Coleta.TBRota.nmRota : "Coleta realizada em pontos específicos",
                TipoColeta = Coleta.bColetaOrdinaria ? "Coleta Ordinária" : "ColetaEventual"
            };
        }
    }

    
}