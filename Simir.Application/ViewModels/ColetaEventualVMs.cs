using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class ListaEnderecoColetaVM
    {
        public int EnderecosColetaEventualID { get; set; }
        public string nmSolicitante { get; set; }
        public string Telefone { get; set; }
        public string nmLocalColeta { get; set; }
        public string nmItemsRecolhido { get; set; }
        public int Status { get; set; }

        internal static IList<ListaEnderecoColetaVM> ToView(ICollection<TBEnderecosColetaEventual> collection)
        {
            return collection.Select(x => ToView(x)).ToList();
        }

        internal static ListaEnderecoColetaVM ToView(TBEnderecosColetaEventual item)
        {
            return new ListaEnderecoColetaVM
            {
                EnderecosColetaEventualID = item.EnderecosColetaEventualID,
                nmSolicitante = item.nmSolicitante,
                Telefone = item.Telefone,
                nmLocalColeta = item.EnderecoColeta,
                nmItemsRecolhido = item.ItensColeta,
                Status = 1
            };
        }
    }

    public class HistoricoColetaEventualVM
    {
        public HistoricoColetaEventualVM(TBColetaEventual x)
        {
            ColetaEventualID = x.ColetaEventualID;
            nmProgramacao = x.nmColetaEventual;
            nmRota = (x.TBRota == null) ? "" : x.TBRota.nmRota;
            dtReferencia = Convert.ToDateTime(x.dtColeta).ToShortDateString();
        }

        public int ColetaEventualID { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Rota")]
        public string nmRota { get; set; }

        [Display(Name = "Data")]
        public string dtReferencia { get; set; }
    }

    public class ColetaEventualVM
    {
        public ColetaEventualVM()
        {
            HistoricoColetaEventual = new List<HistoricoColetaEventualVM>();
            ListaEnderecoColeta = new List<ListaEnderecoColetaVM>();
            Caminhoes = new List<CaminhaoVM>();
        }

        public string Btn { get; set; }
        public int PrefeituraID { get; set; }
        public int ColetaEventualID { get; set; }
        public ICollection<HistoricoColetaEventualVM> HistoricoColetaEventual { get; set; }

        [Display(Name = "Tipos e quantidade de equipamentos e caminhões utilizados")]
        [Ajuda("Incluir os equipamentos utilizados para esta programação.")]
        public IList<ListaEnderecoColetaVM> ListaEnderecoColeta { get; set; }

        [Display(Name = "Tipos e quantidade de equipamentos e caminhões utilizados")]
        [Ajuda("Incluir os equipamentos utilizados para esta programação.")]
        public IList<CaminhaoVM> Caminhoes { get; set; }

        [Display(Name = "Nome da Programação")]
        [Required(ErrorMessage = "Obrigatório informar um nome para esta programação")]
        [Ajuda("Este nome será utilizado para facilitar a busca por programações.")]
        [StringLength(200)]
        public string nmProgramacao { get; set; }

        [Display(Name = "Selecione uma Rota")]
        public string RotaID { get; set; }

        public string nmRota { get; set; }

        [Display(Name = "Selecione uma Prestadora de Serviços")]
        [Required(ErrorMessage = "Obrigatório informar uma prestadora de serviços")]
        public string PrestadoraServicosID { get; set; }
        public string nmPrestadoraServicos { get; set; }

        [Display(Name = "Data da Coleta")]
        [StringLength(10)]
        [InputMask("99/99/9999", Final = "Data", IsReverso = true)]
        public string dtReferencia { get; set; }

        [Display(Name = "Quant. de Garis")]
        [Ajuda("Informar a quantidade de garis alocados para esta Coleta.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGaris { get; set; }

        [Display(Name = "Distancia do local da última coleta até o local de descarregamento")]
        [InputMask("000.000.000", Final = "Km", IsReverso = true)]
        public string DistanciaFinal { get; set; }

        [Display(Name = "Distancia da garagem até o local da primeira coleta")]
        [InputMask("000.000.000", Final = "Km", IsReverso = true)]
        public string DistanciaInicial { get; set; }

        internal static ColetaEventualVM ToView(TBColetaEventual Coleta)
        {
            return new ColetaEventualVM
            {
                ColetaEventualID = Coleta.ColetaEventualID,
                RotaID = (Coleta.TBRota == null) ? "" : Convert.ToString(Coleta.RotasID),
                nmRota = (Coleta.TBRota == null) ? "" : Coleta.TBRota.nmRota,
                PrestadoraServicosID = Convert.ToString(Coleta.PrestadoraServicosID),
                nmPrestadoraServicos = Coleta.TBPrestadoraServico.nmPrestadoraServico,
                nmProgramacao = Coleta.nmColetaEventual,
                PrefeituraID = Coleta.PrefeituraID,
                dtReferencia = Convert.ToDateTime(Coleta.dtColeta).ToShortDateString(),
                qtGaris = Convert.ToString(Coleta.qtGari),
                DistanciaFinal = Convert.ToString(Coleta.DistanciaFinal),
                DistanciaInicial = Convert.ToString(Coleta.DistanciaInicial),
                Caminhoes = CaminhaoVM.ToViewColetaEventual(Coleta.TBEquipamentoColetaEventuals.Where(x => x.bAtivo).ToList()),
                ListaEnderecoColeta = ListaEnderecoColetaVM.ToView(Coleta.TBEnderecosColetaEventuals.Where(x => x.bAtivo).ToList())
            };
        }
    }
}