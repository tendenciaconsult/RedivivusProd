using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Simir.Application.Helpers;
using Simir.Domain.Entities;


namespace Simir.Application.ViewModels
{
    public class ListaRotasVM
    {
        public ListaRotasVM(TBRota x)
        {
            RotasID = x.RotasID;
            nmProgramacao = x.nmRota;
            nmLocalDestino = x.nmLocalDestino;
        }

        public int RotasID { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Local de Destino")]
        public string nmLocalDestino { get; set; }

    }

    public class RotasDescricaoVM
    {
        public int RotasDescricaoID { get; set; }

        public string RegiaoAdministrativaID { get; set; }
        public string nmRegiaoAdministrativa { get; set; }

        public string BairroID { get; set; }
        public string nmBairro { get; set; }

        public string LogradouroID { get; set; }
        public string nmLogradouro { get; set; }

        public string nmDirecionamento { get; set; }

        public string ExtensaoPercorrida { get; set; }
        public string PossuiPevs { get; set; }
        public int Status { get; set; }


        internal static List<RotasDescricaoVM> ToView(ICollection<TBRotasDescricao> collection)
        {
            return collection.Select(x => ToView(x)).ToList();
        }

        internal static RotasDescricaoVM ToView(TBRotasDescricao item)
        {
            return new RotasDescricaoVM
            {
                RotasDescricaoID = item.RotasDescricaoID,
                RegiaoAdministrativaID = Convert.ToString(item.RegiaoAdministrativaID),
                nmRegiaoAdministrativa = item.TBRegiaoAdministrativa.nmRegiaoAdministrativa,
                BairroID = Convert.ToString(item.EnderecoBairroID),
                nmBairro = item.TBEnderecoBairro.nmBairro,
                LogradouroID = Convert.ToString(item.EnderecoLogradouroID),
                nmLogradouro = item.TBEnderecoLogradouro.nmLogradouro,
                nmDirecionamento = item.nmDirecionamento,
                ExtensaoPercorrida = Convert.ToString(item.ExtensaoPercorrida),
                PossuiPevs = (item.PEV == true) ? "Sim" : "Não",
                Status = 1
            };
        }
    }
    public class RotasVM
    {
        public string Btn { get; set; }
        public int PrefeituraID { get; set; }
        public int RotasID { get; set; }

        public bool Excruir { get; set; }
        public bool Alterar { get; set; }
        public bool Salvar { get; set; }

        public string BtnSalvar { get; set; }
        public string BtnExcluir { get; set; }

        public RotasVM()
        {
            ListaRotas = new List<ListaRotasVM>();
            RotasDescricao = new List<RotasDescricaoVM>();
        }
        public ICollection<ListaRotasVM> ListaRotas { get; set; }

        [Display(Name = "Descrição da Rota")]
        [Ajuda("Informar a trajetória que a rota irá fazer.")]
        public IList<RotasDescricaoVM> RotasDescricao { get; set; }

        [Display(Name = "Nome da Programação")]
        [Required(ErrorMessage = "Obrigatório informar um nome para esta programação")]
        [Ajuda("Este nome será utilizado para facilitar a busca por programações.")]
        [StringLength(100)]
        public string nmRota { get; set; }


        [Display(Name = "Distancia da garagem até o início da rota")]
        [InputMask("000.000", Final = "Metros", IsReverso = true)]
        public string DistanciaGaragemRota { get; set; }

        [Display(Name = "Distancia do final da rota ao local de destino (Km)")]
        [InputMask("000.000", Final = "Metros", IsReverso = true)]
        public string DistanciaRotaDescarregamento { get; set; }

        [Display(Name = "Extenção total da rota")]
        [InputMask("000.000", Final = "Metros", IsReverso = true)]
        public string ExtensaoRota { get; set; }

        [Display(Name = "População Atendida nesta rota")]
        [InputMask("000.000", Final = "Metros", IsReverso = true)]
        public string qtPopulacaoAtendida { get; set; }

        [Display(Name = "Local de Destino")]
        public string LocalDestinoID { get; set; }
        public string nmLocalDestino { get; set; }

        internal static RotasVM ToView(TBRota item)
        {
            return new RotasVM
            {
                RotasID = item.RotasID,
                nmRota = item.nmRota,
                PrefeituraID = Convert.ToInt32(item.PrefeituraID),
                DistanciaGaragemRota = Convert.ToString(item.DistanciaGaragemRota),
                DistanciaRotaDescarregamento = Convert.ToString(item.DistanciaRotaDescarregamento),
                ExtensaoRota = Convert.ToString(item.ExtensaoRota),

                qtPopulacaoAtendida = Convert.ToString(item.qtPopulacaoAtendida),
                LocalDestinoID = Convert.ToString(item.LocalDestinoID),
                nmLocalDestino = Convert.ToString(item.nmLocalDestino),
                RotasDescricao = RotasDescricaoVM.ToView(item.TBRotasDescricaos.Where(x=>x.bAtivo).ToList())
            };
        }

    }
}
