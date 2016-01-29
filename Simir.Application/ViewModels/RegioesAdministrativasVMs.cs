using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{

    public class RegiaoAdministrativaLogradouroVM
    {
        public int RegiaoAdministrativaLogradouroID { get; set; }
        public string nmEnderecoLogradouro { get; set; }
        public string EnderecoLogradouroID { get; set; }
        public string nmEnderecoBairro { get; set; }
        public string EnderecoBairroID { get; set; }
        public string qtSargetas { get; set; }
        public string qtSemPavimento { get; set; }
        public string qtAsfalto { get; set; }
        public string qtBloco { get; set; }
        public string nmOutroPavimento { get; set; }
        public string qtOutroPavimento { get; set; }
        public string qtExtensaoTotal { get; set; }
        public string qtBocaLobo { get; set; }
        public string qtLarguraVia { get; set; }

        public int bTotalmenteAsfaltado { get; set; }
        public int bRealizaLimpezaMecanica { get; set; }
        public int bRealizaLavagem { get; set; }
        public int bPossuiAreaVerde { get; set; }
        public int bLogradouroArborizado { get; set; }
        public int bPraca { get; set; }
        public int bParque { get; set; }
        public string qtArvores { get; set; }
        public int Status { get; set; }

        internal static IList<RegiaoAdministrativaLogradouroVM> ToView(
            ICollection<TBRegiaoAdministrativaLogradouro> collection)
        {
            return collection.Select(x => ToView(x)).ToList();
        }

        internal static RegiaoAdministrativaLogradouroVM ToView(TBRegiaoAdministrativaLogradouro item)
        {
            return new RegiaoAdministrativaLogradouroVM
            {
                RegiaoAdministrativaLogradouroID = item.RegiaoAdministrativaLogradouroID,
                nmEnderecoLogradouro = item.TBEnderecoLogradouro.nmLogradouro,
                EnderecoLogradouroID = Convert.ToString(item.EnderecoBairroID),
                nmEnderecoBairro = item.TBEnderecoBairro.nmBairro,
                EnderecoBairroID = Convert.ToString(item.EnderecoBairroID),
                qtSargetas = Convert.ToString(item.qtSargetas),
                qtSemPavimento = Convert.ToString(item.qtSemPavimento),
                qtAsfalto = Convert.ToString(item.qtAsfalto),
                qtBloco = Convert.ToString(item.qtBloco),
                nmOutroPavimento = item.nmOutroPavimento,
                qtOutroPavimento = Convert.ToString(item.qtOutroPavimento),
                qtExtensaoTotal = Convert.ToString(item.qtExtensaoTotal),
                qtBocaLobo = Convert.ToString(item.qtBocaLobo),
                qtLarguraVia = Convert.ToString(item.qtLarguraVia),
                bTotalmenteAsfaltado = (Convert.ToBoolean(item.bTotalmenteAsfaltado) == true) ? 1 : 0,
                bRealizaLimpezaMecanica = (Convert.ToBoolean(item.bRealizaLimpezaMecanica) == true) ? 1 :0,
                bRealizaLavagem = (Convert.ToBoolean(item.bRealizaLavagem) == true) ? 1 :0,
                bPossuiAreaVerde = (Convert.ToBoolean(item.bPossuiAreaVerde) == true) ? 1 :0,
                bLogradouroArborizado = (Convert.ToBoolean(item.bLogradouroArborizado) == true) ? 1 :0,
                bPraca = (Convert.ToBoolean(item.bPraca) == true) ? 1 :0,
                bParque = (Convert.ToBoolean(item.bParque) == true) ? 1 :0,
                qtArvores = Convert.ToString(item.qtArvores),
                Status = 1
            };
        }
    }
    public class RegioesAdministrativasCadastradasVM
    {
        public RegioesAdministrativasCadastradasVM(TBRegiaoAdministrativa x)
        {
            RegiaoAdministrativaID = x.RegiaoAdministrativaID;
            nmRegiaoAdmin = x.nmRegiaoAdministrativa;
        }

        public int RegiaoAdministrativaID { get; set; }

        [Display(Name = "Nome da Regiao Administrativa")]
        public string nmRegiaoAdmin { get; set; }

    }
    public class RegiaoAdministrativaVM
    {
        public RegiaoAdministrativaVM()
        {
            Logradouros = new List<RegiaoAdministrativaLogradouroVM>();
        }

        public string Btn { get; set; }
        public int RegiaoAdministrativaID { get; set; }
        public int PrefeituraID { get; set; }

        [Display(Name = "Selecione uma Região Administrativa")]
        [Ajuda("Obrigatório selecionar uma região administrativa para realizar  inclusão ou alteração de um logradouro."
            )]
        [Required(ErrorMessage = "Obrigatório informar uma Região Administrativa ")]
        public string nmRegiaoAdministrativa { get; set; }

        [Display(Name = "Configuralção de logradouros")]
        public ICollection<RegiaoAdministrativaLogradouroVM> Logradouros { get; set; }

        internal static RegiaoAdministrativaVM ToView(TBRegiaoAdministrativa item)
        {
            return new RegiaoAdministrativaVM
            {
                RegiaoAdministrativaID = item.RegiaoAdministrativaID,
                PrefeituraID = Convert.ToInt32(item.PrefeituraID),
                nmRegiaoAdministrativa = item.nmRegiaoAdministrativa,
                Logradouros = RegiaoAdministrativaLogradouroVM.ToView(item.TBRegiaoAdministrativaLogradouroes.Where(x => x.bAtivo == true).ToList())
            };
        }
    }
}