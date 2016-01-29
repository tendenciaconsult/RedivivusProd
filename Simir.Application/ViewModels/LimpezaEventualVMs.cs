using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class LimpezasFuturasVM
    {
        public LimpezasFuturasVM(TBLimpezaEventual x)
        {
            LimpezaID = x.LimpezaEventualID;
            nmProgramacao = x.nmProgramacao;
            dtInicio = Convert.ToDateTime(x.dtInicio).ToShortDateString();
            dtFim = Convert.ToDateTime(x.dtFim).ToShortDateString();
            nmTipoProgramacao = x.nmTipoProgramacao;
        }

        public int LimpezaID { get; set; }

        [Display(Name = "Nome da Programação")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Data de Inicio da Programação")]
        public string dtInicio { get; set; }

        [Display(Name = "Data de Encerramento")]
        public string dtFim { get; set; }

        [Display(Name = "Tipo de Programação")]
        public string nmTipoProgramacao { get; set; }
    }


    public class LimpezaEventualVM
    {
        public LimpezaEventualVM()
        {
            LimpezasFuturas = new List<LimpezasFuturasVM>();
            Equipamentos = new List<EquipamentoVM>();
        }

        public string Btn { get; set; }
        public int LimpezaEventualID { get; set; }
        public int PrefeituraID { get; set; }
        public int TipoProgramacao { get; set; }
        public ICollection<LimpezasFuturasVM> LimpezasFuturas { get; set; }

        [Display(Name = "Tipos e quantidade de equipamentos utilizados")]
        [Ajuda("Incluir os equipamentos utilizados para esta programação.")]
        public IList<EquipamentoVM> Equipamentos { get; set; }

        [Display(Name = "Nome da Programação")]
        [Ajuda("Este nome será utilizado para facilitar nas buscas e consultas.")]
        [Required(ErrorMessage = "Obrigatório informar um nome para esta programação.")]
        [StringLength(100)]
        public string nmProgramacao { get; set; }

        [Display(Name = "Selecione uma Prestadora de Serviços")]
        [Required(ErrorMessage = "Obrigatório informar uma prestadora de serviços.")]
        public string PrestadoraServicosID { get; set; }

        public string nmPrestadoraServicos { get; set; }

        [Display(Name = "Selecione uma Região Administrativa")]
        [Required(ErrorMessage = "Obrigatório informar uma Região Administrativa.")]
        public string RegiaoAdministrativaID { get; set; }

        public string nmRegiaoAdministrativa { get; set; }

        [Display(Name = "Selecione um Bairro")]
        [Required(ErrorMessage = "Obrigatório informar um bairro.")]
        public string EnderecoBairroID { get; set; }

        public string nmEnderecoBairro { get; set; }

        [Display(Name = "Selecione um Logradouro")]
        public string EnderecoLogradouroID { get; set; }

        public string nmEnderecoLogradouro { get; set; }

        [Display(Name = "Informe o Endereço")]
        [Ajuda("Informe o local que será realizada esta programação, seja ela logradouro, praças, praias, etc...")]
        [StringLength(200)]
        public string nmLogradouro { get; set; }

        [Display(Name = "Início da Limpeza")]
        [StringLength(10)]
        [InputMask("99/99/9999", Final = "Data", IsReverso = true)]
        public string dtInicio { get; set; }

        [Display(Name = "Término da Limpeza")]
        [StringLength(10)]
        [InputMask("99/99/9999", Final = "Data", IsReverso = true)]
        public string dtFim { get; set; }

        [Display(Name = "Quantidade de Garis")]
        [Ajuda("Informar a quantidade de garis alocados.")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtGaris { get; set; }

        [Display(Name = "Quantidade de Tintas Utilizados")]
        [Ajuda("Informar a quantidade de tinta que deverá ser utilizada nesta pintura.")]
        [InputMask("000.000.000", Final = "Litros", IsReverso = true)]
        public string qtTintasUtilizados { get; set; }

        internal static LimpezaEventualVM ToView(TBLimpezaEventual Limpeza)
        {
            return new LimpezaEventualVM
            {
                nmProgramacao = Limpeza.nmProgramacao,
                LimpezaEventualID = Limpeza.LimpezaEventualID,
                PrefeituraID = Limpeza.PrefeituraID,
                RegiaoAdministrativaID = Convert.ToString(Limpeza.RegiaoAdministrativaID),
                nmRegiaoAdministrativa = Limpeza.TBRegiaoAdministrativa.nmRegiaoAdministrativa,
                TipoProgramacao = Convert.ToInt32(Limpeza.TipoProgramacao),
                EnderecoBairroID = Convert.ToString(Limpeza.EnderecoBairroID),
                nmEnderecoBairro = Limpeza.TBEnderecoBairro.nmBairro,
                EnderecoLogradouroID = Convert.ToString(Limpeza.EnderecoLogradouroID),
                nmEnderecoLogradouro = Limpeza.TBEnderecoLogradouro.nmLogradouro,
                PrestadoraServicosID = Convert.ToString(Limpeza.PrestadoraServicosID),
                nmPrestadoraServicos = Limpeza.TBPrestadoraServico.nmPrestadoraServico,
                nmLogradouro = Convert.ToString(Limpeza.nmOutroLogradouro),
                dtInicio = Convert.ToString(Limpeza.dtFim).Substring(0, 10),
                dtFim = Convert.ToString(Limpeza.dtFim).Substring(0, 10),
                qtGaris = Limpeza.qtGaris.ToString(),
                qtTintasUtilizados = Limpeza.qtTintasUtilizados.ToString(),
                Equipamentos = EquipamentoVM.ToViewLimpezaEventual(Limpeza.Equipamentos.Where(x => x.bAtivo).ToList())
            };
        }
    }
}