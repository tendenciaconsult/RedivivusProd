using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Simir.Application.Helpers;
using Simir.Domain.Entities;
namespace Simir.Application.ViewModels
{
    public class ReceitasDespesasVM
    {
        public string Btn { get; set; }
        public string LancamentoID { get; set; }
        public int PrefeituraID { get; set; }

        [Display(Name = "Tipo de Lançamento")]
        public bool bReceita { get; set; }

        [Display(Name = "Título")]
        [Ajuda("Este campo consiste em informar um nome para este lançamento, a fim de auxiliar na identificação do mesmo nos relatórios ou nos campos de buscas.")]
        [StringLength(200)]
        public string nmLancamento { get; set; }


        [Display(Name = "Data")]
        [Ajuda("Informar a data que foi realizada a entrada/saída de capital.")]
        [StringLength(10)]
        [InputMask("99/99/9999", Final = "Data", IsReverso = true)]
        public string dtReferencia { get; set; }

        [Display(Name = "Descrição do lançamento")]
        [Ajuda("Informe uma breve descrição sobre este lançamento.")]
        [StringLength(800)]
        public string Descricao { get; set; }

        [Display(Name = "Valor")]
        [Ajuda("Valor")]
        [InputMask("000.000", Final = "R$", IsReverso = true)]
        public string valor { get; set; }

        [Display(Name = "Selecione uma Prestadora de Serviços")]
        public string PrestadoraServicosID { get; set; }
        public string nmPrestadoraServicos { get; set; }

        [Display(Name = "Categoria do lançamento")]
        public string CategoriaID { get; set; }
        public string nmCategoria { get; set; }
    }
}
