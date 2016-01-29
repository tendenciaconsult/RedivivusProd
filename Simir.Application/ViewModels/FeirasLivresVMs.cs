using System;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class ConsultaFeirasLivresVM
    {
        public ConsultaFeirasLivresVM(TBFeiraLivre x)
        {
            FeiraLivreID = x.FeiraLivreID;
            nmProgramacao = x.nmProgramacao;
            nmBairro = x.TBEnderecoBairro.nmBairro;
            nmLogradouro = x.TBEnderecoLogradouro.nmLogradouro;
        }

        public int FeiraLivreID { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Bairro")]
        public string nmBairro { get; set; }

        [Display(Name = "Logradouro")]
        public string nmLogradouro { get; set; }
    }

    public class FeirasLivresVM
    {
        public int FeiraLivreID { get; set; }
        public int PrefeituraID { get; set; }
        public string Btn { get; set; }

        [Display(Name = "Nome da Feira Livre")]
        [Required(ErrorMessage = "Obrigatório informar um nome para esta Feira Livre")]
        [Ajuda("Este nome será utilizado para localizar esta feira livre na hora de realizar a programação da limpeza.")
        ]
        [StringLength(100)]
        public string nmProgramacao { get; set; }

        [Display(Name = "Selecione uma Região Administrativa *")]
        [Required(ErrorMessage = "Obrigatório informar uma Região Administrativa.")]
        public string RegiaoAdministrativaID { get; set; }

        public string nmRegiaoAdministrativa { get; set; }

        [Display(Name = "Bairro *")]
        [Required(ErrorMessage = "Obrigatório informar um Bairro")]
        public string BairroID { get; set; }

        public string nmBairro { get; set; }

        [Display(Name = "Logradouro *")]
        [Required(ErrorMessage = "Obrigatório informar um Logradouro")]
        public string LogradouroID { get; set; }

        public string nmLogradouro { get; set; }

        internal static FeirasLivresVM ToView(TBFeiraLivre x)
        {
            return new FeirasLivresVM
            {
                FeiraLivreID = x.FeiraLivreID,
                PrefeituraID = x.PrefeituraID,
                RegiaoAdministrativaID = Convert.ToString(x.RegiaoAdministrativaID),
                nmRegiaoAdministrativa = x.TBRegiaoAdministrativa.nmRegiaoAdministrativa,
                nmProgramacao = Convert.ToString(x.nmProgramacao),
                BairroID = Convert.ToString(x.BairroID),
                nmBairro = x.TBEnderecoBairro.nmBairro,
                LogradouroID = Convert.ToString(x.LogradouroID),
                nmLogradouro = x.TBEnderecoLogradouro.nmLogradouro
            };
        }
    }
}